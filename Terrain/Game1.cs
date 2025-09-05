using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
// using Mono

namespace Terrain;

public class Game1 : Core
{
    // private Camera _camera;
    private Matrix _viewMatrix;
    private Matrix _projectionMatrix;
    private VertexPositionColor[] _vertices;
    public Game1() : base("Terrain", 800, 600, false)
    {
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        // _camera = new Camera(GraphicsDevice);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        base.LoadContent();
        Effect = Content.Load<Effect>("effects");
        SetUpCamera();
        SetUpVertices();
        // _camera.SetUpCamera();

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
        GraphicsDevice.Clear(Color.Crimson);

        RasterizerState rasterizerState = new RasterizerState();
        rasterizerState.CullMode = CullMode.None;
        GraphicsDevice.RasterizerState = rasterizerState;

        // TODO: Add your drawing code here
        Effect.CurrentTechnique = Effect.Techniques["ColoredNoShading"];

        Effect.Parameters["xView"].SetValue(_viewMatrix);
        Effect.Parameters["xProjection"].SetValue(_projectionMatrix);
        Effect.Parameters["xWorld"].SetValue(Matrix.Identity);

        foreach (EffectPass pass in Effect.CurrentTechnique.Passes)
        {
            pass.Apply();
            GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, _vertices, 0, 1, VertexPositionColor.VertexDeclaration);
        }

        base.Draw(gameTime);
    }

    private void SetUpCamera()
    {
        _viewMatrix = Matrix.CreateLookAt(new Vector3(0, 0, 50), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        _projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, GraphicsDevice.Viewport.AspectRatio, 1.0f, 300.0f);
    }
    
    private void SetUpVertices()
    {
        _vertices = new VertexPositionColor[3];

        _vertices[0].Position = new Vector3(0f, 0f, 0f);
        _vertices[0].Color = Color.Red;
        _vertices[1].Position = new Vector3(10f, 10f, 0f);
        _vertices[1].Color = Color.Yellow;
        _vertices[2].Position = new Vector3(10f, 0f, -5f);
        _vertices[2].Color = Color.Green;
    }
}
