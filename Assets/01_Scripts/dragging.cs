using UnityEngine;

public class dragging : MonoBehaviour
{
    [SerializeField] private bool isDragging = false;

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    
    void OnMouseDown()
    {
        isDragging = !isDragging;
    }
}
