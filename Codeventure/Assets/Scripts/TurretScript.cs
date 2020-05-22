using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform target;
    public Transform firePoint;
    public GameObject bullet;
    public AudioSource fireSound;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right);
        Quaternion rotation = Quaternion.LookRotation
            (target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        if (hit && hit.collider.name == "Player")
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        fireSound.Play(0);
    }
}