using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public GameObject door;
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Hello World!");
        door.GetComponent<Door>().Open();
    }
}
