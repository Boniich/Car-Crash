using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool enablePhysicsEngine;
    [Range(0, 50)]
    public float speed = 0.0f;
    [Range(0, 50)]
    public float turnSpeed = 0.0f;
    public LayerMask ground;

    public static PlayerController sharedInstance;
    private Rigidbody _rigidbody;
    private float horizontal, vertical;
    private Vector3 startPlayerPosition;
    


     void Awake()
    {
        sharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPlayerPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

   
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
  
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");

            if (enablePhysicsEngine)
            {

                
                if (vertical != 0)
                {
                    _rigidbody.AddForce(Vector3.forward * speed * vertical, ForceMode.Acceleration );

                }

                if (horizontal != 0)
                {
                    _rigidbody.AddTorque(Vector3.up * turnSpeed * horizontal, ForceMode.Acceleration);
                }

            }

            else
            {
                if (vertical != 0) transform.Translate(speed * Time.deltaTime * Vector3.forward * vertical);
                if (horizontal != 0) transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontal);
            }




        }

        
    }


    public void ResetPlayerPosition()
    {
        transform.position = startPlayerPosition;
    }


}
