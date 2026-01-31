using John;
using UnityEngine;

public class itemHolder : MonoBehaviour
{
    public Item whatItemIs;
    
    private SpriteRenderer spriteRenderer;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = whatItemIs.Image;
    }
}
