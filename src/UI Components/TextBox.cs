namespace DerkUI.TextBoxes;

public enum TextBoxState {
    NORMAL,
    DISABLED,
    FOCUSED
}

public interface ITextBox {
    public string Text { get; set; }
    public void Draw();
    public void Update();
}

public class EditableTextBox : ITextBox {
    public string Text { get; set; }
    private TextBoxState state;
    private Rectangle boundary;

    public EditableTextBox(TextBoxState _defaultState, Rectangle _boundary) {
        Text = string.Empty;
        state = _defaultState;
        boundary = _boundary;
    }

    public void Draw() {
        Raylib.DrawRectangleRec(boundary, Raylib.LIGHTGRAY);
        Raylib.DrawText(Text, boundary.x + 10, boundary.y + (boundary.height - 20) / 2, 20, Raylib.BLACK);
    }

    public void Update() {
        if (state == TextBoxState.DISABLED) {
            return;
        }
        
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)) {
            bool isPressed = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), boundary);
            if (isPressed) {
                OnClick();
            } else {
                state = TextBoxState.NORMAL;
            }
        }

        if (state == TextBoxState.FOCUSED) {
            if (Raylib.MeasureText(Text, 20) > boundary.width - 20) {
                Edit('\b');
                return;
            }
            Edit(GetCharFromKeyboard());
        }
    }

    public void Debug(int _y) {
        Raylib.DrawText(state.ToString(), 20, _y, 20, Raylib.BLACK);
    }

    private char GetCharFromKeyboard() {
        KeyboardKey key = (KeyboardKey) Raylib.GetKeyPressed();
        switch (key) {
            case KeyboardKey.KEY_A:
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT)) {
                    return 'A';
                }
                return 'a';
            case KeyboardKey.KEY_B:
                return 'b';
            case KeyboardKey.KEY_C:
                return 'c';
            case KeyboardKey.KEY_D:
                return 'd';
            case KeyboardKey.KEY_E:
                return 'e';
            case KeyboardKey.KEY_F:
                return 'f';
            case KeyboardKey.KEY_G:
                return 'g';
            case KeyboardKey.KEY_H:
                return 'h';
            case KeyboardKey.KEY_I:
                return 'i';
            case KeyboardKey.KEY_J:
                return 'j';
            case KeyboardKey.KEY_K:
                return 'k';
            case KeyboardKey.KEY_L:
                return 'l';
            case KeyboardKey.KEY_M:
                return 'm';
            case KeyboardKey.KEY_N:
                return 'n';
            case KeyboardKey.KEY_O:
                return 'o';
            case KeyboardKey.KEY_P:
                return 'p';
            case KeyboardKey.KEY_Q:
                return 'q';
            case KeyboardKey.KEY_R:
                return 'r';
            case KeyboardKey.KEY_S:
                return 's';
            case KeyboardKey.KEY_T:
                return 't';
            case KeyboardKey.KEY_U:
                return 'u';
            case KeyboardKey.KEY_V:
                return 'v';
            case KeyboardKey.KEY_W:
                return 'w';
            case KeyboardKey.KEY_X:
                return 'x';
            case KeyboardKey.KEY_Y:
                return 'y';
            case KeyboardKey.KEY_Z:
                return 'z';
            case KeyboardKey.KEY_SPACE:
                return ' ';
            case KeyboardKey.KEY_BACKSPACE:
                return '\b';
            default:
                return '\0';
        }
    }

    private void Edit(char _c) {
        if (_c == '\b') {
            try {
                Text = Text[..^1];
            } catch {
                return;
            }
        } else if (_c == '\0') {
            return;
        } else Text += _c;
    }

    private void OnClick() {
        state = TextBoxState.FOCUSED;
    }

    private void Reset() {
        Text = "";
    }
}
