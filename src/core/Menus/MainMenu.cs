using PollinateUI.Buttons;
using PollinateUI.Handlers;
using PollinateUI.Images;

namespace MusicianSimulator.Core.Menus;

public class MainMenu : IMenu {
    readonly List<IStateButton> buttons;
    readonly PollinateImage logo;
    readonly ButtonHandler buttonHandler;
    GameMenu gameMenu;

    public MainMenu() {
        buttons = new List<IStateButton>() {
            // Start button
            new StateButtonTex (
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\MainMenuButtons.png",
                new Rectangle(0, 0, 96, 32),
                new Rectangle(434, 368, 192, 64),
                true
            ),
            // Close button
            new StateButtonTex (
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\MainMenuButtons.png",
                new Rectangle(96, 0, 96, 32),
                new Rectangle(658, 448, 192, 64),
                true
            ),
            // Settings button
            new StateButtonTex (
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\MainMenuButtons.png",
                new Rectangle(0, 64, 96, 32),
                new Rectangle(658, 368, 192, 64),
                true
            ),
            // Load button
            new StateButtonTex (
                @"\programs\personal\c#\Games\MusicianSimulator\res\art\MainMenuButtons.png",
                new Rectangle(96, 64, 96, 32),
                new Rectangle(434, 448, 192, 64),
                true
            )
        };
        buttonHandler = new ButtonHandler(ref buttons);
        gameMenu = new();
        logo = new(
            @"\programs\personal\c#\Games\MusicianSimulator\res\art\Logo.png",
            new Rectangle(0, 0, 256, 128),
            new Rectangle(384, 96, 512, 256)
        );
    }

    public void Update() {
        foreach (IStateButton button in buttons) {
            button.Update();
        }
        buttonHandler.Update();

        if (buttonHandler.CurrentButton != null) {
            if (buttonHandler.CurrentButton == buttons[0]) { // Start button
                gameMenu.Update();
            }
        }
    }

    public void Draw() {
        foreach (IStateButton button in buttons) {
            button.Draw();
        }
        logo.Draw();

        if (buttonHandler.CurrentButton != null) {
            if (buttonHandler.CurrentButton == buttons[0]) { // Start button
                gameMenu.Draw();
            }
        }
    }
}
