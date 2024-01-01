namespace PollinateUI.TextBoxes;

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
        bool isCapital = Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT);
        switch (key) {
            case KeyboardKey.KEY_A:
                if (isCapital) return 'A';
                return 'a';
            case KeyboardKey.KEY_B:
                if (isCapital) return 'B';
                return 'b';
            case KeyboardKey.KEY_C:
                if (isCapital) return 'C';
                return 'c';
            case KeyboardKey.KEY_D:
                if (isCapital) return 'D';
                return 'd';
            case KeyboardKey.KEY_E:
                if (isCapital) return 'E';
                return 'e';
            case KeyboardKey.KEY_F:
                if (isCapital) return 'F';
                return 'f';
            case KeyboardKey.KEY_G:
                if (isCapital) return 'G';
                return 'g';
            case KeyboardKey.KEY_H:
                if (isCapital) return 'H';
                return 'h';
            case KeyboardKey.KEY_I:
                if (isCapital) return 'I';
                return 'i';
            case KeyboardKey.KEY_J:
                if (isCapital) return 'J';
                return 'j';
            case KeyboardKey.KEY_K:
                if (isCapital) return 'K';
                return 'k';
            case KeyboardKey.KEY_L:
                if (isCapital) return 'L';
                return 'l';
            case KeyboardKey.KEY_M:
                if (isCapital) return 'M';
                return 'm';
            case KeyboardKey.KEY_N:
                if (isCapital) return 'N';
                return 'n';
            case KeyboardKey.KEY_O:
                if (isCapital) return 'O';
                return 'o';
            case KeyboardKey.KEY_P:
                if (isCapital) return 'P';
                return 'p';
            case KeyboardKey.KEY_Q:
                if (isCapital) return 'Q';
                return 'q';
            case KeyboardKey.KEY_R:
                if (isCapital) return 'R';
                return 'r';
            case KeyboardKey.KEY_S:
                if (isCapital) return 'S';
                return 's';
            case KeyboardKey.KEY_T:
                if (isCapital) return 'T';
                return 't';
            case KeyboardKey.KEY_U:
                if (isCapital) return 'U';
                return 'u';
            case KeyboardKey.KEY_V:
                if (isCapital) return 'V';
                return 'v';
            case KeyboardKey.KEY_W:
                if (isCapital) return 'W';
                return 'w';
            case KeyboardKey.KEY_X:
                if (isCapital) return 'X';
                return 'x';
            case KeyboardKey.KEY_Y:
                if (isCapital) return 'Y';
                return 'y';
            case KeyboardKey.KEY_Z:
                if (isCapital) return 'Z';
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
