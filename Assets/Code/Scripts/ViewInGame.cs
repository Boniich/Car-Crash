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
    private Image imageComponent;
    private Color impactColor = new Color(0.9333333f, 0.1176471f, 0.1176471f, 0.3921569f); //HEX: EE1E1E
    // Start is called before the first frame update

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        subResistentePanel = GameObject.FindGameObjectWithTag("SubResistencePanel");

        imageComponent = subResistentePanel.GetComponent<Image>();
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

    public void UpdateImpactDamage(int totalDamage)
    {
 
        if (imageComponent.color != impactColor)
        {
            imageComponent.color = impactColor;
        }
        
        impactDamage.text = "- " + totalDamage.ToString();
    }
}
