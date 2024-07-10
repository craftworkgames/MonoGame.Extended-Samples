﻿// Copyright (c) Craftwork Games. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Graphics;

namespace Texture2DRegionSample;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2DRegion _aceOfClubs;
    private Texture2DRegion _aceOfDiamonds;
    private Texture2DRegion _aceOfHearts;
    private Texture2DRegion _aceOfSpades;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 800;
        _graphics.PreferredBackBufferHeight = 600;
        _graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Texture2D cardsTexture = Content.Load<Texture2D>("cards");

        _aceOfClubs = new Texture2DRegion(cardsTexture, 384, 0, 32, 32);
        _aceOfDiamonds = new Texture2DRegion(cardsTexture, 384, 32, 32, 32);
        _aceOfHearts = new Texture2DRegion(cardsTexture, 384, 64, 32, 32);
        _aceOfSpades = new Texture2DRegion(cardsTexture, 384, 96, 32, 32);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        _spriteBatch.Draw(_aceOfClubs, new Vector2(336, 284), Color.White);
        _spriteBatch.Draw(_aceOfDiamonds, new Vector2(368, 284), Color.White);
        _spriteBatch.Draw(_aceOfHearts, new Vector2(400, 284), Color.White);
        _spriteBatch.Draw(_aceOfSpades, new Vector2(432, 284), Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
