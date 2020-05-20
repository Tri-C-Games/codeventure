using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Button Pressed.");
        door.GetComponent<Door>().open();
    }
}