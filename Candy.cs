using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Candy : MonoBehaviour
{
    //References to UI in game
    public GameObject Freeze;   
    public GameObject Slow;

    //Setting candy as equipped s
    public bool FreezeEquipped = false;
    public bool SlowEquipped = false;

    // Update is called once per frame
    void Update()
    {
        PowerUps();
    }

    public void PowerUps()
    {
        //UI gets bigger depending on the chosen power up
        if(Input.GetKey("1"))
        {
            FreezeEquipped = true;
            Slow.transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);

            Freeze.transform.localScale = new Vector3(0.5116256f, 0.4337046f, 0.5f);
            SlowEquipped = false;
        }

        if (Input.GetKey("2"))
        {
            SlowEquipped = true;
            Freeze.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            Slow.transform.localScale = new Vector3(0.5116256f, 0.4337046f, 0.5f);
            FreezeEquipped = false;
        }
        
    }
}
