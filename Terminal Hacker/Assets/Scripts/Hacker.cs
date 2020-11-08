using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    string password;
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    private void Start()
    {
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Whatcha want to hack into?\n");
        Terminal.WriteLine("Press 1 to hack library");
        Terminal.WriteLine("Press 2 to hack police station");
        Terminal.WriteLine("Press 3 to hack NASA\n");
        Terminal.WriteLine("Enter your selection:");
    }

    private void OnUserInput(string input)
    {
        if (input == "menu")
        {
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

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
        }
    }

    private void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();

        Terminal.WriteLine("Please enter your password.");
        Terminal.WriteLine("Hint: " + password.Anagram());
    }

    private void SetRandomPassword()
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
                Debug.Log("You broke it :(");
                break;
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Please try again.");
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowWinImage();
    }

    private void ShowWinImage()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Level 1 Complete!");
                break;
            case 2:
                Terminal.WriteLine("Level 2 Complete!");
                break;
            case 3:
                Terminal.WriteLine("Level 3 Complete!");
                break;
            default:
                break;
        }
        Terminal.WriteLine("Type 'menu' to return to the main menu.");
    }
}
