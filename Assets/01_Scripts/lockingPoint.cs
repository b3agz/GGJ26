using System;
using UnityEngine;
using Object = System.Object;

public class lockingPoint : MonoBehaviour
{
    
    private GameObject whatToLock;

    private bool canLock = false;
    
    
    //this need to be changed to however we are going to manage the pices 
    private int whatCanLock = 0;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("costumeObject") && whatToLock == null && 
            other.gameObject.GetComponent<objectType>().costumneObjectType == whatCanLock)
        {
            whatToLock = other.gameObject;
            canLock = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("costumeObject"))
        {
            whatToLock = null;
            canLock = false;
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
