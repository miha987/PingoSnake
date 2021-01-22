using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
			string textureName = newName != null ? newName : name;
			
			if (Textures.ContainsKey(textureName))
			{
				Trace.WriteLine($"WARNING: Trying to load texture: {name}, when it is already loaded!");
				return;
			}

			Texture2D newTexture = GameState.Instance.GetContent().Load<Texture2D>(name);

			this.Textures.Add(textureName, newTexture);
		}

		public Texture2D GetTexture(string name)
		{
			return this.Textures[name];
		}
	}
}
