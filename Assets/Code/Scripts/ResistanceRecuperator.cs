using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistanceRecuperator : MonoBehaviour
{

    [SerializeField] private int recuperateResistence;
    private int minResistenceToRecuperate = 99;
    private float timeObjectRotation = 30f;
    [SerializeField] private AudioClip resistenceRecuperateSound;
    private AudioSource _audioSource;
    private float timeSound = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(timeObjectRotation * Time.deltaTime * Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(PlayerController.sharedInstance.Resistence <= minResistenceToRecuperate)
            {
                _audioSource.PlayOneShot(resistenceRecuperateSound, 1);
                PlayerController.sharedInstance.Resistence += recuperateResistence;

                if(PlayerController.sharedInstance.Resistence > 100)
                {
                    PlayerController.sharedInstance.Resistence = 100;
                }

                StartCoroutine(TurnOffRecuperator());
                //gameObject.SetActive(false);

                ViewInGame.sharedInstance.UpdateResistenceCount();
                ViewInGame.sharedInstance.UpdateRecuperateResistence(recuperateResistence);

            }
            else
            {
               
                ViewInGame.sharedInstance.ToggleResistenceIsFullWindow(true);
                StartCoroutine(ViewInGame.sharedInstance.CloseResistenceIsfullWindow());
            }

        }
    }

    IEnumerator TurnOffRecuperator()
    {
        yield return new WaitForSeconds(timeSound);
        gameObject.SetActive(false);
    }
}
