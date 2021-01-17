using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingoSnake
{
	class TextureManager
	{
		private IDictionary<string, Texture2D> Textures;

		public TextureManager()
		{
			this.Textures = new Dictionary<string, Texture2D>();
		}

		public void AddTexture(string name, string newName = null)
		{
			Texture2D newTexture = GameState.Instance.GetContent().Load<Texture2D>(name);

			name = newName != null ? newName : name;

			this.Textures.Add(name, newTexture);
		}

		public Texture2D GetTexture(string name)
		{
			return this.Textures[name];
		}
	}
}
