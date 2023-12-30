global using ZeroElectric.Vinculum;
global using System.Numerics;

using DerkUI.Buttons;
using DerkUI.TextBoxes;
using MusicianSimulator.Tools;

namespace MusicianSimulator.Core;

class Program {
	static Vector2 boxSize = new(20);

    static void Main() {
		Vector2 mousePos;

		Raylib.InitWindow(GD.screenWidth, GD.screenHeight, "Hello World , Raylib-CSharp-Vinculum");
		Raylib.SetTargetFPS(60);

		BasicTextButton button = new (
			new Vector4(0, 0, 32, 16),
			new Vector4(350, 200, 100, 40),
			new Vector2(400, 175),
			"Hello World, I haven't been clicked!",
			"Hello World, I have been clicked!",
			@"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png"
		);

		EditableTextBox textBox = new(TextBoxState.NORMAL, new Rectangle(100, 100, 200, 40));

		while (!Raylib.WindowShouldClose()) {
			mousePos = Raylib.GetMousePosition();
			mousePos.X = (float) Math.Round(mousePos.X / boxSize.X) * boxSize.X;
			mousePos.Y = (float) Math.Round(mousePos.Y / boxSize.Y) * boxSize.Y;
			
			textBox.Update();
			textBox.Debug(60);
			button.Update();

			Raylib.BeginDrawing();

			Raylib.ClearBackground(Raylib.RAYWHITE);

			RenderLines();

			Raylib.DrawText(mousePos.ToString(), 20, 20, 20, Raylib.BLACK);
			Raylib.DrawFPS(20, 40);

			textBox.Draw();
			button.Draw();

			Raylib.EndDrawing();
		}

		Raylib.CloseWindow();
    }

	static void RenderLines() {
		for (int y = 0; y < GD.screenHeight; y += (int) boxSize.Y) {
			Raylib.DrawLine(0, y, GD.screenWidth, y, Raylib.DARKGRAY);
		}
		
		for (int x = 0; x < GD.screenWidth; x += (int) boxSize.X) {
			Raylib.DrawLine(x, 0, x, GD.screenWidth, Raylib.DARKGRAY);
		}
	} 
}
