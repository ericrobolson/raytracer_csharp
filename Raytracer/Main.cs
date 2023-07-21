using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Raytracer;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D? _texture;
    private Image _image;
    private RaytracerEngine.Raytracer _raytracerEngine;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _raytracerEngine = new RaytracerEngine.Raytracer();
    }

    protected override void Initialize()
    {
        base.Initialize();

        var width = 800;
        var height = 600;

        _graphics.PreferredBackBufferWidth = width;
        _graphics.PreferredBackBufferHeight = height;

        _image = new Image(width, height);

        _raytracerEngine.Draw(_image);

        _texture = Texture2D.FromStream(GraphicsDevice, _image.GetImageStream());
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (
            GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape)
        )
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);

        if (_texture is not null)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(
                _texture,
                new Rectangle(0, 0, _image.Width, _image.Height),
                Microsoft.Xna.Framework.Color.White
            );
            _spriteBatch.End();
        }

        base.Draw(gameTime);
    }
}
