using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PingoSnake
{
	class Entity
	{
		private int Id;

		private Vector2 Position;
		private Texture2D Texture;

		private Vector2 OriginPoint;
		private float RotationAngle;

		private Color Color;
		public Color TintColor;

		private String TextureMode;
		private String TextureName;

		public List<QTreeNode> QTreeNodes;

		private EntityManager EntityManager;

		public List<String> Tags;

		public Animator Animator;

		// check possible collisions with this object
		public bool CheckCollisions;
		// dont add object to collisions quadtree
		public bool Collidable;
		public bool ForceSize;

		private bool Static;

		private int Width;
		private int Height;

		private int Z;

		private float Scale;

		private Rectangle BoundingRectangle;

		private bool Pausable;

		public Entity(Vector2 position)
		{
			this.Id = 0;
			this.Position = position;
			this.Width = 0;
			this.Height = 0;

			this.OriginPoint = new Vector2(0, 0);
			this.RotationAngle = 0;

			this.TextureMode = "rectangle";
			this.Color = Color.Black;
			this.TintColor = Color.White;

			this.QTreeNodes = new List<QTreeNode>();
			this.CheckCollisions = false;

			this.Tags = new List<string>();
			this.Collidable = true;
			this.ForceSize = false;

			this.Texture = null;

			this.Animator = new Animator(this.Texture);

			this.Z = 10;

			this.Scale = 1;

			this.Static = false;
			this.Pausable = true;

			this.BoundingRectangle = new Rectangle(0, 0, Width, Height);
		}

		public virtual void Initialize()
		{
			
		}

		public virtual void LoadContent()
		{
			switch (this.TextureMode)
			{
				case "rectangle":
					Texture = this.FillRectangleTexture(GameState.Instance.GetGraphics(), this.Width, this.Height, this.Color);

					if (Texture != null)
						OriginPoint = new Vector2(this.Texture.Width / 2, this.Texture.Height / 2);
					
					break;
				case "texture":
					//this.Texture = GameState.Instance.GetContent().Load<Texture2D>(this.TextureName);
					//this.Texture = GameState.Instance.GetCurrentScene().GetTexture(this.TextureName);
					this.Texture = GameState.Instance.GetCurrentScene().GetTexture(this.TextureName);

					if (!this.ForceSize)
					{
						this.Width = this.Texture.Width;
						this.Height = this.Texture.Height;
					}


					if (this.Animator.IsEnabled)
					{
						this.Animator.SetTexture(this.Texture);
						this.Width /= this.Animator.GetColumns();
						this.Height /= this.Animator.GetRows();
					}

					this.OriginPoint = new Vector2(this.Width / 2, this.Height / 2);

					break;
				default:
					break;
			}

			BoundingRectangle = new Rectangle(0, 0, Width, Height);
		}

		private Texture2D FillRectangleTexture(GraphicsDeviceManager graphics, int width, int height, Color color)
		{
			if (width <= 0 || height <= 0)
				return null;

			Texture2D texture = new Texture2D(graphics.GraphicsDevice, width, height);
			Color[] data = new Color[(int)(texture.Width * texture.Height)];

			for (int i = 0; i < data.Length; ++i) data[i] = color;

			texture.SetData(data);

			return texture;
		}

		public void EnableAnimator(int columns, int rows)
		{
			this.Animator.Enable(columns, rows);
		}

		public void AddAnimation(Animation animation)
		{
			this.Animator.AddAnimation(animation);
		}

		public void SetAnimation(string name, bool forceNext=false, bool forceNow=false)
		{
			this.Animator.SetAnimation(name, forceNext, forceNow);
		}

		public bool IsAnimationFinished()
		{
			return this.Animator.IsFinished();
		}

		public bool IsAnimationActive(string name)
		{
			return this.Animator.IsAnimationActive(name);
		}

		public void SetEntityManager(EntityManager entityManager)
		{
			this.EntityManager = entityManager;
		}

		public bool HasEntityManager()
		{
			return this.EntityManager != null;
		}

		public Camera GetCamera()
		{
			return this.EntityManager.GetCamera();
		}

		public void SetOriginPoint(Vector2 originPoint)
		{
			this.OriginPoint = originPoint;
		}

		public Vector2 GetOriginPoint()
		{
			return this.OriginPoint;
		}

		public void SetId(int id)
		{
			this.Id = id;
		}

		public int GetId()
		{
			return this.Id;
		}

		public void SetTexture(string name)
		{
			this.TextureName = name;
			this.TextureMode = "texture";
		}

		public Texture2D GetTexture()
		{
			return this.Texture;
		}

		public void SetPosition(Vector2 position)
		{
			this.Position = position;
		}

		public Vector2 GetPosition()
		{
			return this.Position;
		}

		public void SetSize(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}

		public int GetWidth()
		{
			return this.Width;
		}

		public int GetHeight()
		{
			return this.Height;
		}

		public void SetColor(Color color)
		{
			this.Color = color;
		}

		public Color GetColor()
		{
			return this.Color;
		}

		public void SetZ(int z)
		{
			this.Z = z;
		}

		public int GetZ()
		{
			return this.Z;
		}

		public void SetScale(int scale)
		{
			this.Scale = scale;
		}

		public float GetScale()
		{
			return this.Scale;
		}

		public void SetStatic(bool isStatic)
		{
			this.Static = isStatic;
		}

		public bool GetStatic()
		{
			return this.Static;
		}

		public void SetPausable(bool pausable)
		{
			Pausable = pausable;
		}

		public bool IsPausable()
		{
			return Pausable;
		}

		public void SetBoundingRectangle(Rectangle rectangle)
		{
			BoundingRectangle = rectangle;
		}
		public Rectangle GetBoundingRectangle()
		{
			return BoundingRectangle;
		}

		public void SetRotationAngle(float angle)
		{
			this.RotationAngle = angle;
		}

		public float GetRotationAngle()
		{
			return this.RotationAngle;
		}

		public void Rotate(float deltaAngle)
		{
			this.RotationAngle += deltaAngle;
		}

		public Rectangle GetRectangle()
		{
			return new Rectangle((int)(this.Position.X - this.OriginPoint.X + BoundingRectangle.X), (int)(this.Position.Y - this.OriginPoint.Y + BoundingRectangle.Y), BoundingRectangle.Width, BoundingRectangle.Height);
		}

		public Rectangle GetRectangle(Vector2 position)
		{
			return new Rectangle((int)(position.X - this.OriginPoint.X + BoundingRectangle.X), (int)(position.Y - this.OriginPoint.Y + BoundingRectangle.Y), BoundingRectangle.Width, BoundingRectangle.Height);
		}

		public Vector2 GetProjectedPosition()
		{
			if (this.EntityManager == null || this.Static)
				return this.Position;

			return this.EntityManager.GetProjectedPosition(this.Position);
		}

		public List<Entity> GetMyCollisions()
		{
			if (this.EntityManager == null)
				return new List<Entity>();

			if (!this.EntityManager.Collisions.ContainsKey(this.Id))
				return new List<Entity>();

			return this.EntityManager.Collisions[this.Id];
		}

		public List<Entity> GetMyCollisionsWithTag(string tag)
		{
			if (this.EntityManager == null)
				return new List<Entity>();

			if (!this.EntityManager.Collisions.ContainsKey(this.Id))
				return new List<Entity>();

			return this.EntityManager.Collisions[this.Id].FindAll(e => e.HasTag(tag));
		}

		public Scene GetScene()
		{
			if (this.EntityManager == null)
				return null;
			return this.EntityManager.GetScene();
		}

		public void SetCheckCollisions(bool checkCollisions)
		{
			this.CheckCollisions = checkCollisions;
		}

		public void SetCollidable(bool collidable)
		{
			this.Collidable = collidable;
		}

		public void AddTag(string tag)
		{
			this.Tags.Add(tag);
		}

		public void RemoveTag(string tag)
		{
			this.Tags.Remove(tag);
		}

		public bool HasTag(string tag)
		{
			return this.Tags.Contains(tag);
		}

		public void EmptyQTreeNodes()
		{
			this.QTreeNodes = new List<QTreeNode>();
		}

		public void Remove()
		{
			if (this.EntityManager != null)
				this.EntityManager.RemoveEntity(this);
		}

		public void Move(int dX, int dY)
		{
			this.Position.X += dX;
			this.Position.Y += dY;
		}

		public void Move(float dX, float dY)
		{
			this.Position.X += dX;
			this.Position.Y += dY;
		}

		public bool IsOnScreen(Vector2 position)
		{
			if (this.EntityManager == null)
				return true;

			Rectangle bounds = new Rectangle(0, 0, this.EntityManager.GetScene().GetWindowWidth(), this.EntityManager.GetScene().GetWindowHeight());

			return bounds.Intersects(this.GetRectangle(position));
		}

		public virtual void Update(GameTime gameTime)
		{
			this.Animator.Update(gameTime);
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			if (Texture == null)
				return;

			Vector2 projectedPosition = this.GetProjectedPosition();

			//if (this.EntityManager != null)
			//	projectedPosition = this.EntityManager.GetProjectedPosition(this.Position);

			if (!this.IsOnScreen(projectedPosition))
				return;

			Rectangle dstRect = new Rectangle((int)projectedPosition.X, (int)projectedPosition.Y, this.Width, this.Height);
			//spriteBatch.Draw(this.Texture, this.Position, this.TintColor);

			if (this.Animator.IsEnabled)
				this.Animator.Draw(spriteBatch, dstRect, this.TintColor, this.RotationAngle, this.OriginPoint, this.Scale);
			else
				spriteBatch.Draw(this.Texture, new Vector2(projectedPosition.X, projectedPosition.Y), null, this.TintColor, this.RotationAngle, this.OriginPoint, this.Scale, SpriteEffects.None, 0);
				//spriteBatch.Draw(this.Texture, dstRect, null, this.TintColor, this.RotationAngle, this.OriginPoint, 2.0f, SpriteEffects.None, 0);
			//spriteBatch.Draw(this.Texture, new Rectangle((int)projectedPosition.X, (int)projectedPosition.Y, this.Width, this.Height), this.TintColor);
		}
	}
}
