using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingoSnake
{
	class QuadTree
	{
		private Rectangle Bounds;
		private QTreeNode Root;
		private int MaxEntitiesPerNode;

		private List<Entity> Entities;
		private List<Entity> LineEntities;

		private Boolean Visualize;

		public QuadTree(Rectangle bounds, int max_entities_per_node, Boolean visualize=false)
		{
			this.Bounds = bounds;
			this.Root = new QTreeNode(this.Bounds, null);
			this.MaxEntitiesPerNode = max_entities_per_node;
			this.Entities = new List<Entity>();
			this.LineEntities = new List<Entity>();
			this.Visualize = visualize;
		}

		public List<Entity> GetEntities()
		{
			return this.Entities;
		}

		public void AddEntity(Entity entity)
		{
			this.Entities.Add(entity);
			//this.AddEntity(entity, this.Root);
		}

		public void RemoveEntity(Entity entity)
		{
			this.Entities.Remove(entity);
		}

		public void AddEntity(Entity entity, QTreeNode node)
		{
			if (!entity.Collidable)
				return;

			Vector2 entityPosition = entity.GetProjectedPosition();

			if (!entity.GetRectangle(entityPosition).Intersects(node.GetRectangle()))
				return;

			if (node.GetNumberOfChildren() == 0) {
				if (node.GetNumberOfEntities() < this.MaxEntitiesPerNode) {
					node.AddEntity(entity);
				} else {
					node.Divide();

					foreach (Entity childEntity in node.GetEntities())
					{
						childEntity.EmptyQTreeNodes();

						foreach (QTreeNode childNode in node.GetChildren())
						{
							this.AddEntity(childEntity, childNode);
						}
					}

					node.EmptyEntities();

					foreach (QTreeNode childNode in node.GetChildren())
					{
						this.AddEntity(entity, childNode);
					}
				}
			} else {
				foreach (QTreeNode childNode in node.GetChildren())
				{
					this.AddEntity(entity, childNode);
				}
			}
		}

		public void Recalculate()
		{
			this.Root = new QTreeNode(this.Bounds, null);
			this.LineEntities = new List<Entity>();

			foreach (Entity entity in this.Entities)
			{
				entity.QTreeNodes = new List<QTreeNode>();
				this.AddEntity(entity, this.Root);
			}

			//this.PrepareLineEntities();
		}

		public void SortEntities()
		{
			this.Entities.Sort((x, y) => x.GetZ().CompareTo(y.GetZ()));
		}

		public void Draw(SpriteBatch spriteBatch, EntityManager entityManager)
		{
			//this.Draw(spriteBatch, this.Graphics, this.Content, this.Root);

			foreach (Entity entity in this.LineEntities)
			{
				entity.SetEntityManager(entityManager);
				entity.Draw(spriteBatch);
			}
		}

		public void PrepareLineEntities()
		{
			this.PrepareLineEntities(this.Root);
		}

		public void PrepareLineEntities(QTreeNode node)
		{
			this.GetLineEntities(node.GetRectangle());

			if (node.GetNumberOfChildren() > 0)
			{
				foreach (QTreeNode nodeChild in node.GetChildren())
				{
					this.PrepareLineEntities(nodeChild);
				}
			}
		}

		//public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, ContentManager content, QTreeNode node)
		//{
		//	this.DrawRect(spriteBatch, graphics, content, node.GetRectangle());

		//	if (node.GetNumberOfChildren() > 0)
		//	{
		//		foreach (QTreeNode nodeChild in node.GetChildren())
		//		{
		//			this.Draw(spriteBatch, graphics, content, nodeChild);
		//		}
		//	}
		//}

		public void GetLineEntities(Rectangle rect)
		{
			int thickness = 5;
			//Entity line1 = new Entity(new Vector2(rect.Left, rect.Top), rect.Width, thickness, Color.White);
			//Entity line2 = new Entity(new Vector2(rect.Left, rect.Top), thickness, rect.Height, Color.White);
			//Entity line3 = new Entity(new Vector2(rect.Right - thickness, rect.Top), thickness, rect.Height, Color.White);
			//Entity line4 = new Entity(new Vector2(rect.Left, rect.Bottom - thickness), rect.Width, thickness, Color.White);

			Entity line1 = new Entity(new Vector2(rect.Left, rect.Top));
			Entity line2 = new Entity(new Vector2(rect.Left, rect.Top));
			Entity line3 = new Entity(new Vector2(rect.Right - thickness, rect.Top));
			Entity line4 = new Entity(new Vector2(rect.Left, rect.Bottom - thickness));

			line1.SetTexture("white");
			line2.SetTexture("white");
			line3.SetTexture("white");
			line4.SetTexture("white");

			line1.LoadContent();
			line2.LoadContent();
			line3.LoadContent();
			line4.LoadContent();

			line1.SetSize(rect.Width, thickness);
			line2.SetSize(thickness, rect.Height);
			line3.SetSize(thickness, rect.Height);
			line4.SetSize(rect.Width, thickness);

			this.LineEntities.Add(line1);
			this.LineEntities.Add(line2);
			this.LineEntities.Add(line3);
			this.LineEntities.Add(line4);
		}
	}

	class QTreeNode
	{
		private Rectangle Bounds;
		private List<Entity> Entities;
		private List<QTreeNode> Children;
		private QTreeNode Parent;

		public QTreeNode(Rectangle bounds, QTreeNode parent)
		{
			this.Bounds = bounds;
			this.Entities = new List<Entity>();
			this.Children = new List<QTreeNode>();
			this.Parent = parent;
		}

		public Rectangle GetRectangle()
		{
			return this.Bounds;
		}

		public int GetNumberOfChildren()
		{
			return this.Children.Count;
		}

		public int GetNumberOfEntities()
		{
			return this.Entities.Count;
		}

		public List<QTreeNode> GetChildren()
		{
			return this.Children;
		}

		public List<Entity> GetEntities()
		{
			return this.Entities;
		}

		public void EmptyEntities()
		{
			this.Entities = new List<Entity>();
		}

		public void AddEntity(Entity entity)
		{
			if (!this.Entities.Contains(entity))
			{
				entity.QTreeNodes.Add(this);
				this.Entities.Add(entity);
			}
		}

		public void Divide()
		{
			Rectangle newBounds1 = new Rectangle(this.Bounds.Left, this.Bounds.Top, this.Bounds.Width / 2, this.Bounds.Height / 2);
			Rectangle newBounds2 = new Rectangle(this.Bounds.Left + this.Bounds.Width / 2, this.Bounds.Top, this.Bounds.Width / 2, this.Bounds.Height / 2);
			Rectangle newBounds3 = new Rectangle(this.Bounds.Left, this.Bounds.Top + this.Bounds.Height/ 2, this.Bounds.Width / 2, this.Bounds.Height / 2);
			Rectangle newBounds4 = new Rectangle(this.Bounds.Left + this.Bounds.Width / 2, this.Bounds.Top + this.Bounds.Height/ 2, this.Bounds.Width / 2, this.Bounds.Height / 2);

			this.Children.Add(new QTreeNode(newBounds1, this));
			this.Children.Add(new QTreeNode(newBounds2, this));
			this.Children.Add(new QTreeNode(newBounds3, this));
			this.Children.Add(new QTreeNode(newBounds4, this));
		}
	}
}
