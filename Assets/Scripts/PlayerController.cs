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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        Debug.Log(vertical);

        if(vertical != 0 ) transform.Translate(speed * Time.deltaTime * Vector3.forward * vertical);
        if (horizontal != 0) transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontal);
        
    }
}
