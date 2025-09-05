using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terrain;

public class TriangleRenderer
{
    private GraphicsDevice _device;
    private Effect _effect;
    private VertexPositionColor[] _vertices;

    public TriangleRenderer(GraphicsDevice device, Effect effect)
    {
        _device = device;
        _effect = effect;
        SetUpVertices();
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

    public void Draw(Matrix viewMatrix, Matrix projectionMatrix)
    {
        _effect.CurrentTechnique = _effect.Techniques["ColoredNoShading"];
        _effect.Parameters["xView"].SetValue(viewMatrix);
        _effect.Parameters["xProjection"].SetValue(projectionMatrix);
        _effect.Parameters["xWorld"].SetValue(Matrix.Identity);

        foreach (EffectPass pass in _effect.CurrentTechnique.Passes)
        {
            pass.Apply();
            _device.DrawUserPrimitives(PrimitiveType.TriangleList, _vertices, 0, 1, VertexPositionColor.VertexDeclaration);
        }
    }
}
