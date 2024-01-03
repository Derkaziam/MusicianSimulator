namespace PollinateUI.Images;

public class PollinateImage {
    Texture image;
    Rectangle source;
    Rectangle destination;

    public PollinateImage(string _image, Rectangle _source, Rectangle _destination) {
        image = Raylib.LoadTexture(_image);
        source = _source;
        destination = _destination;
    }

    public void Draw() {
        Raylib.DrawTexturePro(image, source, destination, Vector2.Zero, 0, Raylib.WHITE);
    }
}
