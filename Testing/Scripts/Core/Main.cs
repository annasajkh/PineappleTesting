// Ignore Spelling: App

using Pineapple.Core;
using SkiaSharp;
using Window = Pineapple.Core.Window;
using Pineapple.Abstract;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Testing.Scripts.Core;

public class Main : Scene
{
    float time;
    SKImage? catImage;
    SKPaint paint;

    Random random = new Random();

    public override void Load()
    {
        catImage = SKImage.FromEncodedData(Path.Combine("Assets", "Sprites", "this fucking cat.png"));

        paint = new SKPaint
        {
            Color = SKColors.White,
            IsAntialias = true,
            Style = SKPaintStyle.Fill,
            TextAlign = SKTextAlign.Center,
            TextSize = 32
        };
    }

    public override void Update(float delta)
    {
        time += delta;

        if (Input.IsKeyPressed(Keys.S))
        {
            Program.SceneManager.ChangeScene("Settings");
        }
    }

    public override void Draw(SKCanvas canvas)
    {
        canvas.Clear(SKColor.Parse("#1e2226"));

        canvas.DrawImage(catImage, new SKPoint(100, 100), paint);

        paint.Color = SKColors.Red;

        canvas.Save();

        canvas.Translate(Window.Size.X / 2, Window.Size.Y / 2);
        canvas.RotateRadians(time * 2);

        canvas.DrawRect(-50, -50, 100, 100, paint);
        canvas.Restore();

        paint.Color = SKColors.White;
        
        canvas.DrawCircle(new SKPoint(Input.MousePosition.X, Input.MousePosition.Y), 50, paint);
    }

    public override void Unload()
    {
        Console.WriteLine("Dispose");

        catImage!.Dispose();
        paint.Dispose();
    }
}