using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using PingoSnake.Code.Entities;

namespace PingoSnake.Code.SpawnControllers
{
	class EnemySpawnController : SpawnController
	{
		private Enemy LastSpawnedEnemy;

		private const int MIN_ENEMY_DISTANCE = 500;
		private const int MAX_ENEMY_DISTANCE = 3000;
		private const double SPAWN_RATE = 0.01;
		private const double WALRUS_RATE = 0.5;

		private Random SpawnRandom;

		public EnemySpawnController() : base()
		{
			LastSpawnedEnemy = null;
			SpawnRandom = new Random();
		}

		public void CheckIfCanSpawn()
		{
			int lastEnemyDistance = 0;
			Vector2 spawnPoint = GameState.Instance.GetVar<Vector2>("spawn_point");
			Penguin penguin = GameState.Instance.GetVar<Penguin>("penguin");

			spawnPoint.X = penguin.GetPosition().X + GameState.Instance.GetCurrentScene().GetWindowWidth();

			if (LastSpawnedEnemy != null)
			{
				lastEnemyDistance = (int)spawnPoint.X - (int)LastSpawnedEnemy.GetPosition().X;
			}

			double spawnChance = this.SpawnRandom.NextDouble();

			if (LastSpawnedEnemy == null || lastEnemyDistance >= MAX_ENEMY_DISTANCE || (lastEnemyDistance >= MIN_ENEMY_DISTANCE && spawnChance < SPAWN_RATE ))
			{
				double walrusChance = this.SpawnRandom.NextDouble();

				if (walrusChance < WALRUS_RATE)
				{
					Walrus walrus = new Walrus(spawnPoint);
					GameState.Instance.GetCurrentScene().AddEntity(walrus);
					LastSpawnedEnemy = walrus;
				} else
				{
					spawnPoint.Y = spawnPoint.Y - 90;
					Seagull seagull = new Seagull(spawnPoint);
					GameState.Instance.GetCurrentScene().AddEntity(seagull);
					LastSpawnedEnemy = seagull;
				}
			}
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			this.CheckIfCanSpawn();
		}
	}
}
