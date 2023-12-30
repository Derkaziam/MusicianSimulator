namespace DerkUI.Buttons;

public unsafe interface IButton {
    public unsafe void Draw();
    public void Update();
}

public interface ITextButton {
    public string Text { get; }
}

/// <summary>
/// Represents a button that displays text. Implements IButton & ITextButton.
/// </summary>
public unsafe class BasicTextButton : IButton, ITextButton {
    /// <summary>
    /// What the button displays.
    /// </summary>
    public string Text { get; set; }
    private Vector2 origin;
    private Vector2 textPosition;
    private Rectangle source;
    private Rectangle destination;
    private Texture texture;
    private bool isPressed;
    private bool shouldTick;
    private int frameCount;
    private readonly string originalText;
    private readonly string alternateText;
    
    public unsafe BasicTextButton(Vector4 _source, // Determines the position and size of the button
                                  Vector4 _dest, // Determines which sprite to use
                                  Vector2 _textPos, // Where the text will be drawn
                                  string _text, // What the button displays by default
                                  string _altText, // The alternative text to be used if the button is pressed
                                  string _texturePath // The path to the button's texture
    ) {
        texture = Raylib.LoadTexture(_texturePath); // Loads the texture
        source = new(_source.X, _source.Y, _source.Z, _source.W); // What sprite is used
        destination = new(_dest.X, _dest.Y, _dest.Z, _dest.W); // Where the sprite is drawn
        origin = Vector2.Zero; // Center of sprite
        textPosition = _textPos; // Where the text will be drawn
        Text = _text; // The current text of the button
        originalText = _text; // The original text of the button
        alternateText = _altText; // The text of the button if clicked

        shouldTick = false;
    }

    /// <summary>
    /// Primarily handles the animations of the button, but also handles any other events.
    /// </summary>
    public void Update() {
        // Checks if mouse is pressed, checks if button is pressed and sets shouldTick to true
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)){
            CheckState(Raylib.GetMousePosition());
            shouldTick = true;
        }

        // Animates the button
        if (shouldTick) {
            frameCount++;
            if (frameCount % 120 == 0) {
                Reset();
                shouldTick = false;
            }
        } else frameCount = 0;
    }

    /// <summary>
    /// Draws the button and it's text.
    /// </summary>
    public unsafe void Draw() {
        // Draws the button to the screen
        Raylib.DrawTexturePro(
            texture,
            source, destination,
            origin, 0, Raylib.WHITE
        );

        // Draws the text to the screen, center-aligned
        int textSize = Raylib.MeasureText(Text, 20);
        Raylib.DrawText(Text, textPosition.X - textSize / 2, textPosition.Y, 20, Raylib.BLACK);
    }

    private void CheckState(Vector2 _mousePos) {
        // checks collision between mouse and button
        isPressed = Raylib.CheckCollisionPointRec(_mousePos, destination);
        // if pressed calls OnClick, else resets the button 
        if (isPressed) {
            OnClick();
        }
        else {
            Reset();
        }
    }

    private void OnClick() {
        Text = alternateText;
        isPressed = false;
        source.Y = 16;
    }

    private void Reset() {
        Text = originalText;
        source.Y = 0;
    }
}


