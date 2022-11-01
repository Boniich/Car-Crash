using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Range(0, 50)]
    public float speed = 0.0f;
    [Range(0, 50)]
    public float turnSpeed = 0.0f;
    private float horizontal, vertical;
    public LayerMask ground;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        


        // Debug.Log(vertical);
        //Debug.DrawRay(transform.position, Vector3.down * 100000.0f, Color.green);
        //if (IsOnTheFloor()) { Debug.Log("Toca"); } else { Debug.Log("No toca"); }
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            Debug.Log("Entra");

            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");

            if (vertical != 0) transform.Translate(speed * Time.deltaTime * Vector3.forward * vertical);
            if (horizontal != 0) transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontal);
        }

        
    }

    //does not work
    bool IsOnTheFloor()
    {
        
        if (Physics.Raycast(this.transform.position, Vector2.down, 100.0f, ground.value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
