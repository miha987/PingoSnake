using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PingoSnake.Code.Entities;
using PingoSnake.Code.Spritefonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.GUI
{
	class GameGUI : Entity
	{
		private MyFont32 myFont32;
		private MyFont64 myFont64;
		private MyFont128 myFont128;

		private bool DrawPaused;
		private bool GameOver;

		public GameGUI() : base(new Vector2(0, 0))
		{
			myFont32 = new MyFont32();	 
			myFont64 = new MyFont64();	 
			myFont128 = new MyFont128();
			
			DrawPaused = false;
			GameOver = false;

			SetZ(100);
			SetPausable(false);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			GameOver =  GameState.Instance.GetVar<bool>("game_over");

			DrawPaused = GameState.Instance.GetCurrentScene().IsPaused() && !GameOver;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			myFont64.DrawText(spriteBatch, "SCORE:", 100, 100);
			//myFont64.DrawText(spriteBatch, ((int)GameState.Instance.GetVar<Penguin>("penguin").GetPosition().X / 100).ToString(), 310, 100);

			double score = GameState.Instance.GetVar<double>("score");
			string display_score = Math.Round(score / 100).ToString();
			myFont64.DrawText(spriteBatch, display_score, 310, 100);
		
			if (DrawPaused)
			{
				myFont128.DrawText(spriteBatch, "PAUSED", GameState.Instance.GetCurrentScene().GetWindowWidth()/2 - 200, GameState.Instance.GetCurrentScene().GetWindowHeight()/2 - 100);
			}

			if (GameOver)
			{
				myFont128.DrawText(spriteBatch, "GAME OVER", GameState.Instance.GetCurrentScene().GetWindowWidth() / 2 - 300, GameState.Instance.GetCurrentScene().GetWindowHeight() / 2 - 100);
				myFont64.DrawText(spriteBatch, "To start new game press Enter", GameState.Instance.GetCurrentScene().GetWindowWidth() / 2 - 500, GameState.Instance.GetCurrentScene().GetWindowHeight() / 2 + 40);
			}
		}
	}
}
