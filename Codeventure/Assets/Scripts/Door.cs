using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    
    public void Open()
    {
        transform.position = new Vector3(transform.position.x, 5f, transform.position.z); //the door is opening
    }

    public void Close()
    {
        transform.position = new Vector3(transform.position.x, 1.713078f, transform.position.z); // the door is closing
    }
}
