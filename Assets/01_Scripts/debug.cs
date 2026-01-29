using UnityEngine;

public class debug : MonoBehaviour
{
    //this is for anything we need to make makeing the game faster remember to remove when shipping
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
