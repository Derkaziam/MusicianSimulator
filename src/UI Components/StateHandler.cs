using MusicianSimulator.UI.Buttons;

namespace MusicianSimulator.UI.Handlers;

public class ButtonHandler {
    List<IStateButton> buttons;

    public ButtonHandler(List<IStateButton> _buttons) {
        buttons = _buttons;
    }

    public void Update() {
        foreach (IStateButton button in buttons) {
            if (button.Ping) {
                // Change the state of all other buttons to off
                foreach (IStateButton otherButton in buttons) {
                    if (otherButton != button) {
                        otherButton.BeenClicked = false;
                    }
                }
                break;
            }
        }
    }


}