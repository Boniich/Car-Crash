using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour
{
    public static ViewInGame sharedInstance;
    private SaveMaxScore maxScore = new SaveMaxScore();
    [SerializeField]  private TextMeshProUGUI scoreTextPoint;
    [SerializeField]  private TextMeshProUGUI maxScoreText;
    [SerializeField]  private TextMeshProUGUI obstaculeCountText;
    [SerializeField]  private TextMeshProUGUI resistenceCount;
    [SerializeField]  private TextMeshProUGUI impactDamage;
    private GameObject subResistentePanel;
    private GameObject resistenceIsFullWindow;
    private float timeToDisableResistenceIsFullWindow = 3f;
    private Image imageComponent;
    private Color impactColor = new Color(0.9333333f, 0.1176471f, 0.1176471f, 0.3921569f); //HEX: EE1E1E
    private Color recuperateColor = new Color(0f, 0.5019608f, 0.2156863f, 0.3921569f); //HEX: 008037
    private Color subResistencePanelInitialColor = new Color(0.2196078f, 0.2196078f, 0.2196078f, 0.3921569f); //HEX: 383838
    // Start is called before the first frame update

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        subResistentePanel = GameObject.FindGameObjectWithTag("SubResistencePanel");
        imageComponent = subResistentePanel.GetComponent<Image>();

        resistenceIsFullWindow = GameObject.FindGameObjectWithTag("ResistenceIsFullWindow");
        ToggleResistenceIsFullWindow(false);
    }

    /// <summary>
    /// Update the max score point in the view of inGame
    /// </summary>
    public void UpdateMaxScoreText()
    {
        maxScoreText.text = maxScore.GetMaxScoreString();
    }

    /// <summary>
    /// It show the obstacule that player has to destroy. Each time that she destroy one it is updated
    /// </summary>

    public void UpdateObstaculeCountText()
    {
        obstaculeCountText.text = SpawnManager.sharedInstance.GetDestroyedObstaculeCount().ToString();
    }

    /// <summary>
    /// Update the score points
    /// </summary>

    public void UpdatePointLabel()
    {

        if(GameManager.sharedInstance.GetGameState() == GameState.inGame)
        {
            scoreTextPoint.text = GameManager.sharedInstance.GetPoints().ToString();
        }
    }

    /// <summary>
    /// Update the resistence count each time that it is reduced
    /// </summary>

    public void UpdateResistenceCount()
    {
        resistenceCount.text = PlayerController.sharedInstance.Resistence.ToString();
    }
    /// <summary>
    /// Render each impact that player recive
    /// </summary>
    /// <param name="totalDamage">damege caused at momento to impact</param>

    public void UpdateImpactDamage(int totalImpactDamage)
    {

        ChangeColorSubResistencePanel(impactColor);
        impactDamage.text = "- " + totalImpactDamage.ToString();
    }

    /// <summary>
    /// Update the sub resistence panel when player recuperate resistence
    /// </summary>
    /// <param name="resistenceRecuperate"></param>

    public void UpdateRecuperateResistence(int resistenceRecuperate)
    {
        ChangeColorSubResistencePanel(recuperateColor);
        impactDamage.text = "+ " + resistenceRecuperate.ToString();
    }

    /// <summary>
    /// Reset values in sub resistence panel when is press the button of "play again"
    /// </summary>
    public void ResetSubResitencePanel()
    {
        ChangeColorSubResistencePanel(subResistencePanelInitialColor);
        impactDamage.text = "0";
    }

    /// <summary>
    /// Change the color of sub resistence panel
    /// </summary>
    /// <param name="color">color in which the panel will change</param>

    private void ChangeColorSubResistencePanel(Color color)
    {
        if (imageComponent.color != color)
        {
            imageComponent.color = color;
        }
    }

    /// <summary>
    /// Active or desactive the window that show if the resistence is full to use the recuperacion
    /// </summary>
    /// <param name="enabled"></param>

    public void ToggleResistenceIsFullWindow(bool enabled)
    {
        resistenceIsFullWindow.SetActive(enabled);
    }

    /// <summary>
    /// Corrutine: Wait 'x' time to disable the resistence is full window
    /// </summary>
    /// <returns></returns>

    public IEnumerator CloseResistenceIsfullWindow()
    {
        yield return new WaitForSeconds(timeToDisableResistenceIsFullWindow);
        ViewInGame.sharedInstance.ToggleResistenceIsFullWindow(false);
    }
}
