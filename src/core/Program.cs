global using ZeroElectric.Vinculum;
global using System.Numerics;
global using MusicianSimulator.Core.Tools;

namespace MusicianSimulator.Core;

class Program {
    static void Main() {
		Raylib.InitWindow(GD.screenWidth, GD.screenHeight, "Musician Simulator");
		Raylib.SetTargetFPS(GD.targetFPS);

		Game game = new();

		game.Initialize();

		while (!Raylib.WindowShouldClose()) {
			game.Update();

			Raylib.BeginDrawing();

			game.Draw();

			Raylib.EndDrawing();
		}

		Raylib.CloseWindow();
    } 
}
