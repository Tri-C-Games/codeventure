using System.Runtime.CompilerServices;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform target;
    public Transform firePoint;
    public GameObject bullet;
    public AudioSource fireSound;

    public LayerMask detectPlayerMask;

    const float range = 100;

    void Update()
    {
        RaycastHit2D foundPlayer = Physics2D.Raycast(firePoint.position, firePoint.right, range, detectPlayerMask);
        Quaternion rotation = Quaternion.LookRotation
            (target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        if (foundPlayer)
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        fireSound.Play();
    }
}