using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingoSnake
{

	class Animation
	{
		public string Name;
		private int[] Frames;
		private double TimePerFrame;
		private bool Loop;
		public bool Locked;

		public bool Forced;

		private int CurrentFrame;

		private double TimePassed;

		public Animation(string name, int[] frames, double timePerFrame, bool loop=true, bool locked=false)
		{
			this.Name = name;
			this.Frames = frames;
			this.TimePerFrame= timePerFrame;
			this.Loop = loop;
			this.Locked = locked;

			this.Forced = false;
			this.CurrentFrame = 0;
			this.TimePassed = 0.0f;
		}
		
		public void Update(GameTime gameTime)
		{
			this.TimePassed += gameTime.ElapsedGameTime.TotalSeconds;

			if (this.TimePassed > this.TimePerFrame)
			{
				this.TimePassed = this.TimePassed % this.TimePerFrame;

				if (this.CurrentFrame < this.Frames.Length-1) {
					this.CurrentFrame += 1;
				} else if (this.Loop) {
					this.CurrentFrame = 0;
				}
			}
		}

		public int GetCurrentFrame()
		{
			return this.Frames[this.CurrentFrame];
		}

		public bool isFinished()
		{
			return this.CurrentFrame == this.Frames.Length - 1;
		}

		public void Reset()
		{
			this.CurrentFrame = 0;
			this.TimePassed = 0.0f;
			this.Forced = false;
		}
	}
}
