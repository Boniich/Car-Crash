using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrashObstacule : MonoBehaviour
{
   
     [SerializeField] private int obstaculePoints;
     [SerializeField] private int impactDamage;
     private int totalImpactDamage = 0;
     int[] randomDamageValues = { 0, 3 };
     public AudioClip addPointsSound;
     private AudioSource _audioScource;
     private PoweUp poweUp = new PoweUp();
     private PowerDown powerDown = new PowerDown();
     private bool activePoweUp;
     private bool activePowerDown;
     private float destroyObjectTime = 0.9f;
     private bool used;

    private int ObstaculePoints { get { return obstaculePoints; } }

    private int ImpactDamage { get => impactDamage;}


    private int TotalImpactDamage { get => totalImpactDamage; set => totalImpactDamage = value; }

    public bool ActivePoweUp { get => activePoweUp; set => activePoweUp = value; }

    public bool ActivePowerDown { get => activePowerDown; set => activePowerDown = value; }

    private void Start()
    {
        _audioScource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
    
        if (collision.tag == "Player" && !used)
        {
            _audioScource.PlayOneShot(addPointsSound, 1);

            if (ActivePoweUp)
            {
                int points = poweUp.DuplicatePoints(obstaculePoints);
                ViewInGame.sharedInstance.ShowPowerUp();
                StartCoroutine(DestroyObject(points));
            } else if (ActivePowerDown) 
            {
                int points = powerDown.DontAddPoints();
                ViewInGame.sharedInstance.ShowPowerDown();
                StartCoroutine(DestroyObject(points));
            }
            else
            {
                StartCoroutine(DestroyObject(ObstaculePoints));
            }

            used = true;
        }
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
        ViewInGame.sharedInstance.ShowObstaculePoints(points);
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
