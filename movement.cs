using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 100f;
    public GameObject PauseMenu;

    public AudioSource run;
    public AudioSource walk;

    bool running = false;
    bool walking = false;


    private Rigidbody Flashlight;
    
    
    void Start()
    {
        Flashlight = GetComponent<Rigidbody>();
        
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Playing sounds depending on player walking or running

        if(Input.GetKeyDown("w") && !Input.GetKey(KeyCode.LeftShift))
        {
            walk.Play();
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKeyUp("w"))
        {
            walk.Stop();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            run.Play();
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKey("w"))
        {
            walk.Play();
        }

        if (Input.GetKeyUp("w") || Input.GetKeyUp(KeyCode.LeftShift))
        {
            run.Stop();
        }


        //Movement with left shift (running)
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
         {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed * 2.3f;

        }
        //Walking
         else if(Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift))
         {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed * 1.8f;
           
        }

         if (Input.GetKey("s"))
         {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed * -1.3f;

           
         }

         if (Input.GetKey("d"))
         {
            transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * speed * 1.3f;
          
         }

         if (Input.GetKey("a"))
         {
            transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * speed * -1.3f;
            
         } 


        //Rotation with mouse
        if (Input.GetAxis("Mouse X")>0)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 170f);
        }
        if (Input.GetAxis("Mouse X")<0)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * (-170f));
        }


        //Pause menu  
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            Cursor.visible = true;
        }



    }
}
