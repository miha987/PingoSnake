using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Entities
{
	class LoadingSpinner : Entity
	{
		public LoadingSpinner(Vector2 position) : base(position)
		{
			SetTexture("loading");
			SetCollidable(false);
			SetStatic(true);

			EnableAnimator(4, 1);

			Animation spining = new Animation("spining", new int[] { 1, 2, 3, 4 }, 0.09);
			AddAnimation(spining);

			SetAnimation("spining");
		}
	}
}
