using PollinateUI.Buttons;

namespace MusicianSimulator.Core.Menus;

public interface IMenu {
    public bool Ping { get; }
    public void Update();
    public void Draw();
}

public enum MainMenus {
    NONE,
    GAME,
    LOAD,
    SETTINGS,
    CLOSE,
}

public enum GameMenus {
    ALERT,
    HOME,
    ACCT,
    STATS,
    CHART,
    SHOP,
}
