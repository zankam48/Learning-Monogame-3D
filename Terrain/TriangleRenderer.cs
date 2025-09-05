using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terrain;

public class TriangleRenderer
{
    private GraphicsDevice _device;
    private Effect _effect;
    private VertexPositionColor[] _vertices;
    private int[] _indices;

    public TriangleRenderer(GraphicsDevice device, Effect effect)
    {
        _device = device;
        _effect = effect;
        SetUpVertices();
        SetUpIndices();
    }

    private void SetUpVertices()
    {
        _vertices = new VertexPositionColor[5]
        {
            new VertexPositionColor() { Position = new Vector3(0f, 0f, 0f), Color = Color.White},
            new VertexPositionColor() {Position = new Vector3(5f, 0f, 0f), Color = Color.White},
            new VertexPositionColor() {Position = new Vector3(10f, 0f, 0f), Color = Color.White},
            new VertexPositionColor() {Position = new Vector3(5f, 0f, -5f), Color = Color.White},
            new VertexPositionColor() {Position = new Vector3(10f, 0f, -5f), Color = Color.White}
        };
    }

    private void SetUpIndices()
    {
        _indices = [3, 1, 0, 4, 2, 1];
    }

    public void Draw(Matrix viewMatrix, Matrix projectionMatrix, Matrix? worldMatrix)
    {
        _effect.CurrentTechnique = _effect.Techniques["ColoredNoShading"];
        _effect.Parameters["xView"].SetValue(viewMatrix);
        _effect.Parameters["xProjection"].SetValue(projectionMatrix);

        Matrix world = worldMatrix ?? Matrix.Identity;
        _effect.Parameters["xWorld"].SetValue(world);

        foreach (EffectPass pass in _effect.CurrentTechnique.Passes)
        {
            pass.Apply();
            _device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, _vertices, 0, _vertices.Length, _indices, 0,  _indices.Length / 3, VertexPositionColor.VertexDeclaration);
        }
    }
}
