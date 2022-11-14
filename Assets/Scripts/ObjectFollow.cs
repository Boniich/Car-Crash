using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset = new Vector3(0, 5, -6);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
