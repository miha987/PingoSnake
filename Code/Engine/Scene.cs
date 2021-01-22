using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PingoSnake.Code.Engine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake
{
	class Scene
	{
		private EntityManager EntityManager;
		private TextureManager TextureManager;
		private SoundManager SoundManager;
		private SpawnManager SpawnManager;

		private LoadingScreen SceneLoadingScreen;

		private Rectangle SceneBounds;

		public Camera Camera;

		private bool Paused;

		private bool SceneLoaded;

		public Scene()
		{
			SceneBounds = new Rectangle(0, 0, GetWindowWidth(), GetWindowHeight());
			TextureManager = new TextureManager();
			SoundManager = new SoundManager();
			SpawnManager = new SpawnManager();
			EntityManager = new EntityManager(this);
			Camera = new Camera();

			Paused = false;
			SceneLoaded = false;

			Camera.Initialize(GetWindowWidth(), GetWindowHeight());

			EntityManager.SetCamera(Camera);

			SceneLoadingScreen = GetLoadingScreen(this);
			SceneLoadingScreen.LoadTextures();

			Task.Run(() => LoadSceneContent());
		}

		public Scene(Rectangle sceneBounds)
		{
			SceneBounds = sceneBounds;

			if (SceneBounds.IsEmpty)
			{
				SceneBounds = new Rectangle(0, 0, GetWindowWidth(), GetWindowHeight());
			}

			TextureManager = new TextureManager();
			SoundManager = new SoundManager();
			SpawnManager = new SpawnManager();
			EntityManager = new EntityManager(this);
			Camera = new Camera();

			Paused = false;
			SceneLoaded = false;

			Camera.Initialize(GetWindowWidth(), GetWindowHeight());
			
			EntityManager.SetCamera(Camera);

			SceneLoadingScreen = GetLoadingScreen(this);
			SceneLoadingScreen.LoadTextures();

			Task.Run(() => LoadSceneContent());
		}

		public virtual LoadingScreen GetLoadingScreen(Scene scene)
		{
			return new LoadingScreen(scene);
		}

		async public Task LoadSceneContent()
		{
			LoadTextures();
			LoadSounds();
			Initialize();
			SceneLoaded = true;
		}

		public virtual void LoadTextures()
		{

		}

		public virtual void LoadSounds()
		{

		}

		public virtual void Initialize()
		{
		}

		public virtual void SceneCreated()
		{
			if (SceneLoadingScreen != null)
			{
				SceneLoadingScreen.Initialize();
			}
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

		public void AddSong(string name, string newName = null)
		{
			SoundManager.AddSong(name, newName);
		}

		public void AddSoundEffect(string name, string newName = null)
		{
			SoundManager.AddSoundEffect(name, newName);
		}

		public void PlaySong(string name, bool isRepeating = true)
		{
			SoundManager.PlaySong(name, isRepeating);
		}

		public void StopSong()
		{
			SoundManager.StopSong();
		}

		public void PlaySoundEffect(string name, bool isRepeating = false)
		{
			SoundManager.PlaySoundEffect(name, isRepeating);
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
			if (SceneLoaded)
			{
				this.EntityManager.Update(gameTime, Paused);
				this.SpawnManager.Update(gameTime);

				this.Camera.Update(gameTime);
			}
			else if (SceneLoadingScreen != null)
			{
				SceneLoadingScreen.Update(gameTime);
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			if (SceneLoaded)
			{
				this.EntityManager.Draw(spriteBatch);
			} else if (SceneLoadingScreen != null)
			{
				SceneLoadingScreen.Draw(spriteBatch);
			}
		}
	}
}
