using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}