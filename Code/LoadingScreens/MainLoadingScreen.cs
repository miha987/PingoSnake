using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PingoSnake.Code.Engine;
using PingoSnake.Code.Entities;
using PingoSnake.Code.Spritefonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.LoadingScreens
{
	class MainLoadingScreen : LoadingScreen
	{
		private MyFont128 myFont128;
		private LoadingSpinner spinner;

		public MainLoadingScreen(Scene scene) : base(scene)
		{
		}

		public override void LoadTextures()
		{
			base.LoadTextures();

			AddTexture("good_neighbors_128", newName: "spritefont128");
			AddTexture("loading128", newName: "loading");
		}

		public override void Initialize()
		{
			base.Initialize();

			myFont128 = new MyFont128();
			spinner = new LoadingSpinner(new Vector2(GameState.Instance.GetCurrentScene().GetWindowWidth() / 2 - 64, GameState.Instance.GetCurrentScene().GetWindowHeight() / 2 + 30));

			spinner.LoadContent(); // DONT FORGET TO CALL THIS FOR EACH ENTITY IN LOADING SCREENS!
			spinner.SetOriginPoint(new Vector2(0, 0));
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			spinner.Update(gameTime);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.GraphicsDevice.Clear(new Color(21, 192, 222));

			myFont128.DrawText(spriteBatch, "Loading...", GameState.Instance.GetCurrentScene().GetWindowWidth() / 2 - 250, GameState.Instance.GetCurrentScene().GetWindowHeight() / 2 - 100);

			spinner.Draw(spriteBatch);
		}
	}
}
