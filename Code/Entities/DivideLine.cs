using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Entities
{
	class DivideLine : Entity
	{
		public DivideLine(Vector2 position) : base(position)
		{
			SetTexture("divide_line");
			SetCollidable(false);
			SetStatic(true);
			SetZ(60);
		}

		public override void Initialize()
		{
			base.Initialize();

			SetOriginPoint(new Vector2(0, 0));
		}
	}
}
