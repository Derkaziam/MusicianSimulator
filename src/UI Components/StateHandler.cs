using PollinateUI.Buttons;

namespace PollinateUI.Handlers;

public class ButtonHandler {
    public IStateButton? CurrentButton { get; set; }
    List<IStateButton> buttons;

    public ButtonHandler(List<IStateButton> _buttons) {
        buttons = _buttons;
    }

    public void Update() {
        foreach (IStateButton button in buttons) {
            if (button.Ping) {
                CurrentButton = button;
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