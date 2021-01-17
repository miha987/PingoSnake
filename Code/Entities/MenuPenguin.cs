using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Entities
{
	class MenuPenguin : Entity
	{
		private float Speed = 0.7f;

		public MenuPenguin(Vector2 position) : base(position)
		{
			this.SetTexture("penguin");
			this.AddTag("penguin");

			this.InitializeAnimations();
		}

		public void InitializeAnimations()
		{
			this.EnableAnimator(6, 2);

			int[] penguinRunningFrames = { 1, 2, 3, 4, 5 };

			Animation penguinRunning = new Animation("penguin_running", penguinRunningFrames, 0.04);

			this.AddAnimation(penguinRunning);

			this.SetAnimation("penguin_running");
		}

		public override void Initialize()
		{
			base.Initialize();

			this.SetOriginPoint(new Vector2(0, 0));
		}

		public void Move(GameTime gameTime)
		{
			float dx = this.Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
			float dy = 0;

			this.Move((int)dx, (int)dy);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			Move(gameTime);
		}
	}
}
