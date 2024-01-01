namespace PollinateUI.Buttons;

/// <summary>
/// The root interface of all buttons.
/// </summary>
public unsafe interface IButton {
    public unsafe void Draw();
    public void Update();
}

/// <summary>
/// The root interface of all text buttons.
/// </summary>
public interface ITextButton : IButton {
    public string Text { get; }
}

/// <summary>
/// The root interface of all state buttons.
/// </summary>
public interface IStateButton : IButton {
    public bool BeenClicked { get; set; }
    public bool Ping { get; }
}

/// <summary>
/// Represents a button that displays text. Implements IButton & ITextButton.
/// </summary>
public unsafe class TextButtonTex : ITextButton {
    /// <summary>
    /// What the button displays.
    /// </summary>
    public string Text { get; private set; }
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
    
    /// <summary>
    /// Initializes a new instance of the TextButton class.
    /// </summary>
    /// <param name="_source">Determines the position and size of the button.</param>
    /// <param name="_dest">Determines which sprite to use.</param>
    /// <param name="_textPos">Where the text will be drawn.</param>
    /// <param name="_text">What the button displays by default.</param>
    /// <param name="_altText">The alternative text to be used if the button is pressed.</param>
    public TextButtonTex(Rectangle _source, // Determines the position and size of the button
                                  Rectangle _dest, // Determines which sprite to use
                                  Vector2 _textPos, // Where the text will be drawn
                                  string _text, // What the button displays by default
                                  string _altText // The alternative text to be used if the button is pressed
    ) {
        texture = Raylib.LoadTexture(@"\programs\personal\c#\Games\MusicianSimulator\res\art\Button.png"); // Loads the texture
        source = _source; // What sprite is used
        destination = _dest; // Where the sprite is drawn
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
        shouldTick = true;
        Text = alternateText;
        isPressed = false;
        source.Y = source.height;
    }

    private void Reset() {
        Text = originalText;
        source.Y = 0;
    }
}

public unsafe class StateButtonTex : IStateButton {
    public bool BeenClicked { get; set; }
    public bool Ping { get; private set; }
    private readonly Texture texture;
    private readonly Vector2 origin;
    private Rectangle source;
    private Rectangle originalSource;
    private Rectangle destination;

    public StateButtonTex(string _texPath, Rectangle _src, Rectangle _dest) {
        texture = Raylib.LoadTexture(_texPath);
        source = _src;
        originalSource = _src;
        destination = _dest;

        origin = Vector2.Zero;
        Ping = false;
    }
    
    public unsafe void Draw() {
        Raylib.DrawTexturePro(
            texture,
            source, destination,
            origin, 0, Raylib.WHITE
        );
    }
    
    public void Update() {
        Ping = false;
        // Checks if mouse is pressed, checks if button is pressed and sets shouldTick to true
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)){
            Vector2 mousePos = Raylib.GetMousePosition();
            CheckState(mousePos);
        }

        // Animates the button
        if (!BeenClicked) Reset();
    }

    private void CheckState(Vector2 _mousePos) {
        // checks collision between mouse and button
        bool isPressed = Raylib.CheckCollisionPointRec(_mousePos, destination);
        // if pressed sets BeenClick to true, else resets the button 
        if (isPressed == true) {
            BeenClicked = true;
            Ping = true;
            source.Y = originalSource.Y + originalSource.height;
        }
    }

    private void Reset() {
        source.Y = originalSource.Y;
    }
}
