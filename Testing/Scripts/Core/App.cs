// Ignore Spelling: App

using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using Pineapple.Core;
using SkiaSharp;
using Window = Pineapple.Core.Window;

namespace Testing.Scripts.Core;

public class App
{
    float time;
    SKImage? catImage;

    Random random = new Random();

    public App()
    {
        Application.Load += Load;
        Application.Update += Update;
        Application.Draw += Draw;
        Application.Unload += Unload;
    }

    void Load()
    {
        catImage = SKImage.FromEncodedData(Path.Combine("Assets", "Sprites", "this fucking cat.png"));
    }

    void Update(float delta)
    {
        time += delta;
    }

    void Draw(SKCanvas canvas, SKPaint paint)
    {
        canvas.Clear(SKColors.CornflowerBlue);

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

    void Unload()
    {
        catImage!.Dispose();
    }

    public void Run()
    {
        Application.Run(title: "Testing", size: new Vector2i(960, 540), windowBorder: WindowBorder.Resizable);
    }
}