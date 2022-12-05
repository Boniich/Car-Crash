using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrashObstacule : MonoBehaviour
{
   
     [SerializeField] private int obstaculePoints;
     [SerializeField] private TextMeshPro pointsLabel;
     [SerializeField] private int impactDamage;
     private int totalImpactDamage = 0;
     int[] randomDamageValues = { 0, 3 };
     public AudioClip addPointsSound;
     private AudioSource _audioScource;
     private PoweUp poweUp = new PoweUp();
     [SerializeField] private bool activePoweUp;
     private float destroyObjectTime = 0.9f;
     private Color powerUpColor = Color.green;

    private int ObstaculePoints { get { return obstaculePoints; } }
    private TextMeshPro PointsLabel { get { return pointsLabel; } }

    private int ImpactDamage { get => impactDamage;}


    private int TotalImpactDamage { get => totalImpactDamage; set => totalImpactDamage = value; }

    public bool ActivePoweUp { get => activePoweUp; set => activePoweUp = value; }

    private void Start()
    {
        PointsLabel.text = ObstaculePoints.ToString();
        PointsLabel.enabled = false;
        _audioScource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
    
        if (collision.tag == "Player")
        {
            if(PointsLabel.enabled == false)
            {
                _audioScource.PlayOneShot(addPointsSound, 1);
            }
            PointsLabel.enabled = true;

            if (ActivePoweUp)
            {
                int points = poweUp.DuplicatePoints(obstaculePoints);
                string labelAfterPowerUp = $"{points} ({ObstaculePoints} x 2)";
                UpdatePointsLabel(labelAfterPowerUp, powerUpColor);
                StartCoroutine(DestroyObject(points));
            }
            else
            {
                StartCoroutine(DestroyObject(ObstaculePoints));
            }

            
        }
    }

    /// <summary>
    /// Update points label of obstacule that get a power up or power down
    /// </summary>
    /// <param name="newText">new text that will be rendered after active power up/down</param>
    /// <param name="color">new color that will be rendered after active power up/down</param>

    private void UpdatePointsLabel(string newText, Color color)
    {
        PointsLabel.text = newText;
        PointsLabel.color = color;
    }


    /// <summary>
    /// Destroy and update UI after each time time that an object is destroyed
    /// </summary>

    IEnumerator DestroyObject(int points)
    {
        yield return new WaitForSeconds(destroyObjectTime);
        ReduceResistence();
        Destroy(gameObject);
        SpawnManager.sharedInstance.ObstaculeDiscount();
        GameManager.sharedInstance.GainPoints(points);
        ViewInGame.sharedInstance.UpdateObstaculeCountText();
        ViewInGame.sharedInstance.UpdateResistenceCount();
        ViewInGame.sharedInstance.UpdateImpactDamage(TotalImpactDamage);
    }


    /// <summary>
    /// Reduce resistence of car each time that player impact with and object
    /// </summary>

    private void ReduceResistence()
    {
        int resistence = PlayerController.sharedInstance.Resistence;
        int randomImpactDamage = Random.Range(randomDamageValues[0], randomDamageValues[1]);
        TotalImpactDamage = ImpactDamage + randomImpactDamage;

        if((resistence -= TotalImpactDamage) <= 0)
        {
            PlayerController.sharedInstance.Resistence = 0;
        }
        else
        {
            PlayerController.sharedInstance.Resistence -= TotalImpactDamage;
        }
    }


}
