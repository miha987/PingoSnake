using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PingoSnake.Code.Scenes;

namespace PingoSnake
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            GameState.Instance.SetGameReference(this);

            GameState.Instance.SetGraphics(this._graphics);
            GameState.Instance.SetContent(this.Content);

            GameState.Instance.SetScene(new MainMenu());

            this.IsFixedTimeStep = true;
            this._graphics.SynchronizeWithVerticalRetrace = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            if (GameState.Instance.GetCurrentScene() != null)
            {
                GameState.Instance.GetCurrentScene().LoadContent();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            if (GameState.Instance.GetCurrentScene() != null)
            {
                GameState.Instance.GetCurrentScene().Update(gameTime);
            }

            GameState.Instance.UpdatePrevKeyboardState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            if (GameState.Instance.GetCurrentScene() != null)
            {
                GameState.Instance.GetCurrentScene().Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
