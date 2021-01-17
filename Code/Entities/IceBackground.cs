using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingoSnake.Code.Entities
{
	class IceBackground : Entity
	{
		private float Speed = 0.16f;

		public IceBackground(Vector2 position) : base(position)
		{
			this.SetTexture("ice_background");
			this.SetZ(0);
			this.SetCollidable(false);
			this.SetStatic(true);
		}

		public override void Initialize()
		{
			base.Initialize();

			this.SetOriginPoint(new Vector2(0, 0));
		}

		public void Move(GameTime gameTime)
		{
			float dx = this.Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			this.Move((int)-dx, 0);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			this.Move(gameTime);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			Vector2 projectedPosition = this.GetPosition();

			int offsetX = (int)Math.Abs(projectedPosition.X) % this.GetWidth();

			for (int i = 0; i < 2; i++)
			{
				int x = i * this.GetWidth();
				spriteBatch.Draw(this.GetTexture(), new Vector2(x - offsetX, projectedPosition.Y), null, this.TintColor);
			}

		}
	}
}
