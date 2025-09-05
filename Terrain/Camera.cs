using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terrain;

public class Camera
{
    public Matrix ViewMatrix { get; private set; }
    public Matrix ProjectionMatrix { get; set; }

    public Camera(GraphicsDevice device)
    {
        SetUpCamera(device);
    }

    private void SetUpCamera(GraphicsDevice device)
    {
        ViewMatrix = Matrix.CreateLookAt(new Vector3(0, 50, 0), new Vector3(0, 0, 0), new Vector3(0, 0, -1));
        ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, device.Viewport.AspectRatio, 1.0f, 300.0f);
    }
}
