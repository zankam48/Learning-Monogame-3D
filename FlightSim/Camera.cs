using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlightSim;

public class Camera
{
    public Matrix ViewMatrix { get; private set; }
    public Matrix ProjectionMatrix { get; private set; }

    public Camera(GraphicsDevice device)
    {
        SetUpCamera(device);
    }

    private void SetUpCamera(GraphicsDevice device)
    {
        ViewMatrix = Matrix.CreateLookAt(new Vector3(0, 0, 30), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, device.Viewport.AspectRatio, 0.2f, 500.0f);
    }
}
