using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Entities
{
	class SnakeBackground : Entity
	{
		public SnakeBackground(Vector2 position) : base(position)
		{
			//SetSize(width, height);
			//SetColor(new Color(172, 113, 66));
			SetTexture("dirt_background");
			SetZ(50);
			SetCollidable(false);
			SetStatic(true);
		}

		public override void Initialize()
		{
			base.Initialize();

			this.SetOriginPoint(new Vector2(0, 0));
		}
	}
}
