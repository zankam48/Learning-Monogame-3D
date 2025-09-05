using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;

namespace Terrain;
public class Camera
{
    public Matrix ViewMatrix { get; set; }
    public Matrix ProjectionMatrix { get; set; }
    private GraphicsDevice _device;

    public Camera(GraphicsDevice device)
    {
        _device = device;
    }

    public void SetUpCamera()
    {
        ViewMatrix = Matrix.CreateLookAt(new Vector3(0, 0, 50), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, _device.Viewport.AspectRatio, 1.0f, 300.0f);
    }
}