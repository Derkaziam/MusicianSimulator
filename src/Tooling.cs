namespace MusicianSimulator.Tools;

public static class GD {
    public static readonly int screenWidth = 800;
	public static readonly int screenHeight = 450;

    public static int PercentToScreen(int percent) => (int) Math.Round((float) percent / 100f * screenWidth);
}