using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public void Open()
    {
        var transformPosition = transform.position;
        transformPosition.y += 100;
    }
}
