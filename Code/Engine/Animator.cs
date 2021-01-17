using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingoSnake
{
	class Animator
	{
		private Texture2D Texture;

		private int Columns;
		private int Rows;

		private IDictionary<string, Animation> Animations = new Dictionary<string, Animation>();
		private Animation CurrentAnimation;
		private Animation NextAnimation;

		public bool IsEnabled;

		public Animator(Texture2D texture)
		{
			this.Texture = texture;
			this.IsEnabled = false;

			this.CurrentAnimation = null;
			this.NextAnimation = null;
		}

		public void Enable(int columns, int rows)
		{
			this.Columns = columns;
			this.Rows = rows;
		
			this.IsEnabled = true;
		}

		public void SetTexture(Texture2D texture)
		{
			this.Texture = texture;
		}

		public void AddAnimation(Animation animation)
		{
			if (this.Animations.ContainsKey(animation.Name))
				throw new AnimationAlreadyExistsException(animation.Name);

			this.Animations[animation.Name] = animation;
		}

		public void SetAnimation(string name, bool forceNext=false, bool forceNow=false)
		{
			if (forceNow)
			{
				if (this.CurrentAnimation != null)
					this.CurrentAnimation.Reset();

				this.NextAnimation = null;

				this.CurrentAnimation = this.Animations[name];
			}
			else if (this.CurrentAnimation == null || !this.CurrentAnimation.Locked || (this.CurrentAnimation.Locked && this.CurrentAnimation.isFinished()) || (this.CurrentAnimation.Locked && this.CurrentAnimation.isFinished()))
			{
				if (this.CurrentAnimation != null)
					this.CurrentAnimation.Reset();

				this.CurrentAnimation = this.Animations[name];
			} else 
			{
				if (this.NextAnimation == null || !this.NextAnimation.Forced)
				{
					this.NextAnimation = this.Animations[name];
					this.NextAnimation.Forced = forceNext;
				}
			}
		}

		public int GetColumns()
		{
			return this.Columns;
		}

		public int GetRows()
		{
			return this.Rows;
		}

		public bool IsFinished()
		{
			return this.CurrentAnimation.isFinished();
		}

		public bool IsAnimationActive(string name)
		{
			if (this.CurrentAnimation == null)
				return false;

			return this.CurrentAnimation.Name == name;
		}

		public void Update(GameTime gameTime)
		{
			if (!this.IsEnabled || this.CurrentAnimation == null)
				return;
			
			this.CurrentAnimation.Update(gameTime);

			if (this.NextAnimation != null && this.CurrentAnimation.isFinished())
			{
				this.CurrentAnimation.Reset();
				this.CurrentAnimation = this.NextAnimation;
				this.NextAnimation = null;
			}
		}

		public void Draw(SpriteBatch spriteBatch, Rectangle dstRect, Color tintColor, float rotationAngle, Vector2 rotationOriginPoint, float scale)
		{
			if (!this.IsEnabled || this.CurrentAnimation == null)
				return;

			int currentFrame = this.CurrentAnimation.GetCurrentFrame();

			int SpriteWidth = this.Texture.Width / this.Columns;
			int SpriteHeight = this.Texture.Height / this.Rows;

			int spriteX = ((currentFrame - 1) % this.Columns) * SpriteWidth;
			int spriteY = ((currentFrame - 1) / this.Columns) * SpriteHeight;

			Rectangle sourceRect = new Rectangle(spriteX, spriteY, SpriteWidth, SpriteHeight);

			spriteBatch.Draw(this.Texture, dstRect, sourceRect, tintColor, rotationAngle, rotationOriginPoint, SpriteEffects.None, 0);
			//spriteBatch.Draw(this.Texture, new Vector2(spriteX, spriteY), sourceRect, tintColor, rotationAngle, rotationOriginPoint, scale, SpriteEffects.None, 0);
		}
	}

	class AnimationAlreadyExistsException : Exception
	{
		public AnimationAlreadyExistsException() : base("Animation with this name already exists in this Animator")
		{ }

		public AnimationAlreadyExistsException(string animationName) : base($"Animation with name {animationName} already exists in this Animator")
		{ }
	}
}
