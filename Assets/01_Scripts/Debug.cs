using UnityEngine;

public class Debug : MonoBehaviour
{
    //this is just to throw some debug stuff we may need for dev stuff make sure to remove before shipping
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
