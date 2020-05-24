using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform target;
    public Transform firePoint;
    public GameObject bullet;
    public AudioSource fireSound;

    public LayerMask detectPlayerMask;

    public float shootCooldown;

    private const float range = 100;

    private float shootCooldownTimer;

    private void Update()
    {
        transform.right = target.transform.position - transform.position;

        RaycastHit2D foundPlayer = Physics2D.Raycast(firePoint.position, firePoint.right, range, detectPlayerMask);

        if (foundPlayer && shootCooldownTimer <= 0)
        {
            Shoot();
        }

        shootCooldownTimer -= Time.deltaTime;
    }

    private void Shoot()
    {
        shootCooldownTimer = shootCooldown;

        Instantiate(bullet, firePoint.position, firePoint.rotation);
        fireSound.Play();
    }
}
