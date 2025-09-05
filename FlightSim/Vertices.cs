using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlightSim;

public class Vertices
{
    private GraphicsDevice _device;
    private Effect _effect;
    // private Texture2D _texture;
    private VertexPositionTexture[] _vertices;

    public Vertices(GraphicsDevice device, Effect effect)
    {
        _device = device;
        _effect = effect;
        SetUpVertices();
    }

    private void SetUpVertices()
    {
        _vertices = new VertexPositionTexture[6];

        _vertices[0].Position = new Vector3(-10f, 10f, 0f);
        _vertices[0].TextureCoordinate.X = 0;
        _vertices[0].TextureCoordinate.Y = 0;

        _vertices[1].Position = new Vector3(10f, -10f, 0f);
        _vertices[1].TextureCoordinate.X = 1;
        _vertices[1].TextureCoordinate.Y = 1;

        _vertices[2].Position = new Vector3(-10f, -10f, 0f);
        _vertices[2].TextureCoordinate.X = 0;
        _vertices[2].TextureCoordinate.Y = 1;

        _vertices[3].Position = new Vector3(10.1f, -9.9f, 0f);
        _vertices[3].TextureCoordinate.X = 1;
        _vertices[3].TextureCoordinate.Y = 1;

        _vertices[4].Position = new Vector3(-9.9f, 10.1f, 0f);
        _vertices[4].TextureCoordinate.X = 0;
        _vertices[4].TextureCoordinate.Y = 0;

        _vertices[5].Position = new Vector3(10.1f, 10.1f, 0f);
        _vertices[5].TextureCoordinate.X = 1;
        _vertices[5].TextureCoordinate.Y = 0;
    }

    public void Draw(Matrix viewMatrix, Matrix projectionMatrix, Matrix? worldMatrix, Texture2D texture)
    {
        Matrix world = worldMatrix ?? Matrix.Identity;
        _effect.CurrentTechnique = _effect.Techniques["TexturedNoShading"];
        _effect.Parameters["xWorld"].SetValue(world);
        _effect.Parameters["xView"].SetValue(viewMatrix);
        _effect.Parameters["xProjection"].SetValue(projectionMatrix);
        _effect.Parameters["xTexture"].SetValue(texture);

        foreach (EffectPass pass in _effect.CurrentTechnique.Passes)
        {
            pass.Apply();
            _device.DrawUserPrimitives(PrimitiveType.TriangleList, _vertices, 0, 2, VertexPositionTexture.VertexDeclaration);
        }
    }
}