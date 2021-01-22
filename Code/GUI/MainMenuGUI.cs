using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PingoSnake.Code.Scenes;
using PingoSnake.Code.Spritefonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.GUI
{
	class MainMenuGUI : Entity
	{
		private MyFont32 myFont32;
		private MyFont64 myFont64;
		private MyFont128 myFont128;

		private string[] Options;
		private int CurrentOption;

		public MainMenuGUI() : base(new Vector2(0, 0))
		{
			myFont32 = new MyFont32();
			myFont64 = new MyFont64();
			myFont128 = new MyFont128();

			Options = new string[] { "start_game", "practice_pingo", "practice_snake", "exit" };
			CurrentOption = 0;

			SetZ(100);
			SetPausable(false);
		}

		public void CheckKeyboard()
		{
			KeyboardState keyState = Keyboard.GetState();
			KeyboardState prevKeyState = GameState.Instance.GetPrevKeyboardState();

			if ((keyState.IsKeyDown(Keys.Up) && !prevKeyState.IsKeyDown(Keys.Up)) || (keyState.IsKeyDown(Keys.W) && !prevKeyState.IsKeyDown(Keys.W)))
			{
				if (CurrentOption > 0)
				{
					CurrentOption -= 1;
					GameState.Instance.GetCurrentScene().PlaySoundEffect("menu_select");
				}
			}

			if ((keyState.IsKeyDown(Keys.Down) && !prevKeyState.IsKeyDown(Keys.Down)) || (keyState.IsKeyDown(Keys.S) && !prevKeyState.IsKeyDown(Keys.S)))
			{
				if (CurrentOption < Options.Length-1)
				{
					CurrentOption += 1;
					GameState.Instance.GetCurrentScene().PlaySoundEffect("menu_select");
				}
			}
			
			if (keyState.IsKeyDown(Keys.Enter) && !prevKeyState.IsKeyDown(Keys.Enter))
			{
				if (Options[CurrentOption] == "start_game")
				{
					GameState.Instance.SetScene(new MainLevel());
				}

				if (Options[CurrentOption] == "practice_pingo")
				{
					GameState.Instance.SetScene(new PingoLevel());
				}

				if (Options[CurrentOption] == "practice_snake")
				{
					GameState.Instance.SetScene(new SnakeLevel());
				}

				if (Options[CurrentOption] == "exit")
				{
					GameState.Instance.GetGameReference().Exit();
				}
					
			}
		}

		public bool IsOptionActive(string option)
		{
			return Options[CurrentOption] == option;
		}

		public Color GetOptionColor(string option)
		{
			if (IsOptionActive(option))
				return Color.Cyan;

			return Color.White;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			CheckKeyboard();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			myFont128.DrawText(spriteBatch, "PINGO SNAKE", GameState.Instance.GetCurrentScene().GetWindowWidth() / 2 - 370, GameState.Instance.GetCurrentScene().GetWindowHeight() / 2 - 350);

			myFont64.DrawText(spriteBatch, "Start game", GameState.Instance.GetCurrentScene().GetWindowWidth() / 2 - 180, GameState.Instance.GetCurrentScene().GetWindowHeight() / 2 - 150, GetOptionColor("start_game"));
			myFont64.DrawText(spriteBatch, "Practice Pingo", GameState.Instance.GetCurrentScene().GetWindowWidth() / 2 - 240, GameState.Instance.GetCurrentScene().GetWindowHeight() / 2 - 60, GetOptionColor("practice_pingo"));
			myFont64.DrawText(spriteBatch, "Practice Snake", GameState.Instance.GetCurrentScene().GetWindowWidth() / 2 - 240, GameState.Instance.GetCurrentScene().GetWindowHeight() / 2 + 30, GetOptionColor("practice_snake"));
			myFont64.DrawText(spriteBatch, "Exit", GameState.Instance.GetCurrentScene().GetWindowWidth() / 2 - 70, GameState.Instance.GetCurrentScene().GetWindowHeight() / 2 + 120, GetOptionColor("exit"));

		}
	}
}
