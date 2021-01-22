using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Entities
{
	class Snake : Entity
	{
		const float ROTATION_SPEED = 0.07f;
		private const int INITIAL_LENGTH = 4;
		private const int HEIGHT = 48;
		private const int FOOD_SCORE = 20 * 100;

		private Vector2 FieldOffset;
		private Rectangle FieldBounds;

		private SnakePart Head;
		private List<SnakePart> SnakeParts;
		private LinkedList<Vector2> MovementPath;

		private Food CurrentFood;

		Random FoodRandomizer;

		public Snake(Vector2 position, Vector2 fieldOffset, Rectangle fieldBounds) : base(new Vector2(0, 0))
		{
			SetTexture("snake5");
			SetZ(55);
			LoadContent();

			FieldOffset = fieldOffset;
			FieldBounds = fieldBounds;

			SnakeParts = new List<SnakePart>();
			MovementPath = new LinkedList<Vector2>();

			FoodRandomizer = new Random();

			InitializeSnake(position);
			AddFood();
		}

		public void InitializeSnake(Vector2 position)
		{
			Head = new SnakePart((int)position.X, (int)position.Y, HEIGHT, 1);

			for (int i = 0; i < INITIAL_LENGTH; i++)
			{
				SnakeParts.Add(new SnakePart((int)position.X, (int)position.Y + i*HEIGHT, HEIGHT));
			}
		}

		public void AddFood()
		{
			int offsetX = HEIGHT;
			int offsetY = HEIGHT;

			int fX = FoodRandomizer.Next(offsetX, FieldBounds.Width - offsetX) + (int)FieldOffset.X;
			int fY = FoodRandomizer.Next(offsetY, FieldBounds.Height - offsetY) + (int)FieldOffset.Y;

			Trace.WriteLine($"FOOD: {fX}, {fY}");

			CurrentFood = new Food(new Vector2(fX, fY));
			GameState.Instance.GetCurrentScene().AddEntity(CurrentFood);
		}

		public void SetGameOver()
		{
			GameState.Instance.GetCurrentScene().Pause();
			GameState.Instance.SetVar<bool>("game_over", true);
		}

		public void UpdateHeadMovement(GameTime gameTime)
		{
			float rX = (float)Math.Cos((double)Head.Rotation);
			float rY = (float)Math.Sin((double)Head.Rotation);

			float length = (float)Math.Sqrt((rX * rX) + (rY * rY));

			Head.SpeedX = (rX / length) * Head.Speed;
			Head.SpeedY = (rY / length) * Head.Speed;

			float dX = Head.SpeedX * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
			float dY = Head.SpeedY * (float)gameTime.ElapsedGameTime.TotalMilliseconds;


			Head.X += (int)dX;
			Head.Y += (int)dY;

			MovementPath.AddFirst(Head.GetPosition());
		}

		public void UpdateBodyMovement()
		{
			int counter = 1;
			if (MovementPath.Count == 0)
				return;


			foreach (SnakePart snakePart in SnakeParts)
			{
				float distanceToHead = HEIGHT * counter;

				Vector2 prevPoint = MovementPath.First.Value;

				float sumDistance = 0;

				bool found = false;

				LinkedListNode<Vector2> nextNode = MovementPath.First.Next;

				while (nextNode != null)
				{
					Vector2 point = nextNode.Value;
					Vector2 diffToPrev = point - prevPoint;
					float distanceToPrev = diffToPrev.Length();
					//sumDistance += distanceToPrev;

					if ((sumDistance + distanceToPrev) >= distanceToHead)
					{
						float percentageToDesiredPoint = (distanceToHead - sumDistance) / distanceToPrev;

						Vector2 desiredPosition = prevPoint + (diffToPrev * percentageToDesiredPoint);

						snakePart.X = (int)Math.Round(desiredPosition.X);
						snakePart.Y = (int)Math.Round(desiredPosition.Y);

						found = true;

						// REMOVE MOVEMENT PATHS WE DONT NEED ANYMORE
						if (counter == SnakeParts.Count)
						{
							int to_skip = 20;
							int skipCounter = 0;

							// WE NEED TO SKIP A FEW, OTHERWISE THERE IS A PROBLEM WHILE ADDING NEW PART
							while (nextNode != null && skipCounter < to_skip)
							{
								nextNode = nextNode.Next;
								skipCounter += 1;
							} 

							if (skipCounter >= to_skip && nextNode != null)
							{
								while (nextNode != MovementPath.Last)
								{
									MovementPath.RemoveLast();
								}
							}
						}
						
						break;
					}

					sumDistance += distanceToPrev;

					prevPoint = point;
					nextNode = nextNode.Next;
				}
				
				if (!found)
				{
					Vector2 diffToHead = Head.GetPosition() - snakePart.GetPosition();
					float distToHead = diffToHead.Length();

					float percentageToDesiredPoint = (distToHead - distanceToHead) / distToHead;
					Vector2 desiredPosition = snakePart.GetPosition() + (diffToHead * percentageToDesiredPoint);

					snakePart.X = (int)Math.Round(desiredPosition.X);
					snakePart.Y = (int)Math.Round(desiredPosition.Y);
				}

				counter += 1;
			}
		}

		public void CheckKeyboard(GameTime gameTime)
		{
			KeyboardState keyState = Keyboard.GetState();
			//KeyboardState prevKeyState = GameState.Instance.GetPrevKeyboardState();


			if (keyState.IsKeyDown(Keys.Left))
			{
				Head.Rotation -= ROTATION_SPEED;
			}

			if (keyState.IsKeyDown(Keys.Right))
			{
				Head.Rotation += ROTATION_SPEED;
			}
		}

		public void CheckCollisions() 
		{
			Rectangle headRectangle = Head.GetRectangle();

			Rectangle foodRectangle = CurrentFood.GetRectangle();
			foodRectangle.X -= (int)FieldOffset.X;
			foodRectangle.Y -= (int)FieldOffset.Y;

			if (foodRectangle.Intersects(headRectangle))
			{
				CurrentFood.Remove();
				AddFood();
				SnakeParts.Add(new SnakePart(-1, -1, HEIGHT));

				double score = GameState.Instance.GetVar<double>("score");
				score += FOOD_SCORE;
				GameState.Instance.SetVar<double>("score", score);

				GameState.Instance.GetCurrentScene().PlaySoundEffect("eat");
			}

			if (headRectangle.Top < FieldBounds.Y || headRectangle.Bottom > FieldBounds.Height || headRectangle.Left < FieldBounds.X || headRectangle.Right > FieldBounds.Width)
			{
				SetGameOver();
			}

			foreach (SnakePart snakePart in SnakeParts.Skip(INITIAL_LENGTH))
			{
				if (snakePart.GetRectangle().Intersects(headRectangle))
				{
					SetGameOver();
				}
			}
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			CheckKeyboard(gameTime);
			UpdateHeadMovement(gameTime);
			UpdateBodyMovement();
			CheckCollisions();

			// Trace.WriteLine(MovementPath.Count);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			Head.Draw(spriteBatch, GetTexture(), FieldOffset);

			foreach (SnakePart snakePart in SnakeParts)
			{
				snakePart.Draw(spriteBatch, GetTexture(), FieldOffset);
			}
		}
	}

	class SnakePart
	{
		public int X;
		public int Y;
		public float Rotation;
		public int DrawTileNum;
		public float SpeedX;
		public float SpeedY;
		public float Speed;

		public int TileSize;
		public Vector2 OriginPoint;

		public SnakePart(int x, int y, int tileSize, int drawTileNum = 2)
		{
			X = x;
			Y = y;
			DrawTileNum = drawTileNum;
			Rotation = -1.54f;
			SpeedX = 0;
			SpeedY = 0;
			Speed = 0.4f;

			TileSize = tileSize;
			OriginPoint = new Vector2(tileSize / 2, tileSize / 2);
		}

		public Vector2 GetPosition()
		{
			return new Vector2(X, Y);
		}

		public Rectangle GetRectangle()
		{
			return new Rectangle((int)(X - OriginPoint.X) + 5, (int)(Y - OriginPoint.Y) + 5, TileSize - 5, TileSize - 5);
		}

		public void Draw(SpriteBatch spriteBatch, Texture2D texture, Vector2 FieldOffset, int drawTileNum = 0)
		{
			// LITLE HACK
			if (X == -1 && Y == -1)
				return;

			drawTileNum = drawTileNum == 0 ? DrawTileNum : drawTileNum;

			Rectangle rect = new Rectangle((drawTileNum - 1) * TileSize, 0, TileSize, TileSize);
			spriteBatch.Draw(texture, new Rectangle((int)FieldOffset.X + X, (int)FieldOffset.Y + Y, rect.Width, rect.Height), rect, Color.White, Rotation, OriginPoint, SpriteEffects.None, 0);
		}
	}
}

