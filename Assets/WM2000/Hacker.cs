using UnityEngine;

public class Hacker : MonoBehaviour
{
    string[] currPasswords;
    string[] levelOnePasswords = {"frog", "dog", "bog"};
    string[] levelTwoPasswords = {"tree", "bee", "knee"};
    string[] levelThreePasswords = {"hop", "bop", "plop"};
    enum Screen{
        LevelOne, LevelTwo, LevelThree, MainMenu
    };
    Screen currentScreen = Screen.MainMenu;

    private string greeting = "Hey Dan";
    private string level;
    // Start is called before the first frame update
    void Start()
    {
        PrintWelcome(greeting);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PrintWelcome(string greeting){
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police department");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter your selection: ");
        Terminal.WriteLine("");
    }

    void OnUserInput(string userInput){
        if(currentScreen == Screen.MainMenu){
            RunMainMenu(userInput);
        }else if(currentScreen == Screen.LevelOne){
            RunLevelOne(userInput);
        }else if(currentScreen == Screen.LevelTwo){
            RunLevelTwo(userInput);
        }else if(currentScreen == Screen.LevelThree){
            RunLevelThree(userInput);
        }else{
            print("Whoah what happened");
        }
    }

    void StartGame(){
        if(this.level == "1"){
            this.currentScreen = Screen.LevelOne;
            Terminal.WriteLine("Guess the password: ");
        }else if(this.level == "2"){
            this.currentScreen = Screen.LevelTwo;
        }else if(this.level == "3"){
            this.currentScreen = Screen.LevelThree;
        }else if(this.level == "menu"){
            this.currentScreen = Screen.MainMenu;
            PrintWelcome(greeting);
        }else{
            Terminal.WriteLine("Please enter a valid choice");
        }
    }

    void RunMainMenu(string userInput){
        this.currentScreen = Screen.MainMenu;
        this.level = userInput;
        StartGame();
    }
    void RunLevelOne(string userInput){
        int index = Random.Range(0, levelOnePasswords.Length - 1);
        string password = levelOnePasswords[index];
        CheckPassword(password, userInput);
        
    }
    void RunLevelTwo(string userInput){
        int index = Random.Range(0, levelOnePasswords.Length - 1);
        string password = levelTwoPasswords[index];
        CheckPassword(password, userInput);
    }

    void RunLevelThree(string userInput){
        int index = Random.Range(0, levelOnePasswords.Length - 1);
        string password = levelThreePasswords[index];
        CheckPassword(password, userInput);
    }

    void CheckPassword(string password, string guess){
        if(guess == password){
            Terminal.WriteLine("You got it");
        }else if (guess == "menu"){
            PrintWelcome(greeting);
            this.currentScreen = Screen.MainMenu;
        }else{
            Terminal.WriteLine("You didn't get it");
        }
    }
}
