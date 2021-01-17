using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PingoSnake
{
	class EntityManager
	{
		//private List<Entity> Entities;
		private QuadTree EntitiesTree;
		private List<Entity> EntitiesToRemove;
		private List<Entity> EntitiesToAdd;

		private Scene Scene;

		private Camera Camera;

		private int InsertedNum;

		public IDictionary<int, List<Entity>> Collisions;

		public EntityManager(Scene scene)
		{
			this.Scene = scene;

			this.EntitiesToAdd = new List<Entity>();
			this.EntitiesToRemove = new List<Entity>();
			this.InsertedNum = 0;

			this.Collisions = new Dictionary<int, List<Entity>>();

			this.Camera = null;

			this.EntitiesTree = new QuadTree(scene.GetSceneBounds(), 40, visualize: true);
		}

		public void AddEntity(Entity entity)
		{
			this.EntitiesToAdd.Add(entity);
		}


		public void AddAllEntities()
		{
			List<Entity> toAdd = new List<Entity>(this.EntitiesToAdd);
			this.EntitiesToAdd = new List<Entity>();

			foreach (Entity entity in toAdd)
			{
				entity.SetId(this.InsertedNum);
				this.InsertedNum++;

				entity.SetEntityManager(this);

				this.EntitiesTree.AddEntity(entity);

				entity.LoadContent();

				entity.Initialize();
			}

			this.EntitiesTree.SortEntities();
			
		}

		public void RemoveEntity(Entity entity)
		{
			//this.EntitiesTree.RemoveEntity(entity);
			this.EntitiesToRemove.Add(entity);
		}

		public void RemoveAllEntities()
		{
			if (this.EntitiesToRemove.Count == 0)
				return;

			foreach (Entity entity in this.EntitiesToRemove)
			{
				this.EntitiesTree.RemoveEntity(entity);
			}

			this.EntitiesToRemove = new List<Entity>();
		}

		//public void Initialize(Rectangle sceneBounds)
		//{
		//}

		public void SetCamera(Camera camera)
		{
			this.Camera = camera;
		}

		public Camera GetCamera()
		{
			return this.Camera;
		}

		public Vector2 GetProjectedPosition(Vector2 position)
		{
			if (this.Camera != null)
				return this.Camera.GetPosition(position);

			return position;
		}

		public Scene GetScene()
		{
			return this.Scene;
		}

		public void LoadContent()
		{
			//this.Graphics = graphics;
			//this.Content = content;
			//this.EntitiesTree.PrepareLineEntities();

			//foreach (Entity entity in this.EntitiesTree.GetEntities())
			//{
			//	entity.LoadContent();
			//}
		}

		public void CheckCollisions()
		{
			foreach (Entity entity in this.EntitiesTree.GetEntities())
			{
				Rectangle entityRect = entity.GetRectangle();

				if (!this.Collisions.ContainsKey(entity.GetId())) {
					this.Collisions[entity.GetId()] = new List<Entity>();
				}

				if (entity.CheckCollisions)
				{
					foreach (QTreeNode node in entity.QTreeNodes)
					{
						foreach (Entity otherEntity in node.GetEntities())
						{
							if (entity.GetId() != otherEntity.GetId() && entityRect.Intersects(otherEntity.GetRectangle()))
							{
								if (!this.Collisions.ContainsKey(otherEntity.GetId()))
								{
									this.Collisions[otherEntity.GetId()] = new List<Entity>();
								}

								if (!this.Collisions[entity.GetId()].Contains(otherEntity))
									this.Collisions[entity.GetId()].Add(otherEntity);

								if (!this.Collisions[otherEntity.GetId()].Contains(entity))
									this.Collisions[otherEntity.GetId()].Add(entity);
							}
						}
					}
				}
			}
		}

		public void EmptyCollisions()
		{
			this.Collisions = new Dictionary<int, List<Entity>>();
		}

		public void Update(GameTime gameTime, bool paused=false)
		{
			this.EntitiesTree.Recalculate();

			this.EmptyCollisions();
			this.CheckCollisions();

			foreach (Entity entity in this.EntitiesTree.GetEntities())
			{
				if (!paused || !entity.IsPausable())
					entity.Update(gameTime);
			}

			// For entites that are dinamicly added, so that they dont lose one loop
			foreach (Entity entity in this.EntitiesToAdd)
			{
				if (!paused || !entity.IsPausable())
					entity.Update(gameTime);
			}

			this.RemoveAllEntities();
			this.AddAllEntities();

			//Trace.WriteLine($"Num of entities: {this.EntitiesTree.GetEntities().Count}");
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			//this.EntitiesTree.Draw(spriteBatch, this);

			foreach (Entity entity in this.EntitiesTree.GetEntities())
			{
				entity.Draw(spriteBatch);
			}
		}
	}
}
