global using ZeroElectric.Vinculum;
global using System.Numerics;

using MusicianSimulator.UI.Buttons;
using MusicianSimulator.UI.TextBoxes;
using MusicianSimulator.Core.Tools;
using MusicianSimulator.Core.Menus;

namespace MusicianSimulator.Core;

class Program {
	static Vector2 boxSize = new(20);

    static void Main() {
		Vector2 mousePos;

		Raylib.InitWindow(GD.screenWidth, GD.screenHeight, "Musician Simulator");
		Raylib.SetTargetFPS(60);

		TextButton button = new (
			new Rectangle(0, 0, 64, 32),
			new Rectangle(20, 160, 128, 64),
			new Vector2(400, 175),
			"eversnore tanked",
			"speak now outsold",
			@"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png"
		);

		/* StateButton stateButton = new(
			@"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
			new Rectangle(96, 0, 64, 32),
			new Rectangle(20, 260, 128, 64)
		); */

		MainMenu menu = new();

		EditableTextBox textBox = new(TextBoxState.NORMAL, new Rectangle(100, 100, 200, 40));

		while (!Raylib.WindowShouldClose()) {
			mousePos = Raylib.GetMousePosition();
			mousePos.X = (float) Math.Round(mousePos.X / boxSize.X) * boxSize.X;
			mousePos.Y = (float) Math.Round(mousePos.Y / boxSize.Y) * boxSize.Y;
			
			textBox.Update();
			textBox.Debug(60);
			button.Update();
			menu.Update();
			//stateButton.Update();

			Raylib.BeginDrawing();

			Raylib.ClearBackground(Raylib.RAYWHITE);

			RenderLines();

			Raylib.DrawText(mousePos.ToString(), 20, 20, 20, Raylib.BLACK);
			
			//if (stateButton.BeenClicked) Raylib.DrawText("Hi from state button!", 20, 300, 20, Raylib.BLACK);
			Raylib.DrawFPS(20, 40);

			textBox.Draw();
			button.Draw();
			menu.Draw();
			// stateButton.Draw();

			Raylib.EndDrawing();
		}

		Raylib.CloseWindow();
    }

	static void RenderLines() {
		for (int y = 0; y < GD.screenHeight; y += (int) boxSize.Y) {
			Raylib.DrawLine(0, y, GD.screenWidth, y, Raylib.LIGHTGRAY);
		}
		
		for (int x = 0; x < GD.screenWidth; x += (int) boxSize.X) {
			Raylib.DrawLine(x, 0, x, GD.screenWidth, Raylib.LIGHTGRAY);
		}
	} 
}
