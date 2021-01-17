using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingoSnake
{
	class SpawnManager
	{
		private List<SpawnController> SpawnControllers;

		public SpawnManager()
		{
			this.SpawnControllers = new List<SpawnController>();
		}

		public void AddSpawnController(SpawnController spawnController)
		{
			this.SpawnControllers.Add(spawnController);
		}

		public void RemoveSpawnController(SpawnController spawnController)
		{
			this.SpawnControllers.Remove(spawnController);
		}

		public void Update(GameTime gameTime)
		{
			foreach (SpawnController spawnController in this.SpawnControllers)
			{
				spawnController.Update(gameTime);
			} 
		}
	}
}
