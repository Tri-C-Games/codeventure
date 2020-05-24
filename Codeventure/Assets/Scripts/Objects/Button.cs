using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private bool editable = false;

    [SerializeField]
    private GameObject doorObject;

    private Door door;

    [SerializeField]
    private Sprite sprite, editableSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        door = doorObject.GetComponent<Door>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (editable)
        {
            gameObject.tag = "Editable";
            spriteRenderer.sprite = editableSprite;
        }
        else
        {
            spriteRenderer.sprite = sprite;
        }
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