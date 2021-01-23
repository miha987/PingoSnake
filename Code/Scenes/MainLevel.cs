using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PingoSnake.Code.Engine;
using PingoSnake.Code.Entities;
using PingoSnake.Code.GUI;
using PingoSnake.Code.LoadingScreens;
using PingoSnake.Code.SpawnControllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingoSnake.Code.Scenes
{
	class MainLevel : Scene
	{
		public override void LoadTextures()
		{
			base.LoadTextures();

			this.AddTexture("ice_background_1", newName: "ice_background");
			this.AddTexture("ice_tile_platform_1", newName: "ice_platform");
			this.AddTexture("running_penguin_with_duck_1_cropped", newName: "penguin");
			this.AddTexture("walrus_1", newName: "walrus");
			this.AddTexture("seagule2", newName: "seagull");
			this.AddTexture("good_neighbors_32", newName: "spritefont32");
			this.AddTexture("good_neighbors_64", newName: "spritefont64");
			//this.AddTexture("good_neighbors_128", newName: "spritefont128");
			this.AddTexture("snake_v2", newName: "snake");
			this.AddTexture("snake_v3", newName: "snake3");
			this.AddTexture("snake_v4", newName: "snake4");
			this.AddTexture("snake_v5", newName: "snake5");
			this.AddTexture("snake_v6", newName: "snake6");
			this.AddTexture("snake_v7", newName: "snake7");
			this.AddTexture("food20", newName: "food");
			//this.AddTexture("dirt_background", newName: "dirt_background");
			this.AddTexture("dirt_background1", newName: "dirt_background");
			this.AddTexture("divideLine1", newName: "divide_line");
		}

		public override void LoadSounds()
		{
			base.LoadSounds();

			AddSong("mainTheme", "main_theme");

			foreach (KeyValuePair<string, string> soundEffect in Penguin.requestedSoundEffects())
			{
				AddSoundEffect(soundEffect.Key, soundEffect.Value);
			}
			AddSoundEffect("eat1", "eat");
			AddSoundEffect("dizzy", "dizzy");
		}

		public override LoadingScreen GetLoadingScreen(Scene scene)
		{
			return new MainLoadingScreen(scene);
		}

		/*public override LoadingScreen GetLoadingScreen()
		{
			return new MainLoadingScreen();
		}*/

		public override void Initialize()
		{
			base.Initialize();

			int floor_pos_y = this.GetWindowHeight() - 128;

			IceBackground background = new IceBackground(new Vector2(0, -800));
			this.AddEntity(background);

			IcePlatform platform = new IcePlatform(new Vector2(0, floor_pos_y));
			this.AddEntity(platform);

			Penguin penguin = new Penguin(new Vector2(300, floor_pos_y - 128));
			this.AddEntity(penguin);

			SnakeBackground snakeBackground = new SnakeBackground(new Vector2(GetWindowWidth() / 2, 0));
			AddEntity(snakeBackground);

			DivideLine divideLine = new DivideLine(new Vector2(GetWindowWidth() / 2 - 10, 0));
			AddEntity(divideLine);

			Snake snake = new Snake(new Vector2(400, floor_pos_y - 128), new Vector2(GetWindowWidth()/2 + 10, 0), new Rectangle(0, 0, (GetWindowWidth() / 2)-10, GetWindowHeight()));
			AddEntity(snake);

			GameGUI gameGUI = new GameGUI();
			AddEntity(gameGUI);

			Vector2 spawnPoint = new Vector2((int)penguin.GetPosition().X + this.GetWindowWidth(), floor_pos_y - 64);

			GameState.Instance.SetVar<int>("floor_pos_y", floor_pos_y);
			GameState.Instance.SetVar<Penguin>("penguin", penguin);
			GameState.Instance.SetVar<Vector2>("spawn_point", spawnPoint);
			GameState.Instance.SetVar<bool>("game_over", false);
			GameState.Instance.SetVar<double>("score", 0);

			//this.Camera.SetScreenOffset(0.18, 0.83);
			this.Camera.SetScreenOffset(0.10, 0.83);
			this.Camera.FollowOnlyXAxis();
			this.Camera.FollowEntity(penguin);

			EnemySpawnController enemySpawnController = new EnemySpawnController();
			AddSpawnController(enemySpawnController);

			PlaySong("main_theme");
		}

		public void CheckKeyboard()
		{
			KeyboardState keyState = Keyboard.GetState();
			KeyboardState prevKeyState = GameState.Instance.GetPrevKeyboardState();

			if (keyState.IsKeyDown(Keys.P) && !prevKeyState.IsKeyDown(Keys.P))
			{
				if (!GameState.Instance.GetVar<bool>("game_over"))
					TogglePause();
			}

			if (keyState.IsKeyDown(Keys.Enter) && !prevKeyState.IsKeyDown(Keys.Enter))
			{
				if (GameState.Instance.GetVar<bool>("game_over"))
					GameState.Instance.SetScene(new MainLevel());
			}

			if (keyState.IsKeyDown(Keys.Escape) && !prevKeyState.IsKeyDown(Keys.Escape))
			{
				StopSong();
				GameState.Instance.SetScene(new MainMenu());
			}
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			CheckKeyboard();
		}
	}
}
