using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlightSim;

public class Game1 : Game
{
    //Properties
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GraphicsDevice _device;
    private Effect _effect;
    private Camera _camera;
    private Vertices _vertices;
    private Texture2D _texture;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferWidth = 500;
        _graphics.PreferredBackBufferHeight = 500;
        _graphics.IsFullScreen = false;
        _graphics.ApplyChanges();
        Window.Title = "Riemer's MonoGame Tutorials -- 3D Series 2";

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _device = _graphics.GraphicsDevice;
        _effect = Content.Load<Effect>("effects");
        _texture = Content.Load<Texture2D>("riemerstexture");

        // Initialize camera
        _camera = new Camera(_device);
        _vertices = new Vertices(_device, _effect);
        
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _device.Clear(Color.DarkSlateBlue);

        // TODO: Add your drawing code here
        Matrix worldMatrix = Matrix.Identity;
        _vertices.Draw(_camera.ViewMatrix, _camera.ProjectionMatrix, worldMatrix, _texture);

        base.Draw(gameTime);
    }
}
