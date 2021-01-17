using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingoSnake.Code.Entities
{
	class Walrus : Enemy
	{
		public Walrus(Vector2 position) : base(position)
		{
			this.SetTexture("walrus");
			this.SetZ(10);
		}

		public override void Initialize()
		{
			base.Initialize();

			this.SetOriginPoint(new Vector2(0, 0));
		}
	}
}
