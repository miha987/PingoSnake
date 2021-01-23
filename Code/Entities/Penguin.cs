using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PingoSnake.Code.Entities
{
	class Penguin : Entity
	{
		private bool Jumping = false;
		private bool Ducking = false;

		private float Speed = 0.7f;
		private float Acceleration = 0.03f;
		private float JumpForce = -0.7f;
		private float ForceY = 0f;

		private const int FOOD_SCORE = 15 * 100;

		public Penguin(Vector2 position) : base(position)
		{
			this.SetTexture("penguin");
			this.AddTag("penguin");
			this.SetCheckCollisions(true);

			this.InitializeAnimations();
		}

		public void InitializeAnimations()
		{
			this.EnableAnimator(6, 2);

			int[] penguinRunningFrames = { 1, 2, 3, 4, 5 };
			int[] penguinRunningDuckedFrames = { 7, 8, 9, 10, 11 };
			int[] penguinJumpingFrames = { 6 };
			int[] penguinFallingFrames = { 2 };

			Animation penguinRunning = new Animation("penguin_running", penguinRunningFrames, 0.04);
			Animation penguinRunningDucked = new Animation("penguin_running_ducked", penguinRunningDuckedFrames, 0.04);
			Animation penguinJumping = new Animation("penguin_jumping", penguinJumpingFrames, 0.04);
			Animation penguinFalling = new Animation("penguin_falling", penguinFallingFrames, 0.04);

			this.AddAnimation(penguinRunning);
			this.AddAnimation(penguinRunningDucked);
			this.AddAnimation(penguinJumping);
			this.AddAnimation(penguinFalling);

			this.SetAnimation("penguin_running");
		}

		public static string[] requestedTextures()
        {
			return new string[]
			{

			};
        }

		public static Dictionary<string, string> requestedSoundEffects()
        {
			Dictionary<string, string> d = new Dictionary<string, string>();
			d.Add("jump2", "jump");
			d.Add("duck3", "duck");
			return d;
        }

		public override void Initialize()
		{
			base.Initialize();

			this.SetOriginPoint(new Vector2(0, 0));
			SetBoundingRectangle(new Rectangle(40, 0, GetWidth() - 40, GetHeight() - 15));
		}

		public void CheckKeyboard(GameTime gameTime)
		{
			KeyboardState keyState = Keyboard.GetState();
			KeyboardState prevKeyState = GameState.Instance.GetPrevKeyboardState();

			if (keyState.IsKeyDown(Keys.S) && !this.Jumping && !this.Ducking)
			{
				this.Ducking = true;
				this.SetAnimation("penguin_running_ducked");
				SetBoundingRectangle(new Rectangle(40, GetHeight() / 2, GetWidth() -40, (GetHeight() / 2) - 15 ));
				GameState.Instance.GetCurrentScene().PlaySoundEffect("duck");
			}

			if (!keyState.IsKeyDown(Keys.S) && prevKeyState.IsKeyDown(Keys.S))
			{
				this.Ducking = false;
				this.SetAnimation("penguin_running");
				SetBoundingRectangle(new Rectangle(40, 0, GetWidth()-40, GetHeight() - 15));
			}

			//if (keyState.IsKeyDown(Keys.W) && !prevKeyState.IsKeyDown(Keys.W) && !this.Jumping)
			if (keyState.IsKeyDown(Keys.W) && !this.Jumping)
			{
				this.Jumping = true;
				this.ForceY = this.JumpForce;
				this.SetAnimation("penguin_jumping");
				GameState.Instance.GetCurrentScene().PlaySoundEffect("jump");
			}
		}

		public void Move(GameTime gameTime)
		{
			if (this.Jumping)
			{
				this.ForceY += this.Acceleration;

				if (this.ForceY <= 0)
				{
					this.SetAnimation("penguin_jumping");
				} else
				{
					this.SetAnimation("penguin_falling");
				}
			}

			float dx = this.Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
			float dy = this.ForceY * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			//Trace.WriteLine(dx);

			this.Move((int)dx, (int)dy);

			int floor_pos_y = GameState.Instance.GetVar<int>("floor_pos_y");

			if (this.Jumping && this.GetScene() != null && (this.GetPosition().Y + this.GetHeight()) > floor_pos_y)
			{
				this.Jumping = false;
				this.SetPosition(new Vector2(this.GetPosition().X, floor_pos_y - this.GetHeight()));
				this.ForceY = 0f;
				this.SetAnimation("penguin_running");
			}
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			CheckKeyboard(gameTime);
			Move(gameTime);

			List<Entity> collisions = GetMyCollisionsWithTag("enemy");

			if (collisions.Count > 0)
			{
				// Remove();
				GameState.Instance.GetCurrentScene().Pause();
				GameState.Instance.SetVar<bool>("game_over", true);
			}

			List<Entity> scoreCollisions = GetMyCollisionsWithTag("score");
			if (scoreCollisions.Count > 0)
            {
				// add to score
				double score = GameState.Instance.GetVar<double>("score");
				score += FOOD_SCORE;
				GameState.Instance.SetVar<double>("score", score);

				// remove score entity
				foreach(Entity e in scoreCollisions)
                {
					e.Remove();
                }
			}
		}
	}
}
