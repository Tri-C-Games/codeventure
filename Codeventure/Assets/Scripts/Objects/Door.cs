using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool editable;

    [SerializeField]
    private Sprite openSprite, closedSprite, editableOpenSprite, editableClosedSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = editable ? editableClosedSprite : closedSprite;
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
