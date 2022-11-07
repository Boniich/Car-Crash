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
    inGame,
    endOfGame
}

public class GameManager : MonoBehaviour
{

    public static GameManager sharedInstance;
    public GameState currentGameState = GameState.startMenu;

    public Canvas startMenuCanvas;
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
        inGameCanvas.enabled = false;
        endOfGameCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(SpawnManager.sharedInstance.GetDestroyedObstaculeCount() == 0)
        {
            Debug.Log("No hay mas obtaculos. El juego termino!");
            EndGame();
        }
 

           
           

    }


    public void StartGame()
    {
        ChangeGameState(GameState.inGame);
        SpawnManager.sharedInstance.SpawnRandomObstacules();
        ViewInGame.sharedInstance.UpdateObstaculeCountText();
        ViewInGame.sharedInstance.UpdateMaxScoreText();
    }


    public void EndGame()
    {
        
        ChangeGameState(GameState.endOfGame);
        ViewEndOfGame.sharedInstance.UpdatePointsAtEndOfGame();
        ViewInGame.sharedInstance.SetMaxScoreText(points);
        ViewEndOfGame.sharedInstance.UpdateMaxScoreText();
    }

    public void PlayAgain()
    {
        SpawnManager.sharedInstance.ResetDestroyedObstaculeCount();
        PlayerController.sharedInstance.ResetPlayerPosition();
        StartGame();
        ResetPoints();
        
    }

    private void ResetPoints()
    {
        points = 0;
        ViewInGame.sharedInstance.UpdatePointLabel();
    }

    void ChangeGameState(GameState newGameState)
    {
        if(newGameState == GameState.startMenu)
        {
            startMenuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            endOfGameCanvas.enabled = false;
        }else if(newGameState == GameState.inGame)
        {
            startMenuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            endOfGameCanvas.enabled = false;
        }else if(newGameState == GameState.endOfGame)
        {
            startMenuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            endOfGameCanvas.enabled = true;
        }


        currentGameState = newGameState;
    }

    public void GainPoints(int pointsAmount)
    {
        points += pointsAmount;
        ViewInGame.sharedInstance.UpdatePointLabel();

    }

}
