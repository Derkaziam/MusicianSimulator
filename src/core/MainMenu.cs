using MusicianSimulator.UI.Buttons;
using MusicianSimulator.UI.Handlers;

namespace MusicianSimulator.Core.Menus;

public class MainMenu {
    List<IStateButton> buttons;
    ButtonHandler buttonHandler;

    public MainMenu() {
        buttons = new List<IStateButton>() {
            new StateButton (
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(96, 0, 64, 32),
                new Rectangle(20, 260, 128, 64)
            ),
            new StateButton (
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png",
                new Rectangle(192, 0, 64, 32),
                new Rectangle(20, 360, 128, 64)
            )
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
