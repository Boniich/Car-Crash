using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController sharedInstance;

    [Range(0, 50), SerializeField] private float speed = 0.0f;
    [Range(0, 50), SerializeField] private float turnSpeed = 0.0f;

    [SerializeField] private bool enablePhysicsEngine;
    
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

   
        if (GameManager.sharedInstance.GetGameState() == GameState.inGame)
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

    /// <summary>
    /// Reset the player position 
    /// </summary>

    public void ResetPlayerPosition()
    {
        transform.position = startPlayerPosition;
    }


}
