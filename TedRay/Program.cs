using Raylib_cs;
using System.Numerics;

namespace TedRay;

public enum GameScreen
{
    LOGO = 0,
    TITLE,
    GAMEPLAY,
    ENDING
}

public class Programs
{
    private const string DATA_FILE = @"C:\Users\shiog\Workspace\dotnet\TedRay\TedRay\Assets\Data\rlgl.h";
    private const string FONT_PATH = @"C:\Users\shiog\Workspace\dotnet\TedRay\TedRay\Assets\Fonts\VictorMono-Regular.ttf";

    public static void Main()
    {
        Raylib.SetWindowState(ConfigFlags.ResizableWindow);
        var data = File.ReadAllLines(DATA_FILE);

        Raylib.InitWindow(1200, 800, "TEDRay - Text Editor");
        int width = Raylib.GetScreenWidth();
        int height = Raylib.GetScreenHeight();

        Raylib.SetTargetFPS(60);
        Raylib.SetTextLineSpacing(16);
        Font font = Raylib.LoadFont(FONT_PATH);

        while (!Raylib.WindowShouldClose())
        {
            if (Raylib.IsKeyPressed(KeyboardKey.F11))
            {
                Raylib.ToggleFullscreen();
            }

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);
            Raylib.DrawFPS(5, 5);

            for (int i = 0; i < data.Length; i++)
            {
                Raylib.DrawTextEx(
                    font,
                    string.Format("{0} | {1}", (i + 1).ToString().PadLeft(5, ' '), data[i]),
                    new Vector2(5, 30 + (i * 16)),
                    font.BaseSize,
                    2,
                    Color.Black
                );
            }

            Raylib.EndDrawing();
        }

        Raylib.UnloadFont(font);
        Raylib.CloseWindow();
    }
}
