using OpenTK.Windowing.GraphicsLibraryFramework;
using Pineapple.Abstract;
using Pineapple.Core;
using SkiaSharp;
using Window = Pineapple.Core.Window;

namespace Testing.Scripts.Core;

public class Settings : Scene
{
    SKPaint paint;


    public override void Load()
    {
        paint = new SKPaint
        {
            Color = SKColors.White,
            IsAntialias = true,
            Style = SKPaintStyle.Fill,
            TextAlign = SKTextAlign.Center,
            TextSize = 64
        };

        paint.Typeface = SKTypeface.FromFile(Path.Combine("Assets", "Fonts", "GreatVibes-Regular.ttf"));
    }

    public override void Update(float delta)
    {
        if (Input.IsKeyPressed(Keys.Escape))
        {
            Program.SceneManager.ChangeScene("Main");
        }
    }

    public override void Draw(SKCanvas canvas)
    {
        canvas.Clear(SKColor.Parse("#1e2226"));
        canvas.DrawText("This is the settings", new SKPoint(Window.Size.X / 2, Window.Size.Y / 2), paint);
    }

    public override void Unload()
    {
        paint.Dispose();
    }
}
