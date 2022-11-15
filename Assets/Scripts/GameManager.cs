using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ideally our game should be 4 states, but for now it only will have 3
// 1- start menu
// 2- select car
// 3- InGame
// 4- End of game


public enum GameState
{
    startMenu,
    //carSelect,
    optionMenu,
    inGame,
    endOfGame
}

public class GameManager : MonoBehaviour
{

    public static GameManager sharedInstance;
    public GameState currentGameState = GameState.startMenu;
    public Canvas startMenuCanvas;
    public Canvas optionMenu;
    public Canvas inGameCanvas;
    public Canvas endOfGameCanvas;
    public int points = 0;


    private void Awake()
    {
        sharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameState.startMenu;
        startMenuCanvas.enabled = true;
        optionMenu.enabled = false;
        inGameCanvas.enabled = false;
        endOfGameCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (SpawnManager.sharedInstance.GetDestroyedObstaculeCount() == 0)
        {
            EndGame();
        }

    }

    /// <summary>
    /// Start the game when player press the button "Start"
    /// </summary>
    public void StartGame()
    {
        ChangeGameState(GameState.inGame);
        SpawnManager.sharedInstance.SpawnRandomObstacules();
        ViewInGame.sharedInstance.UpdateObstaculeCountText();
        ViewInGame.sharedInstance.UpdateMaxScoreText();
    }


    public void OpenOptionMenu()
    {
        ChangeGameState(GameState.optionMenu);
    }

    /// <summary>
    /// It change the state of game to "end of game" when obstacule is equal to zero
    /// Update the max socre if is necessary
    /// </summary>

    public void EndGame()
    {

        ChangeGameState(GameState.endOfGame);
        ViewEndOfGame.sharedInstance.UpdatePointsAtEndOfGame();
        ViewInGame.sharedInstance.SetMaxScoreText(points);
        ViewEndOfGame.sharedInstance.UpdateMaxScoreText();
    }

    /// <summary>
    /// Reset the game when player press the button "playe again"
    /// </summary>

    public void PlayAgain()
    {
        SpawnManager.sharedInstance.ResetDestroyedObstaculeCount();
        PlayerController.sharedInstance.ResetPlayerPosition();
        StartGame();
        ResetPoints();

    }

    /// <summary>
    /// Reset the point for each gameplay
    /// </summary>

    private void ResetPoints()
    {
        points = 0;
        ViewInGame.sharedInstance.UpdatePointLabel();
    }

    /// <summary>
    /// Handle the state of different game's view
    /// </summary>
    /// <param name="newGameState">It recive the new status that should be change</param>

    void ChangeGameState(GameState newGameState)
    {
        if (newGameState == GameState.startMenu)
        {
            
            startMenuCanvas.enabled = true;
            optionMenu.enabled = false;
            inGameCanvas.enabled = false;
            endOfGameCanvas.enabled = false;
            
           

        } else if (newGameState == GameState.optionMenu) {

            startMenuCanvas.enabled = false;
            optionMenu.enabled = true;
            inGameCanvas.enabled = false;
            endOfGameCanvas.enabled = false;

        } else if (newGameState == GameState.inGame)
        {
            startMenuCanvas.enabled = false;
            optionMenu.enabled = false;
            inGameCanvas.enabled = true;
            endOfGameCanvas.enabled = false;
        } else if (newGameState == GameState.endOfGame)
        {
            startMenuCanvas.enabled = false;
            optionMenu.enabled = false;
            inGameCanvas.enabled = false;
            endOfGameCanvas.enabled = true;
        }


        currentGameState = newGameState;
    }



    /// <summary>
    /// Incress the score point in code
    /// </summary>
    /// <param name="pointsAmount">Recibe diferent value depedding to value of obstacule</param>
    public void GainPoints(int pointsAmount)
    {
        points += pointsAmount;
        ViewInGame.sharedInstance.UpdatePointLabel();

    }

}
