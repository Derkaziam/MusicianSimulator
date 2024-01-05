using PollinateUI.Buttons;
using PollinateUI.Handlers;
using PollinateUI.Images;

namespace MusicianSimulator.Core.Menus;

public class GameMenu : IMenu {
    public bool Ping { get; private set; }
    public ButtonHandler buttonHandler;
    public List<IStateButton> buttons;
    
    public GameMenu() {
        buttons = new() {
            new StateButtonTex( // Alert Button
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(0, 0, 64, 32),
                new Rectangle(32, 32, 128, 64)
            ),
            new StateButtonTex( // Home Button
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(96, 0, 64, 32),
                new Rectangle(32, 112, 128, 64)
            ),
            new StateButtonTex( // Account Button
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(192, 0, 64, 32),
                new Rectangle(32, 192, 128, 64)
            ),
            new StateButtonTex( // Shop Button
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(192, 64, 64, 32),
                new Rectangle(32, 272, 128, 64)
            ),
            new StateButtonTex( // Charts Button
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(96, 64, 64, 32),
                new Rectangle(32, 352, 128, 64)
            ),
            new StateButtonTex( // Statistics Button
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(0, 64, 64, 32),
                new Rectangle(32, 432, 128, 64)
            ),
            new StateButtonTex( // Exit Button
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(0, 128, 64, 32),
                new Rectangle(32, 624, 128, 64)
            ),
        };
        buttonHandler = new(ref buttons);
    }

    public void Draw() {
        Raylib.DrawRectangleRec(new Rectangle(0, 0, 192, GD.screenHeight), GD.ACCENT_COLOR);
        foreach (IStateButton button in buttons) {
            button.Draw();
        }
    }

    public void Update() {
        foreach (IStateButton button in buttons) {
            button.Update();
        }
        buttonHandler.Update();
    }
}
