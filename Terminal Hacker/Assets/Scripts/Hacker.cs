using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private void Start()
    {
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Whatcha want to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 to hack into your local library");
        Terminal.WriteLine("Press 2 to hack into your local police station");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
        Terminal.WriteLine("");
    }

    private void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
        }
    }
}
