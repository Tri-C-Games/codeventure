using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {
  public Transform target;
  public Transform firePoint;
  public GameObject bullet;

    void Update() {
      RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right);
      Quaternion rotation = Quaternion.LookRotation
          (target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
      transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

      if(hit) {
        if(hit.collider.name == "Player"){
          Shoote();
        }}
      }
      public void Shoote() {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
      }
    }
