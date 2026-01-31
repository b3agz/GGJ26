using System;
using John;
using UnityEngine;
using Object = System.Object;

public class lockingPoint : MonoBehaviour
{
    
    private GameObject whatToLock;

    private bool canLock = false;

    public string slotName;
    
    /// <summary>
    /// this is just to make moveing and managing them earies by making the sprits invisable
    /// the sprites are a visual indicator of the hit box is
    /// </summary>

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider2D;
    
    private void Start()
    { 
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        
        boxCollider2D.size = new Vector2(spriteRenderer.bounds.size.x, spriteRenderer.bounds.size.y);
        spriteRenderer.enabled = false;
        
    }
    
    //this need to be changed to however we are going to manage the pices 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null)
            return;
        
        if (other.CompareTag("costumeObject") && whatToLock == null && other.gameObject.GetComponent<itemHolder>().whatItemIs.Slot == slotName)
        {
            whatToLock = other.gameObject;
            canLock = true;
            Judger.Instance.AddItem(other.gameObject.GetComponent<itemHolder>().whatItemIs);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == null)
            return;
        
        
        if (other.CompareTag("costumeObject"))
        {
            whatToLock = null;
            canLock = false;
            Judger.Instance.RemoveItem(other.gameObject.GetComponent<itemHolder>().whatItemIs);
        }
    }

    private void FixedUpdate()
    {
        //my soal hurt this is on Fixed update but its quick and i'm not good enough at unity to make it better 
        if(canLock == true)
        {
            if (!whatToLock.GetComponent<dragging>().GetIsDragging())
            {
                whatToLock.transform.position = transform.position;
            }
        }
    }
}
