using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Terrain;

public class Game1 : Game
{
    //Properties
    private GraphicsDeviceManager _graphics;
    private GraphicsDevice _device;
    private Effect _effect;
    private Camera _camera;
    private TriangleRenderer _triangleRenderer;
    private float _angle = 0f;

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
        Window.Title = "Riemer's MonoGame Tutorials -- 3D Series 1";

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        _device = _graphics.GraphicsDevice;
        _effect = Content.Load<Effect>("effects");

        // Initialize camera
        _camera = new Camera(_device);

        // Initialize triangle renderer
        _triangleRenderer = new TriangleRenderer(_device, _effect);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        _angle += 0.005f;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _device.Clear(Color.DarkSlateBlue);

        RasterizerState rs = new RasterizerState();
        rs.CullMode = CullMode.None;
        _device.RasterizerState = rs;

        Vector3 rotAxis = new Vector3(3*_angle, _angle, 2*_angle);
        rotAxis.Normalize();
        Matrix worldMatrix = Matrix.CreateTranslation(-20.0f / 3.0f, -10.0f / 3.0f, 0) * Matrix.CreateFromAxisAngle(rotAxis, _angle);
        // Render the triangle
        _triangleRenderer.Draw(_camera.ViewMatrix, _camera.ProjectionMatrix, worldMatrix);

        base.Draw(gameTime);
    }
}
