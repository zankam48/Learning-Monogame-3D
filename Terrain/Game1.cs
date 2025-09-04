using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
// using Mono

namespace Terrain;

public class Game1 : Core
{
    public Game1() : base("Terrain", 800, 600, false)
    {
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        // base.LoadContent();
        _effect = Content.Load<Effect>("effects");
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

        // TODO: Add your drawing code here
        _effect.CurrentTechnique = _effect.Techniques["Pretransformed"];

        foreach (EffectPass pass in _effect.CurrentTechnique.Passes)
        {
            pass.Apply();
        }

        base.Draw(gameTime);
    }
}
