using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {
  public Transform target;
  public Transform firePoint;
  public GameObject bullet;
  public AudioSource fireSound;
  public LayerMask detectPlayerMask;
  public LineRenderer lr;
  private const float range = 100;

    void Update() {
      transform.right = target.transform.position - transform.position;

      RaycastHit2D foundPlayer = Physics2D.Raycast(firePoint.position, firePoint.right, range, detectPlayerMask);

      if (foundPlayer) {
          Shoot();
      }
    }
    private void Shoot() {

        Instantiate(bullet, firePoint.position, firePoint.rotation);
        fireSound.Play();
    }
}
