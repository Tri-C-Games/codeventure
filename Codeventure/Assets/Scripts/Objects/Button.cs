using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private bool editable;

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

        spriteRenderer.sprite = editable ? editableSprite : sprite;
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