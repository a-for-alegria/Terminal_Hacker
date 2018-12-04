using UnityEngine;

public class Hacker : MonoBehaviour {
    // Game configuration data
    string[] level1Passwords = { "phone", "button", "call", "signal", "screen" };
    string[] level2Passwords = { "internet", "programming", "remote", "connection", "technology" };
    string[] level3Passwords = { "extraterrestrial", "athmosphere", "interstellar", "astronaut", "dehydration" };

    // Game states
    int level;
    string password;

    enum Screen {MainMenu, Password, Win}
    Screen currentScreen;

    // Use this for initialization
    void Start ()
    {
        currentScreen = Screen.MainMenu;
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Choose your target:");
        Terminal.WriteLine("Press 1 for mobile phone");
        Terminal.WriteLine("Press 2 for laptop");
        Terminal.WriteLine("Press 3 for military satelite");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "Menu" || input == "menu")
        {
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        SetRandomPassword();
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter password. Hint: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("Type 'menu' to go back");
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("President's phone. Access granted");
                break;
            case 2:
                Terminal.WriteLine("Secret laptop. Access granted");
                break;
            case 3:
                Terminal.WriteLine("International satelite. Access granted");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;

        } 
    }
}
