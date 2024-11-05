﻿// Copyright (c) Craftwork Games. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Collisions;
using MonoGame.Extended;

namespace Collision
{
    public class CubeEntity : IEntity
    {
        public Vector2 Velocity;
        public IShapeF Bounds { get; }

        public CubeEntity(RectangleF rectangleF)
        {
            Bounds = rectangleF;
            RandomizeVelocity();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Red, 3);
        }

        public virtual void Update(GameTime gameTime)
        {
            Bounds.Position += Velocity * gameTime.GetElapsedSeconds() * 50;
        }

        public void OnCollision(CollisionEventArgs collisionInfo)
        {
            Velocity.X *= -1;
            Velocity.Y *= -1;
            Bounds.Position -= collisionInfo.PenetrationVector;
        }

        private void RandomizeVelocity()
        {
            Velocity.X = Random.Shared.Next(-1, 2);
            Velocity.Y = Random.Shared.Next(-1, 2);
        }
    }
}
