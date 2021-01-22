using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingoSnake
{
	sealed class GameState
	{
		private Game GameReference;
		private Scene CurrentScene;
		private GraphicsDeviceManager Graphics;
		private ContentManager Content;

		private IDictionary<String, StateVariable<Object>> StateVariables;

		private KeyboardState KeyboardState;
		private KeyboardState PrevKeyboardState;

		private static GameState instance = null;
		private static readonly object padlock = new object();

		public GameState()
		{
			this.StateVariables = new Dictionary<String, StateVariable<object>>();

			this.KeyboardState = Keyboard.GetState();
			this.PrevKeyboardState = new KeyboardState();
		}

		public static GameState Instance
		{
			get
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new GameState();
					}
					return instance;
				}
			}
		}

		public void SetScene(Scene scene)
		{
			CurrentScene = scene;
			CurrentScene.SceneCreated();
			//this.CurrentScene.Initialize();
		}

		public Scene GetCurrentScene()
		{
			return this.CurrentScene;
		}

		public void SetVar<T>(String name, T value)
		{
			StateVariable<object> var = new StateVariable<object>(name, value);
			this.StateVariables[name] = (StateVariable<object>)var;
		}

		public T GetVar<T>(String name)
		{
			return (T)this.StateVariables[name].value;
		}

		public void SetGraphics(GraphicsDeviceManager graphics)
		{
			this.Graphics = graphics;
		}

		public GraphicsDeviceManager GetGraphics()
		{
			return this.Graphics;
		}

		public void SetContent(ContentManager content)
		{
			this.Content = content;
		}

		public ContentManager GetContent()
		{
			return this.Content;
		}

		public void SetGameReference(Game game)
		{
			GameReference = game;
		}

		public Game GetGameReference()
		{
			return this.GameReference;
		}

		public void UpdatePrevKeyboardState()
		{
			//this.KeyboardState = Keyboard.GetState();
			this.PrevKeyboardState = Keyboard.GetState();
		}

		public KeyboardState GetPrevKeyboardState()
		{
			return this.PrevKeyboardState;
		}

	}

	class StateVariable<T>
	{
		private T Value;
		private String Name;

		public StateVariable(String name, T value)
		{
			this.Name = name;
			this.value = value;
		}

		public T value
		{
			get
			{
				return this.Value;
			}

			set
			{
				this.Value = value;
			}
		}
	}
}
