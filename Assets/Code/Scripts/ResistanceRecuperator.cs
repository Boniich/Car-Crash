using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistanceRecuperator : MonoBehaviour
{

    [SerializeField] private int recuperateResistence;
    private int minResistenceToRecuperate = 99;
    private float timeObjectRotation = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
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
                
                PlayerController.sharedInstance.Resistence += recuperateResistence;

                if(PlayerController.sharedInstance.Resistence > 100)
                {
                    PlayerController.sharedInstance.Resistence = 100;
                }
                gameObject.SetActive(false);

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
}
