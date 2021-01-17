using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Engine
{
	class Spritefont : Entity
	{
		private List<Rectangle> CharactersBoxes;
		private string ReferenceString;
		private Dictionary<char, Rectangle> CharactersDictionary;

		
		public Spritefont(string texture_name) : base(new Vector2(0, 0))
		{
			CharactersBoxes = new List<Rectangle>();
			CharactersDictionary = new Dictionary<char, Rectangle>();

			SetTexture(texture_name);
			LoadContent();
			InitializeBoxes();
			ReferenceString = SetReferenceString();

			GenerateCharactersDictionary();
		}

		public virtual void InitializeBoxes()
		{

		}

		public virtual string SetReferenceString()
		{
			return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
		}

		public void AddCharacterBox(Rectangle characterBox)
		{
			CharactersBoxes.Add(characterBox);
		}

		public void GenerateCharactersDictionary()
		{
			for (int i = 0; i < ReferenceString.Length; i++)
			{
				char c = ReferenceString[i];
				Rectangle charBox = CharactersBoxes[i];

				CharactersDictionary.Add(c, charBox);
			}
		}

		public void DrawText(SpriteBatch spriteBatch, string text, int x, int y, int spacing=2)
		{
			DrawText(spriteBatch, text, x, y, Color.White, spacing);
		}

		public void DrawText(SpriteBatch spriteBatch, string text, int x, int y, Color color, int spacing = 2)
		{
			for (int i = 0; i < text.Length; i++)
			{
				Rectangle rect = CharactersDictionary[text[i]];
				spriteBatch.Draw(GetTexture(), new Rectangle(x, y, rect.Width, rect.Height), rect, color, 0, new Vector2(0, 0), SpriteEffects.None, 0);

				x += rect.Width + spacing;
			}
		}
	}
}
