using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingoSnake
{
	class Scene
	{
		private EntityManager EntityManager;
		private TextureManager TextureManager;
		private SpawnManager SpawnManager;

		private Rectangle SceneBounds;

		public Camera Camera;

		private bool Paused;

		public Scene()
		{
			this.SceneBounds = new Rectangle(0, 0, this.GetWindowWidth(), this.GetWindowHeight());
			this.TextureManager = new TextureManager();
			this.SpawnManager = new SpawnManager();
			this.EntityManager = new EntityManager(this);
			this.Camera = new Camera();

			this.Paused = false;

			this.Camera.Initialize(this.GetWindowWidth(), this.GetWindowHeight());

			this.EntityManager.SetCamera(this.Camera);

			this.LoadTextures();
		}

		public Scene(Rectangle sceneBounds)
		{
			this.SceneBounds = sceneBounds;

			if (this.SceneBounds.IsEmpty)
			{
				this.SceneBounds = new Rectangle(0, 0, this.GetWindowWidth(), this.GetWindowHeight());
			}

			this.TextureManager = new TextureManager();
			this.SpawnManager = new SpawnManager();
			this.EntityManager = new EntityManager(this);
			this.Camera = new Camera();

			this.Camera.Initialize(this.GetWindowWidth(), this.GetWindowHeight());
			
			this.EntityManager.SetCamera(this.Camera);

			this.LoadTextures();
		}

		public virtual void LoadTextures()
		{

		}

		public virtual void Initialize()
		{
		}

		public void LoadContent()
		{
			this.EntityManager.LoadContent();
		}

		public void AddEntity(Entity entity)
		{
			this.EntityManager.AddEntity(entity);
		}

		public void AddTexture(string name, string newName=null)
		{
			this.TextureManager.AddTexture(name, newName);
		}

		public void AddSpawnController(SpawnController spawnController)
		{
			this.SpawnManager.AddSpawnController(spawnController);
		}

		public void RemoveSpawnController(SpawnController spawnController)
		{
			this.SpawnManager.RemoveSpawnController(spawnController);
		}

		public Texture2D GetTexture(string name)
		{
			return this.TextureManager.GetTexture(name);
		}

		public int GetWindowWidth()
		{
			return GameState.Instance.GetGraphics().GraphicsDevice.Viewport.Width;
		}

		public int GetWindowHeight()
		{
			return GameState.Instance.GetGraphics().GraphicsDevice.Viewport.Height;
		}

		public Rectangle GetSceneBounds()
		{
			return this.SceneBounds;
		}

		public void Pause()
		{
			Paused = true;
		}

		public void Resume()
		{
			Paused = false;
		}

		public void TogglePause()
		{
			Paused = !Paused;
		}

		public bool IsPaused()
		{
			return Paused;
		}

		public virtual void Update(GameTime gameTime)
		{
			this.EntityManager.Update(gameTime, Paused);
			this.SpawnManager.Update(gameTime);

			this.Camera.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			this.EntityManager.Draw(spriteBatch);
		}
	}
}
