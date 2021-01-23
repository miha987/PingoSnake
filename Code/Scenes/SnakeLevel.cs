using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PingoSnake.Code.Engine;
using PingoSnake.Code.Entities;
using PingoSnake.Code.GUI;
using PingoSnake.Code.LoadingScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Scenes
{
	class SnakeLevel : Scene
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
		}

		public override void LoadSounds()
		{
			base.LoadSounds();

			AddSoundEffect("eat1", "eat");
			AddSoundEffect("dizzy", "dizzy");
		}

		public override LoadingScreen GetLoadingScreen(Scene scene)
		{
			return new MainLoadingScreen(scene);
		}

		public override void Initialize()
		{
			base.Initialize();

			int floor_pos_y = this.GetWindowHeight() - 128;

			SnakeBackground snakeBackground1 = new SnakeBackground(new Vector2(0, 0));
			SnakeBackground snakeBackground2 = new SnakeBackground(new Vector2(1025, 0));
			AddEntity(snakeBackground1);
			AddEntity(snakeBackground2);

			Snake snake = new Snake(new Vector2(400, floor_pos_y - 128), new Vector2(0, 0), new Rectangle(0, 0, GetWindowWidth(), GetWindowHeight()));
			AddEntity(snake);

			GameGUI gameGUI = new GameGUI();
			AddEntity(gameGUI);


			GameState.Instance.SetVar<bool>("game_over", false);
			GameState.Instance.SetVar<double>("score", 0);
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
					GameState.Instance.SetScene(new SnakeLevel());
			}

			if (keyState.IsKeyDown(Keys.Escape) && !prevKeyState.IsKeyDown(Keys.Escape))
			{
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
