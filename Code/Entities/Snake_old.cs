using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Entities
{
	class Snake_old : Entity
	{
		private const int INITIAL_LENGTH = 6;

		private List<BodyPart> BodyParts;

		private int DirX;
		private int DirY;

		private double TimePassed;
		private const double MOVE_RATE = 0.1;

		public Snake_old(Vector2 position) : base(new Vector2(0, 0))
		{
			SetTexture("snake");
			SetZ(55);
			LoadContent();

			BodyParts = new List<BodyPart>();
			DirX = 0;
			DirY = -1;
			TimePassed = 0;

			InitializeSnake(position);
		}

		public void InitializeSnake(Vector2 position)
		{
			for (int i = INITIAL_LENGTH-1; i >= 0; i--)
			{
				BodyParts.Add(new BodyPart((int)position.X, (int)position.Y + i));
			}
		}

		public void CheckKeyboard()
		{
			KeyboardState keyState = Keyboard.GetState();
			KeyboardState prevKeyState = GameState.Instance.GetPrevKeyboardState();

			if (keyState.IsKeyDown(Keys.Up) && !prevKeyState.IsKeyDown(Keys.Up) && DirY != 1)
			{
				DirX = 0;
				DirY = -1;
			}

			if (keyState.IsKeyDown(Keys.Down) && !prevKeyState.IsKeyDown(Keys.Down) && DirY != -1)
			{
				DirX = 0;
				DirY = 1;
			}

			if (keyState.IsKeyDown(Keys.Left) && !prevKeyState.IsKeyDown(Keys.Left) && DirX != 1)
			{
				DirX = -1;
				DirY = 0;
			}

			if (keyState.IsKeyDown(Keys.Right) && !prevKeyState.IsKeyDown(Keys.Right) && DirX != -1)
			{
				DirX = 1;
				DirY = 0;
			}
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			CheckKeyboard();

			TimePassed += gameTime.ElapsedGameTime.TotalSeconds;

			if (TimePassed > MOVE_RATE)
			{
				TimePassed = TimePassed % MOVE_RATE;

				BodyPart head = BodyParts[BodyParts.Count - 1];
				BodyParts.RemoveAt(0);
				BodyParts.Add(new BodyPart(head.X + DirX, head.Y + DirY));
			}
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			int counter = 0;
			
			foreach (BodyPart bodyPart in BodyParts)
			{
				int drawTileNum = 0;

				if (counter == 0)
					drawTileNum = 5; // tail

				if (counter == BodyParts.Count-1)
					drawTileNum = 1; // head


				bodyPart.Draw(spriteBatch, GetTexture(), drawTileNum);

				counter++;
			}
		}
	}

	class BodyPart
	{
		public int X;
		public int Y;
		public int DrawTileNum;

		public BodyPart(int x, int y, int drawTileNum=2)
		{
			X = x;
			Y = y;
			DrawTileNum = drawTileNum;
		}

		public void Draw(SpriteBatch spriteBatch, Texture2D texture, int drawTileNum=0)
		{
			int offsetX = GameState.Instance.GetCurrentScene().GetWindowWidth() / 2;
			int offsetY = 0;
			int tileSize = texture.Height;

			drawTileNum = drawTileNum == 0 ? DrawTileNum : drawTileNum;

			Rectangle rect = new Rectangle((drawTileNum-1)*tileSize, 0, tileSize, tileSize);
			spriteBatch.Draw(texture, new Rectangle(offsetX + X * tileSize, offsetY + Y * tileSize, rect.Width, rect.Height), rect, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0);
		}
	}
}
