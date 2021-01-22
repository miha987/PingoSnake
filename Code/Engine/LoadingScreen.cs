using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Engine
{
	class LoadingScreen
	{
		private Scene Scene;

		public LoadingScreen(Scene scene)
		{
			Scene = scene;
		}

		public void AddTexture(string name, string newName=null)
		{
			Scene.AddTexture(name, newName);
		}

		public virtual void LoadTextures()
		{

		}

		public virtual void Initialize()
		{

		}

		public virtual void Update(GameTime gameTime)
		{

		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.GraphicsDevice.Clear(Color.Cyan);
		}
	}
}
