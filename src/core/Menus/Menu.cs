namespace MusicianSimulator.Core.Menus;

public interface IMenu {
    public void Update();
    public void Draw();
}

public enum MenuType {
    MAIN,
    GAME
}

public class RootMenuHandler {
    readonly MenuType? currentMenu;
    readonly MenuType? selectedMenu;
    MainMenu mainMenu;
    GameMenu gameMenu;
    
    public RootMenuHandler() {
        mainMenu = new();
        gameMenu = new();
    }

    public void Draw() {
        switch (currentMenu) {
            case MenuType.MAIN:
                mainMenu.Draw();
                break;
            case MenuType.GAME:
                gameMenu.Draw();
                break;
        }
    }
}

public enum GameMenus {
    ALERT,
    HOME,
    ACCT,
    STATS,
    CHART,
    SHOP
}
