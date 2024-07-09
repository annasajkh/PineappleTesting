using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using Pineapple.Core;
using Pineapple.Managers;
using Testing.Scripts.Core;

namespace Testing.Scripts;

internal class Program
{
    public static SceneManager SceneManager { get; } = new();

    static void Main(string[] args)
    {
        SceneManager.AddScene("Main", new Main());
        SceneManager.AddScene("Settings", new Settings());

        SceneManager.SetActiveScene("Main");

        Application.Run(title: "Testing", size: new Vector2i(960, 540), sceneManager: SceneManager, windowBorder: WindowBorder.Resizable);
    }
}