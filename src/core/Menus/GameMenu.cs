using PollinateUI.Buttons;
using PollinateUI.Handlers;
using PollinateUI.Images;

namespace MusicianSimulator.Core.Menus;

public class GameMenu : IMenu {
    public ButtonHandler buttonHandler;
    public List<IStateButton> buttons;
    
    public GameMenu() {
        buttons = new() {
            new StateButtonTex(
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(0, 0, 64, 32),
                new Rectangle(0, 0, 64, 32),
                true
            ),
            new StateButtonTex(
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(0, 0, 64, 32),
                new Rectangle(0, 0, 64, 32),
                true
            ),
            new StateButtonTex(
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(0, 0, 64, 32),
                new Rectangle(0, 0, 64, 32),
                true
            ),
            new StateButtonTex(
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(0, 0, 64, 32),
                new Rectangle(0, 0, 64, 32),
                true
            ),
            new StateButtonTex(
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(0, 0, 64, 32),
                new Rectangle(0, 0, 64, 32),
                true
            ),
            new StateButtonTex(
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(0, 0, 64, 32),
                new Rectangle(0, 0, 64, 32),
                true
            ),
        };
        buttonHandler = new(ref buttons);
    }

    public void Draw() {
        Raylib.ClearBackground(GD.BACKGROUND_COLOR);
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
