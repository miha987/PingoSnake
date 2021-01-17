using Microsoft.Xna.Framework;
using PingoSnake.Code.Entities;
using PingoSnake.Code.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoSnake.Code.Scenes
{
	class MainMenu : Scene
	{
		public override void LoadTextures()
		{
			base.LoadTextures();

			this.AddTexture("ice_background_1", newName: "ice_background");
			this.AddTexture("ice_tile_platform_1", newName: "ice_platform");
			this.AddTexture("running_penguin_with_duck_1_cropped", newName: "penguin");
			this.AddTexture("good_neighbors_32", newName: "spritefont32");
			this.AddTexture("good_neighbors_64", newName: "spritefont64");
			this.AddTexture("good_neighbors_128", newName: "spritefont128");
			this.AddTexture("snake_v2", newName: "snake");
			this.AddTexture("snake_v3", newName: "snake3");
			this.AddTexture("snake_v4", newName: "snake4");
			this.AddTexture("snake_v5", newName: "snake5");
			this.AddTexture("snake_v6", newName: "snake6");
			this.AddTexture("snake_v7", newName: "snake7");
			this.AddTexture("food20", newName: "food");
		}

		public override void Initialize()
		{
			base.Initialize();

			int floor_pos_y = this.GetWindowHeight() - 128;

			IceBackground background = new IceBackground(new Vector2(0, -800));
			this.AddEntity(background);

			IcePlatform platform = new IcePlatform(new Vector2(0, floor_pos_y));
			this.AddEntity(platform);

			MenuPenguin penguin = new MenuPenguin(new Vector2(1000, floor_pos_y - 128));
			this.AddEntity(penguin);

			MainMenuGUI mainMenuGUI = new MainMenuGUI();
			AddEntity(mainMenuGUI);

			GameState.Instance.SetVar<int>("floor_pos_y", floor_pos_y);

			this.Camera.SetScreenOffset(0.49, 0.83);
			this.Camera.FollowOnlyXAxis();
			this.Camera.FollowEntity(penguin);
		}
	}
}
