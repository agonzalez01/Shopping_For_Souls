using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interact : MonoBehaviour
{

    float view = 100f; //Range for raycasts
    
    //References for the different objects in game
    public GameObject ScrollInteract1;
    public GameObject ActualScroll1;
    public GameObject KeyInteract1;

    public GameObject Scroll1;
    public GameObject Scroll2;
    public GameObject Scroll3;


    public GameObject ScrollInteract2;
    public GameObject ActualScroll2;
    public GameObject KeyInteract2;

    public GameObject ScrollInteract3;
    public GameObject ActualScroll3;
    public GameObject KeyInteract3;

    public GameObject KEY1;
    public GameObject KEY2;
    public GameObject KEY3;

    public GameObject DoorInteract;
    public GameObject NoKeys;
    public GameObject Winning;

    public GameObject backBtn;

    //Bools to check which scrolls and keys have been picked up
    bool scroll1 = false;
    bool scroll2 = false;
    bool scroll3 = false;

    bool keyPickedUp1 = false;
    bool keyPickedUp2 = false;
    bool keyPickedUp3 = false;



    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InteractWithRay();
    }


    public void InteractWithRay()
    {

        //Setting different layers for each scroll and key

        LayerMask mask1 = LayerMask.GetMask("Scroll1");
        LayerMask mask2 = LayerMask.GetMask("Scroll2");
        LayerMask mask3 = LayerMask.GetMask("Scroll3");

        LayerMask key1 = LayerMask.GetMask("Key1");
        LayerMask key2 = LayerMask.GetMask("Key2");
        LayerMask key3 = LayerMask.GetMask("Key3");

        LayerMask Door = LayerMask.GetMask("Door");






     
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * view, Color.red);

        
        //Checking for hits for all scrolls and keys
        bool hit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), view, mask1);

        if (hit)
        {

            ScrollInteract1.SetActive(true);

            if (Input.GetKey("e"))
            {
                backBtn.SetActive(true);
                Cursor.visible = true;

                Time.timeScale = 0;
                ActualScroll1.SetActive(true);
                ScrollInteract1.SetActive(false);

                scroll1 = true;

            }

        }

        else
        {
          //  Time.timeScale = 1;
            ScrollInteract1.SetActive(false);
            ActualScroll1.SetActive(false);
        }

        bool hit2 = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), view, key1);

        //Interacts for keys will only be activated if the respective scroll has been picked up
        if (hit2 & scroll1)
        {
            
             KeyInteract1.SetActive(true);

                if (Input.GetKeyDown("e"))
                {
                //Time.timeScale = 0;

                keyPickedUp1 = true;

                KEY1.SetActive(true);
                Scroll1.SetActive(false);

                }

        }

        else
            {
           // Time.timeScale = 1;
            KeyInteract1.SetActive(false);            
            }


        bool hit3 = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), view, mask2);

        if (hit3)
        {

            ScrollInteract2.SetActive(true);

            if (Input.GetKey("e"))
            {
                backBtn.SetActive(true);
                Cursor.visible = true;

                Time.timeScale = 0;
                ActualScroll2.SetActive(true);
                ScrollInteract2.SetActive(false);

                scroll2 = true;

            }

        }

        else
        {
           // Time.timeScale = 1;
            ScrollInteract2.SetActive(false);
            ActualScroll2.SetActive(false);
        }

        bool hit4 = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), view, key2);

        if (hit4 & scroll2)
        {

            KeyInteract1.SetActive(true);

            if (Input.GetKeyDown("e"))
            {
              //  Time.timeScale = 0;

                keyPickedUp2 = true;
                KEY2.SetActive(true);
                Scroll2.SetActive(false);

            }

        }

        else
        {
           // Time.timeScale = 1;
            KeyInteract2.SetActive(false);
        }

        bool hit5 = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), view, mask3);

        if (hit5)
        {

            ScrollInteract3.SetActive(true);

            if (Input.GetKey("e"))
            {
                backBtn.SetActive(true);
                Cursor.visible = true;

                Time.timeScale = 0;
                ActualScroll3.SetActive(true);
                ScrollInteract3.SetActive(false);

                scroll3 = true;

            }

        }

        else
        {
          //  Time.timeScale = 1;
            ScrollInteract3.SetActive(false);
            ActualScroll3.SetActive(false);
        }

        bool hit6 = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), view, key3);

        if (hit6 & scroll3)
        {

            KeyInteract3.SetActive(true);

            if (Input.GetKeyDown("e"))
            {
               // Time.timeScale = 0;

                keyPickedUp3 = true;
                KEY3.SetActive(true);
                Scroll3.SetActive(false);

            }

        }

        else
        {
           // Time.timeScale = 1;
            KeyInteract3.SetActive(false);
        }

        bool hit7 = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), view, Door); //Check for hit with the exit door

        
        if(hit7)
        {
            DoorInteract.SetActive(true);

            if (Input.GetKey("e"))
            {
                backBtn.SetActive(true);
                Cursor.visible = true;

                Time.timeScale = 0;

                DoorInteract.SetActive(false);

                if (keyPickedUp1 && keyPickedUp2 && keyPickedUp3) //If the player has picked up all keys, they win the game 
                {
                    NoKeys.SetActive(false);
                    Winning.SetActive(true);
                }


                else
                {
                    NoKeys.SetActive(true); //If they do not have all keys, activate UI to tell them to get all keys
                }
            }
        }

        else
        {
          //  Time.timeScale = 1;
            DoorInteract.SetActive(false);
            NoKeys.SetActive(false);
        }



    }


}
