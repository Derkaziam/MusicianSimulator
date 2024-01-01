using PollinateUI.Buttons;
using PollinateUI.TextBoxes;
using MusicianSimulator.Core.Menus;

namespace MusicianSimulator.Core;

public unsafe class Game {
	public MainMenu menu;
    Vector2 mousePos;
    Vector2 boxSize = new(16);

    public Game() {
        menu = new();
    }

    public void Update() {
        mousePos = Raylib.GetMousePosition();
        mousePos.X = (float) Math.Round(mousePos.X / boxSize.X) * boxSize.X;
        mousePos.Y = (float) Math.Round(mousePos.Y / boxSize.Y) * boxSize.Y;

        menu.Update();
    }

    public unsafe void Draw() {
        RenderLines();

        Raylib.DrawText(mousePos.ToString(), 20, 20, 20, Raylib.BLACK);
        
        Raylib.DrawFPS(20, 40);

        menu.Draw();
    }

    public void Initialize() {
    }

    void RenderLines() {
		for (int y = 0; y < GD.screenHeight; y += (int) boxSize.Y) {
			Raylib.DrawLine(0, y, GD.screenWidth, y, Raylib.LIGHTGRAY);
		}
		
		for (int x = 0; x < GD.screenWidth; x += (int) boxSize.X) {
			Raylib.DrawLine(x, 0, x, GD.screenWidth, Raylib.LIGHTGRAY);
		}
	}
}
