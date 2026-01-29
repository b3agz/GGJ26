using System;
using UnityEngine;
using UnityEngine.UIElements;

public class dragging : MonoBehaviour
{
    [SerializeField] private bool isDragging = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public bool GetIsDragging()
    {
        return isDragging;
    }
    
    void FixedUpdate()
    {
        if (isDragging)
        {
            rb.MovePosition((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }
    
    private void OnMouseUp()
    {
        isDragging = false;
    }
}
