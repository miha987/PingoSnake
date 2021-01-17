using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Entities
{
	class Seagull : Enemy
	{
		public Seagull(Vector2 position) : base(position)
		{
			SetTexture("seagull");
			SetZ(10);
		}

		public override void Initialize()
		{
			base.Initialize();

			SetOriginPoint(new Vector2(0, 0));
			SetBoundingRectangle(new Rectangle(8, 16, GetWidth()-8, GetHeight() - 16));
		}
	}
}
