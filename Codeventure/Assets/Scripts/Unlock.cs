using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour {
    public GameObject door;
    void OnTriggerEnter(Collider collider) {
        door.GetComponent<Door>().Open();
    }

    private void OnTriggerExit(Collider colider)
    {
         door.GetComponent<Door>().Close();
    }
}
