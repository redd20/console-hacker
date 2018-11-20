using System;
using UnityEngine;

public class Hacker : MonoBehaviour {

    #region variables

    public string greeting ;
    public bool isLoggedIn = false;
    public string[] coffeShop = { "mug", "coffee", "bob", "sally" } ;
    public string[] polDataBase = {"police","detective","murder" };
    public string[] nsaFirewall = { "president", "security", "national" };

    public enum Screen {MainMenu,CoffePass,CoffeLog,PolPass,Pollogged,NsaPass,NsaLogged,logon};
    public Screen currentScreen = Screen.MainMenu;
    string passwordcoffee ;
    string passwordpolice ;
    string passwordNSA;

    #endregion
    // Use this for initialization
    void Start ()
    {
        StartGame();
    }


    void OnUserInput(string input)
    {
        if (currentScreen ==  Screen.MainMenu )
        {
            ShowMainMenu(input);
        }
        else if (currentScreen == Screen.CoffePass)
        {
            CoffeePasswordMenu(input);
        }
        else if (currentScreen == Screen.CoffeLog)
        {
            CoffeeLoggedScreen(input);
        }
        else if (currentScreen == Screen.PolPass)
        {
            PolicePasswordScreen(input);
        }
        else if (currentScreen == Screen.Pollogged)
        {
            PoliceLoggedScreen(input);
        }
        else if (currentScreen == Screen.NsaPass)
        {
            NsaPasswordMenu(input);
        }
        else if (currentScreen == Screen.NsaLogged)
        {
            NsaLoggedScreen(input);
        }
        else if (currentScreen == Screen.logon)
        {
            LoginScreen(input);
        }
    }


    #region functions
    void LoadMenu(string greetParam)
    {
        Terminal.ClearScreen();
        UserNameLogin(greetParam);
        Terminal.WriteLine("Welcome to Terminal XJ114fJC");
        Terminal.WriteLine("Please make a choice");
        Terminal.WriteLine("");
        Terminal.WriteLine("1. Hack into CoffeShop.WiFi");
        Terminal.WriteLine("2. Hack Police.docs");
        Terminal.WriteLine("3. Breach NSA.Firewall");
        Terminal.WriteLine("4. Login");
        Terminal.WriteLine("");
        Terminal.WriteLine("Make your selection:");
    }

    private void UserNameLogin(string greetParam)
    {
        if (isLoggedIn == true)
        {
            Terminal.WriteLine("Welcome " + greetParam);
        }
        else
        {
            Terminal.WriteLine(greetParam);
        }
    }

    private void PoliceLoggedScreen(string input)
    {
        if (input == "menu")
        {
            ResetPolicePassword();
            currentScreen = Screen.MainMenu;
            LoadMenu(greeting);
        }
        else
        {
            PolLog();
        }
    }
    private void PolicePasswordScreen(string input)
    {
        if (input == "menu")
        {
            ResetPolicePassword();
            currentScreen = Screen.MainMenu;
            LoadMenu(greeting);
        }
        else if (input == passwordpolice)
        {
            currentScreen = Screen.Pollogged;
            PolLog();
        }
        else
        {
            PolStation();
        }
    }
    private void ResetPolicePassword()
    {
        passwordpolice = polDataBase[UnityEngine.Random.Range(0, polDataBase.Length)];
    }

    private void CoffeeLoggedScreen(string input)
    {
        if (input == "menu")
        {
            ResetCoffeePassword();
            currentScreen = Screen.MainMenu;
            LoadMenu(greeting);
        }
        else
        {
            CoffeLog();
        }
    }
    private void CoffeePasswordMenu(string input)
    {
        if (input == "menu")
        {
            ResetCoffeePassword();
            currentScreen = Screen.MainMenu;
            LoadMenu(greeting);
        }
        else if (input == passwordcoffee)
        {
            currentScreen = Screen.CoffeLog;
            CoffeLog();
        }
        else
        {
            CoofeeShop();
        }
    }
    private void ResetCoffeePassword()
    {
        passwordcoffee = coffeShop[UnityEngine.Random.Range(0, coffeShop.Length)];
    }

    private void NsaLoggedScreen(string input)
    {
        if (input == "menu")
        {
            ResetNsaPassword();
            currentScreen = Screen.MainMenu;
            LoadMenu(greeting);
        }
        else
        {
            NsaLog();
        }
    }
    private void NsaPasswordMenu(string input)
    {
        if (input == "menu")
        {
            ResetNsaPassword();
            currentScreen = Screen.MainMenu;
            LoadMenu(greeting);
        }
        else if (input == passwordNSA)
        {
            currentScreen = Screen.NsaLogged;
            NsaLog();
        }
        else
        {
            NsaStation();
        }
    }
    private void ResetNsaPassword()
    {
        passwordNSA = nsaFirewall[UnityEngine. Random.Range(0, nsaFirewall.Length)];
    }

    private void StartGame()
    {
        ResetCoffeePassword();
        ResetPolicePassword();
        ResetNsaPassword();
        LoadMenu(greeting);
    }

    private void ShowMainMenu(string input)
    {
        if (input == "1") //bool in print
        {
            currentScreen = Screen.CoffePass;
            CoofeeShop();
        }
        else if (input == "2")
        {
            currentScreen = Screen.PolPass;
            PolStation();
        }
        else if (input == "3")
        {
            currentScreen = Screen.NsaPass;
            NsaStation();
        }
        else if (input == "4")
        {
            currentScreen = Screen.logon;
            Logonmenu();
        }
        else if (input == "menu")
        {
            LoadMenu(greeting);
        }
        else
        {
            string holder = greeting;
            greeting = "please make a valid selection";
            LoadMenu(greeting);
            greeting = holder;
        }
    }

    private void LoginScreen(string input)
    {
        
        greeting = input;
        isLoggedIn = true;
        currentScreen = Screen.MainMenu;
        LoadMenu(greeting);
        
        
    }

    private void Logonmenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter a Name");
    }

    private void PolLog()
    {
        Terminal.ClearScreen();
            Terminal.WriteLine("Welcome to the Vice City DataBase:");
            Terminal.WriteLine("Type : menu to return");
    }
    private static void CoffeLog()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to Dark Beans Coffee Shop");
        Terminal.WriteLine(@"
(  (  (
 )  )  )
(__(__(__
|        |--
|        |  |
|        |--
|________|
");

        Terminal.WriteLine("Type : menu to return");
    }
    private static void NsaLog()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Security Breach in Sector x");
        Terminal.WriteLine(@"
 __     _     ____         ___
|  \   | |   / __ \       /   \
|   \  | |  | |__|_|     / /_\ \
| |\ \ | |   \____ \    /  ___  \
| | \ \| |    _   | |  /  /   \  \
| |  \   |   | \_/ /  /  /     \  \
| |   \  |    \___/  /__/       \__\
");

        Terminal.WriteLine("Type : menu to return");
    }

    private void PolStation()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Connecting to Police Station DATABASE");
        Terminal.WriteLine("Type : menu to return");
        Terminal.WriteLine("Please enter a Password: ");
        Terminal.WriteLine("Hint: " + passwordpolice.Anagram());
    }
    private void CoofeeShop()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Connecting to the coffeshop");
        Terminal.WriteLine("Type : menu to return");
        Terminal.WriteLine("Please enter a Password: ");
        Terminal.WriteLine("Hint : " + passwordcoffee.Anagram());
    }
    private void NsaStation()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Connecting to the NSA");
        Terminal.WriteLine("Type : menu to return");
        Terminal.WriteLine("Please enter a Password: ");
        Terminal.WriteLine("Hint : " + passwordNSA.Anagram());
    }

    #endregion

}
