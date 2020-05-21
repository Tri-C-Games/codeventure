using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {
  public Transform target;

    void Update() {
      Quaternion rotation = Quaternion.LookRotation
          (target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
      transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}
