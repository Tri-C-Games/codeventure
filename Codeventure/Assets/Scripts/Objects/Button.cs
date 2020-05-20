using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject doorObject;

    private Door door;

    private void Start()
    {
        door = doorObject.GetComponent<Door>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        door.Open();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        door.Close();
    }
}