using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using Pineapple.Core;
using Pineapple.Managers;
using Testing.Scripts.Core;

namespace Testing.Scripts;

internal class Program
{
    public static SceneManager SceneManager { get; } = new(initialSceneName: "Main", initialScene: new Main());

    static void Main(string[] args)
    {
        SceneManager.AddScene("Settings", new Settings());

        Application.Run(title: "Testing", size: new Vector2i(960, 540), sceneManager: SceneManager, windowBorder: WindowBorder.Resizable);
    }
}