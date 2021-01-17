using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingoSnake.Code.Entities
{
	class IcePlatform : Entity
	{
		public IcePlatform(Vector2 position) : base(position)
		{
			this.SetTexture("ice_platform");
			
		}

		public override void Initialize()
		{
			base.Initialize();

			this.SetOriginPoint(new Vector2(0, 0));
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
			Camera camera = this.GetCamera();

			int offsetX = camera.X % this.GetWidth();

			Vector2 projectedPosition = this.GetProjectedPosition();

			for (int i = 0; i < 3; i++)
			{
				int x = i * this.GetWidth();
				spriteBatch.Draw(this.GetTexture(), new Vector2(x - offsetX, projectedPosition.Y), null, this.TintColor);
			}

		}
	}
}
