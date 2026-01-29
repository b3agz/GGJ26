using System;
using John;
using UnityEngine;
using Object = System.Object;

public class lockingPoint : MonoBehaviour
{
    
    private GameObject whatToLock;

    private bool canLock = false;

    public string slotName;
    
    //this need to be changed to however we are going to manage the pices 



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("costumeObject") && whatToLock == null && other.gameObject.GetComponent<itemHolder>().whatItemIs.Slot == slotName)
        {
            whatToLock = other.gameObject;
            canLock = true;
            Judger.Instance.AddItem(other.gameObject.GetComponent<itemHolder>().whatItemIs);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
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
