using PollinateUI.Buttons;
using PollinateUI.Handlers;

namespace MusicianSimulator.Core.Menus;

public class MainMenu {
    List<IStateButton> buttons;
    ButtonHandler buttonHandler;

    public MainMenu() {
        buttons = new List<IStateButton>() {
            new StateButtonTex (
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\MainMenuButtons.png",
                new Rectangle(0, 0, 96, 32),
                new Rectangle(20, 240, 192, 64)
            ),
            new StateButtonTex (
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\MainMenuButtons.png",
                new Rectangle(96, 0, 96, 32),
                new Rectangle(20, 320, 192, 64)
            ),
            new StateButtonTex (
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\MainMenuButtons.png",
                new Rectangle(0, 64, 96, 32),
                new Rectangle(20, 400, 192, 64)
            ),
            new StateButtonTex (
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\MainMenuButtons.png",
                new Rectangle(96, 64, 96, 32),
                new Rectangle(20, 480, 192, 64)
            ),
        };
        buttonHandler = new ButtonHandler(buttons);
    }

    public void Update() {
        foreach (IStateButton button in buttons) {
            button.Update();
        }
        buttonHandler.Update();
    }

    public void Draw() {
        foreach (IStateButton button in buttons) {
            button.Draw();
        }
    }
}
