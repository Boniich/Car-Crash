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
    private Animator _animator;
    private bool used;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(timeObjectRotation * Time.deltaTime * Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && used == false)
        {
            if(PlayerController.sharedInstance.Resistence <= minResistenceToRecuperate)
            {
                _audioSource.PlayOneShot(resistenceRecuperateSound, 1);
                PlayerController.sharedInstance.Resistence += recuperateResistence;

                if(PlayerController.sharedInstance.Resistence > 50)
                {
                    PlayerController.sharedInstance.Resistence = 50;
                }

                used = true;
                ToogleAnimacionRecuperator(true);
                StartCoroutine(TurnOffRecuperator());

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
    /// <summary>
    /// Active o desactive resistence recuperator
    /// </summary>
    /// <param name="toggle"></param>
    private void ToggleResistenceRecuperator(bool toggle)
    {
        gameObject.SetActive(toggle);
    }

    /// <summary>
    /// Active or desactive animation of resistence recuperator
    /// </summary>
    /// <param name="toggle"></param>

    private void ToogleAnimacionRecuperator(bool toggle)
    {
        _animator.enabled = toggle;
    }

    /// <summary>
    /// Active the resistence recuperator for after press "play again"
    /// </summary>

    public void ActiveResistenceRecuperator()
    {
        ToggleResistenceRecuperator(true);
        ToogleAnimacionRecuperator(false);
    }

    /// <summary>
    /// Corrutine: turn off the object of resistence recuperator after it us used
    /// </summary>
    /// <returns></returns>

    IEnumerator TurnOffRecuperator()
    {
        yield return new WaitForSeconds(timeSound);
        ToggleResistenceRecuperator(false);
        used = false;
    }
}
