using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingoSnake
{
	class Camera
	{
		public int X;
		public int Y;
		private int Width;
		private int Height;

		private double ScreenOffsetX;
		private double ScreenOffsetY;

		private Entity FollowingEntity;

		private Rectangle MoveZone;

		private string FollowMode;

		private bool FollowXAxis;
		private bool FollowYAxis;

		public Camera()
		{
			this.X = 0;
			this.Y = 0;

			this.Width = 0;
			this.Height = 0;

			this.ScreenOffsetX = 0.5;
			this.ScreenOffsetY = 0.5;

			this.FollowingEntity = null;

			this.FollowMode = "center";

			this.FollowXAxis = true;
			this.FollowYAxis = true;
		}

		public void Initialize(int width, int height)
		{
			this.Width = width;
			this.Height = height;

			this.MoveZone = new Rectangle((int)(this.Width * 0.4), (int)(this.Height * 0.4), (int)(this.Width * 0.2), (int)(this.Height * 0.2));
		}

		public void FollowEntity(Entity entity)
		{
			this.FollowingEntity = entity;

			this.X = ((int)this.FollowingEntity.GetPosition().X) - (int)((this.Width * this.ScreenOffsetX) - (this.FollowingEntity.GetWidth() / 2) + (int)this.FollowingEntity.GetOriginPoint().X);
			this.Y = ((int)this.FollowingEntity.GetPosition().Y) - (int)((this.Height * this.ScreenOffsetY) - (this.FollowingEntity.GetHeight() / 2) + (int)this.FollowingEntity.GetOriginPoint().Y);
		}

		public bool IsFollowing(Entity entity)
		{
			return this.FollowingEntity == entity;
		}

		public void FollowOnlyXAxis()
		{
			this.FollowXAxis = true;
			this.FollowYAxis = false;
		}

		public void FollowOnlyYAxis()
		{
			this.FollowYAxis = true;
			this.FollowXAxis = false;
		}

		public void Update(GameTime gameTime)
		{
			if (this.FollowMode == "center")
			{
				if (this.FollowingEntity != null)
				{
					this.X = ((int)this.FollowingEntity.GetPosition().X) - (int)((this.Width * this.ScreenOffsetX) - (this.FollowingEntity.GetWidth()/2) + (int)this.FollowingEntity.GetOriginPoint().X);
					this.Y = ((int)this.FollowingEntity.GetPosition().Y) - (int)((this.Height * this.ScreenOffsetY) - (this.FollowingEntity.GetHeight()/2) + (int)this.FollowingEntity.GetOriginPoint().Y);
				} else
				{
					this.X = 0;
					this.Y = 0;
				}
			}

			if (this.FollowMode == "zone")
			{
				Rectangle followRect = this.FollowingEntity.GetRectangle(this.FollowingEntity.GetProjectedPosition());

				if (followRect.Top < this.MoveZone.Top)
				{
					this.Y -= this.MoveZone.Top - followRect.Top;
				}

				if (followRect.Bottom > this.MoveZone.Bottom)
				{
					this.Y += followRect.Bottom - this.MoveZone.Bottom;
				}

				if (followRect.Left < this.MoveZone.Left)
				{
					this.X -= this.MoveZone.Left - followRect.Left;
				}

				if (followRect.Right > this.MoveZone.Right)
				{
					this.X += followRect.Right - this.MoveZone.Right;
				}
			}
		}

		public float GetX(float x)
		{
			if (this.FollowXAxis)
			{
				return x - this.X;
			}

			return x;
		}

		public float GetY(float y)
		{
			if (this.FollowYAxis)
			{
				return y - this.Y;
			}

			return y;
		}

		public Vector2 GetPosition(Vector2 position)
		{
			return new Vector2(this.GetX(position.X), this.GetY(position.Y));
		}

		public void SetScreenOffset(double offsetX, double offsetY)
		{
			this.ScreenOffsetX = offsetX;
			this.ScreenOffsetY = offsetY;
		}
	}
}
