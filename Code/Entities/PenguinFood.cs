using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Entities
{
	
	/// <summary>
	/// An invisible entitiy spawned above Walrus or below Seagull for penguin score counting.
	/// </summary>
	class PenguinFood : Entity
	{
		public PenguinFood(Vector2 position) : base(position)
		{
			// SetTexture("food");
			AddTag("score");
		}

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

			Penguin penguin = GameState.Instance.GetVar<Penguin>("penguin");
			if (GetPosition().X < penguin.GetPosition().X - GameState.Instance.GetCurrentScene().GetWindowWidth() / 2)
			{
				Remove();
			}
		}
    }
}
