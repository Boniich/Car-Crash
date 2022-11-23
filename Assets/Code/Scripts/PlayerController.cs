using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public static PlayerController sharedInstance;

    [Range(0, 50), SerializeField] private float speed = 0.0f;
    [Range(0, 50), SerializeField] private float turnSpeed = 0.0f;

    [SerializeField] private bool enablePhysicsEngine;


    [Space]

    [SerializeField] private float rightXRange;
    [SerializeField] private float leftXRange;
    [SerializeField] private float forwardZRange;
    [SerializeField] private float backZRange;

    private Rigidbody _rigidbody;
    private float horizontal, vertical;
    private Vector3 startPlayerPosition;
    private Vector3 recalculatePlayerPosition = new Vector3(0, 0, 0);



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

            RestrictPlayerMovement();

            if (enablePhysicsEngine)
            {

                
                if (vertical != 0)
                {
                    _rigidbody.AddForce(Vector3.forward * speed * vertical, ForceMode.Acceleration );

                }

                if (horizontal != 0)
                {
                    _rigidbody.AddForce(Vector3.up * speed * horizontal, ForceMode.Acceleration);
                    //_rigidbody.AddTorque(Vector3.up * turnSpeed * horizontal, ForceMode.Acceleration);
                }

            }else
            {
                if (vertical != 0) transform.Translate(speed * Time.deltaTime * Vector3.forward * vertical);
                if (horizontal != 0) transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontal);
            }




        }

        
    }

    /// <summary>
    /// Restrict player movement to keep she in specific positions
    /// </summary>


    private void RestrictPlayerMovement()
    {

        if (transform.position.x < -leftXRange) {

            recalculatePlayerPosition.Set(-leftXRange, transform.position.y, transform.position.z);

            transform.position = recalculatePlayerPosition;
        };

        if (transform.position.x > rightXRange) {

            recalculatePlayerPosition.Set(rightXRange, transform.position.y, transform.position.z);

            transform.position = recalculatePlayerPosition;


        };
        if (transform.position.z < -backZRange) {

            recalculatePlayerPosition.Set(transform.position.x, transform.position.y, -backZRange);

            transform.position = recalculatePlayerPosition;

        };

        if (transform.position.z > forwardZRange) {

            recalculatePlayerPosition.Set(transform.position.x, transform.position.y, forwardZRange);

            transform.position = recalculatePlayerPosition;

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
