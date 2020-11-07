using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
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
        Terminal.WriteLine("Press 1 to hack into your local library\n");
        Terminal.WriteLine("Press 2 to hack into your local police station\n");
        Terminal.WriteLine("Enter your selection:\n");
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
    }

    private void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
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
        Terminal.WriteLine("You have chosen level " + level);
    }
}
