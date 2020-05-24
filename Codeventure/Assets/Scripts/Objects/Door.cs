using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool editable = false;

    [SerializeField]
    private Sprite openSprite, closedSprite, editableOpenSprite, editableClosedSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (editable)
        {
            gameObject.tag = "Editable";
            spriteRenderer.sprite = editableClosedSprite;
        }
        else
        {
            spriteRenderer.sprite = closedSprite;
        }
    }

    public void Open()
    {
        spriteRenderer.sprite = editable ? editableOpenSprite : openSprite;
    }

    public void Close()
    {
        spriteRenderer.sprite = editable ? editableClosedSprite : closedSprite;
    }
}
