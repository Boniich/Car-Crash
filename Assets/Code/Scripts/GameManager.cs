
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    endOfGame,
    pauseMenu,
    gameOver
}

public class GameManager : MonoBehaviour
{

    public static GameManager sharedInstance;
    [SerializeField]  private GameState currentGameState = GameState.startMenu;
    private GameState prevGameState;
    private SaveMaxScore maxScore = new SaveMaxScore();
    private SaveAudioProcess audioProcess = new SaveAudioProcess();
    private Points points = new Points();
    [SerializeField]  private Canvas startMenuCanvas;
    [SerializeField]  private Canvas optionMenu;
    [SerializeField]  private Canvas inGameCanvas;
    [SerializeField]  private Canvas endOfGameCanvas;
    [SerializeField]  private Canvas pauseMenu;
    [SerializeField]  private Canvas gameOverViewCanvas;
    private bool breakEndGame;
    private bool breakGameOver;
    private bool notAddToMaxScore = false;
    private AudioSource myAudio;
    private Scrollbar myScrollBar;
    private Toggle myToggle;
    private ResistanceRecuperator resistenceRecuperator;
    private PowerManager powerManager;
    private Timer timer;


    private bool BreakEndGame { get => breakEndGame; set => breakEndGame = value; }

    private bool BreakGameOver { get => breakGameOver; set => breakGameOver = value; }

    private GameState PrevGameState { get => prevGameState; set => prevGameState = value; }

    private bool NotAddToMaxScore { get => notAddToMaxScore; set => notAddToMaxScore = value; }
    private void Awake()

    {
        sharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameState.startMenu;
        myAudio = Camera.main.GetComponent<AudioSource>();
        myScrollBar = optionMenu.GetComponentInChildren<Scrollbar>();
        myToggle = optionMenu.GetComponentInChildren<Toggle>();
        myScrollBar.value = audioProcess.LoadScrollBackgroundMusic();
        myAudio.volume = audioProcess.LoadScrollBackgroundMusic();
        resistenceRecuperator = FindObjectOfType<ResistanceRecuperator>();
        powerManager = FindObjectOfType<PowerManager>();
        timer = FindObjectOfType<Timer>();
        HandleViewActivation();
    }

    // Update is called once per frame
    void Update()
    {

        if((PlayerController.sharedInstance.Resistence == 0 || timer.GetEndTimer()) && BreakGameOver == false)
        {
            GameOver();
        }
        
        if (SpawnManager.sharedInstance.GetDestroyedObstaculeCount() == 0 && BreakEndGame == false)
        {
            EndGame();
        }

    }
    /// <summary>
    /// Exit from game
    /// </summary>
    public void Exit()
    {
        Application.Quit();
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
        ViewInGame.sharedInstance.UpdateResistenceCount();
        NotAddToMaxScore = false;
        powerManager.AddObstaculesToList();
        powerManager.AddPowerUp();
        powerManager.AddPowerDown();
        timer.StartTimer();
    }

    /// <summary>
    /// This function is called when a player press the button back in the option menu.
    /// </summary>

    public void ComeBackToStarMenu()
    {
        if(PrevGameState == GameState.endOfGame)
        {
            ChangeGameState(GameState.endOfGame);
            BreakEndGame = false;
        }
        else if(PrevGameState == GameState.inGame)
        {
            ChangeGameState(GameState.pauseMenu);
        } 
        else if (PrevGameState == GameState.gameOver)
        {
            ChangeGameState(GameState.gameOver);
            BreakGameOver = false;
        }
        else
        {
            ChangeGameState(GameState.startMenu);
        }

        
    }

    /// <summary>
    /// Call the method to change state with option menu state
    /// </summary>


    public void OpenOptionMenu()
    {
        if (GetGameState() == GameState.endOfGame)
        {
            PrevGameState = GameState.endOfGame;
            BreakEndGame = true;
        }else if(GetGameState() == GameState.gameOver)
        {
            PrevGameState = GameState.gameOver;
            BreakGameOver = true;
        }

        ChangeGameState(GameState.optionMenu);
    }

    /// <summary>
    /// It change the state of game to "end of game" when obstacule is equal to zero
    /// Update the max socre if is necessary
    /// </summary>

    public void EndGame()
    {
        timer.PauseTimer();
        ChangeGameState(GameState.endOfGame);
        ViewEndOfGame.sharedInstance.UpdatePointsAtEndOfGame();
        if (!NotAddToMaxScore)
        {
            maxScore.SetMaxScoreValue(points.GetPoints());
        }
        
        ViewEndOfGame.sharedInstance.UpdateMaxScoreText();
    }

    /// <summary>
    /// Reset the game when player press the button "playe again"
    /// </summary>

    public void PlayAgain()
    {
        timer.RestartTimer();
        SpawnManager.sharedInstance.DestroyAllOldObstacules();
        SpawnManager.sharedInstance.ResetDestroyedObstaculeCount();
        PlayerController.sharedInstance.ResetPlayerPosition();
        PlayerController.sharedInstance.ResetResistence();
        ViewInGame.sharedInstance.ResetSubResitencePanel();
        ViewInGame.sharedInstance.ResetObstaculePoints();
        ViewInGame.sharedInstance.ResetPowerView();
        StartGame();
        points.ResetPoints();
        resistenceRecuperator.ActiveResistenceRecuperator();
        

    }

    /// <summary>
    /// Return the current state of game
    /// </summary>
    /// <returns></returns>

    public GameState GetGameState()
    {
        return currentGameState;
    }

    /// <summary>
    /// Change the state of game at GameOver
    /// </summary>
    private void GameOver()
    {
        timer.PauseTimer();
        gameOverViewCanvas.GetComponent<GameOverView>().ShowEndTimeSubText();
        gameOverViewCanvas.GetComponent<GameOverView>().ShowLostAllResistenceSubText();
        ChangeGameState(GameState.gameOver);
    }


    /// <summary>
    /// Handle the state of different game's view
    /// </summary>
    /// <param name="newGameState">It recive the new status that should be change</param>

    void ChangeGameState(GameState newGameState)
    {
        if (newGameState == GameState.startMenu)
        {

            HandleViewActivation();

        } else if (newGameState == GameState.optionMenu) {

            HandleViewActivation(startMenu:false,optionMenu:true,inGameMenu:false,endOfGameMenu:false);

        } else if (newGameState == GameState.inGame)
        {
            HandleViewActivation(startMenu: false, optionMenu: false, inGameMenu: true, endOfGameMenu: false);

        } else if (newGameState == GameState.endOfGame)
        {
            HandleViewActivation(startMenu: false, optionMenu: false, inGameMenu: false, endOfGameMenu: true);
        } else if(newGameState == GameState.pauseMenu)
        {
            HandleViewActivation(startMenu: false, optionMenu: false, inGameMenu: false, endOfGameMenu: false, pauseMenu: true);
        }else if(newGameState == GameState.gameOver)
        {
            HandleViewActivation(startMenu: false, optionMenu: false, inGameMenu: false, endOfGameMenu: false, pauseMenu: false, gameOverCanvas: true);
        }


        currentGameState = newGameState;
    }
    


    /// <summary>
    /// Handle the enabled and disabled of all different views in all moments necessary
    /// </summary>
    /// <param name="startMenu">determinate if startMenu is enabled o disabled.By default it is true</param>
    /// <param name="optionMenu">determinate if optionMenu is enabled o disabled.By default it is false</param>
    /// <param name="inGameMenu">determinate if inGame view is enabled o disabled.By default it is false</param>
    /// <param name="endOfGameMenu">determinate if end of game view is enabled o disabled.By default it is false</param>

    private void HandleViewActivation(bool startMenu = true, bool optionMenu = false, bool inGameMenu = false, 
        bool endOfGameMenu = false,bool pauseMenu = false, bool gameOverCanvas = false)
    {
        startMenuCanvas.enabled = startMenu;
        this.optionMenu.enabled = optionMenu;
        inGameCanvas.enabled = inGameMenu;
        endOfGameCanvas.enabled = endOfGameMenu;
        this.pauseMenu.enabled = pauseMenu;
        this.gameOverViewCanvas.enabled = gameOverCanvas;
    }
    /// <summary>
    /// Return the value of variable points
    /// </summary>
    /// <returns></returns>

    public int GetPoints()
    {
        return points.GetPoints();
    }

    /// <summary>
    /// Incress the score point in code
    /// </summary>
    /// <param name="pointsAmount">Recibe diferent value depedding to value of obstacule</param>
    public void GainPoints(int pointsAmount)
    {
        points.GainPoints(pointsAmount);
    }

    /// <summary>
    /// Reset the maxScore
    /// </summary>

    public void ResetMaxScore()
    {
            maxScore.ResetMaxScore();

            if (PrevGameState == GameState.endOfGame)
            {
                ViewEndOfGame.sharedInstance.UpdateMaxScoreText();
                NotAddToMaxScore = true;
            }

            PopupManager.sharedInstance.ToggleMaxScoreResetWindow(false);
            PopupManager.sharedInstance.ToggleSuccefullResetWindow(true);
            ViewInGame.sharedInstance.UpdateMaxScoreText();
    }


    /// <summary>
    /// Handle the volumen of background music using the scroll bar
    /// </summary>

    public void ScrollMusicVolumen()
    {
        myAudio.volume = myScrollBar.value;
        audioProcess.SaveScrollBackgroundMusic(myAudio.volume);
    }

    /// <summary>
    /// Change the state to play after use pause menu
    /// </summary>

    public void ComeBackToPlay()
    {
        timer.StartTimer();
        ChangeGameState(GameState.inGame);
        
    }


    /// <summary>
    /// Open and close pause menu with ESC
    /// </summary>

    public void TogglePauseMenu()
    {
        if (GetGameState() == GameState.inGame || GetGameState() == GameState.pauseMenu)
        {
 
                if (GetGameState() != GameState.pauseMenu)
                {
                    ChangeGameState(GameState.pauseMenu);
                    PrevGameState = GameState.inGame;
                    timer.PauseTimer();

                }
                else if (GetGameState() == GameState.pauseMenu)
                {

                    if(PopupManager.sharedInstance.ReturnPauseExitPopupState() == false)
                    {
                        ComeBackToPlay();
                    }
                    else
                    {
                        PopupManager.sharedInstance.ClosePauseExitPopup();
                    }
                }

        }
    }
}
