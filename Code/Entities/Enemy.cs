using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingoSnake.Code.Entities
{
	class Enemy : Entity
	{
		public Enemy(Vector2 position) : base(position)
		{
			AddTag("enemy");
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			Penguin penguin = GameState.Instance.GetVar<Penguin>("penguin");
			if (GetPosition().X  < penguin.GetPosition().X - GameState.Instance.GetCurrentScene().GetWindowWidth()/2)
			{
				Remove();
			}
		}
	}
}
