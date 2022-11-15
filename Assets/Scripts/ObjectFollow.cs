using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{

    [SerializeField]  private GameObject player;
    [SerializeField]  private Vector3 offset = new Vector3(0, 5, -6);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
