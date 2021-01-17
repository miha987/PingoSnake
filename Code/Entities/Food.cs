using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Entities
{
	class Food : Entity
	{
		public Food(Vector2 position) : base(position)
		{
			SetTexture("food");
			SetCollidable(false);
			SetStatic(true);
			SetZ(53);
		}
	}
}
