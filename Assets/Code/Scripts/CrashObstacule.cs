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

    private int ObstaculePoints { get { return obstaculePoints; } }
    private TextMeshPro PointsLabel { get { return pointsLabel; } }

    private int ImpactDamage { get => impactDamage;}


    private int TotalImpactDamage { get => totalImpactDamage; set => totalImpactDamage = value; }



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
            Invoke("DestroyObject", 0.9f);
        }
    }

    /// <summary>
    /// Destroy and update UI after each time time that an object is destroyed
    /// </summary>

    private void DestroyObject()
    {
        
        ReduceResistence();
        Destroy(gameObject);
        SpawnManager.sharedInstance.ObstaculeDiscount();
        GameManager.sharedInstance.GainPoints(ObstaculePoints);
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
