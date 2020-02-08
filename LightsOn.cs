using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOn : MonoBehaviour
{

    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;

    // Update is called once per frame
    void Update()
    {
        lights();
    }

    //Turning flashlight on and off with the f key
    void lights()
    {    
            if(Input.GetKeyDown("f"))
            {
                if (Light1.activeInHierarchy)
                {
                    Light1.SetActive(false);
                    Light2.SetActive(false);
                    Light3.SetActive(false);
                }

                else
                {
                    Light1.SetActive(true);
                    Light2.SetActive(true);
                    Light3.SetActive(true);
                }

            }

            
            
        
    }
}
