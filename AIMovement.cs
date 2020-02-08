using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{

    GameObject Flashlight;
    int MouseClicks = 0;

    
    bool freeze = false;
    bool slow = false;

    bool frozen = false;
    bool slowed = false;

  //  int freezeCandies = 0;
    int slowCandies = 0;
    int timesCaught = 0;

    public NavMeshAgent nav;
    public GameObject Smashbtn;
    public GameObject DeadMenu;
    public GameObject lights;

    bool DogActive = true;
    bool Caught = false;



    // Start is called before the first frame update
    void Start()
    {
        //Looking for plater object (flashlight)
        Flashlight = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        CandyManagement();
        
        if (Vector3.Distance(Flashlight.transform.position, nav.transform.position) < 1000 && !frozen && lights.activeInHierarchy) //if player comes within a distance less than 1000, dog chases
        {
            nav.destination = Flashlight.transform.position;
        }


        if (frozen /*&&  freezeCandies < 4*/) 
        {
            nav.speed = 1; //Setting speed of dog to one to freeze him
            StartCoroutine(ChaseAgain());
        }

        if(slowed && slowCandies < 4)
        {
            nav.speed = 80; //Setting speed of 80 to slow him down
            StartCoroutine(ResetSpeed());
        }

        if (Caught)
        {
            //If the dog catches the player, count teh clicks that the player does
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
            {
                MouseClicks++;
            }
        }

    }
    

    //Function called three seconds after the playing is caught
    IEnumerator Reactivate()
    {
        yield return new WaitForSecondsRealtime(3f);
        if (MouseClicks > 8 && timesCaught < 4) //Check if the player clicked enough amount of times and if they haven't been caught more than three times 
        {
            Time.timeScale = 1; //Unpaue the game
            Smashbtn.SetActive(false); //Deactivate the UI 
            timesCaught++;
            Caught = false;
            MouseClicks = 0;

            nav.speed = 10; //Slowing down the dog to give the player time to get away 
            yield return new WaitForSecondsRealtime(3f);
            nav.speed = 150;
        }
        else //If the player didn't click enough or has been caught more than three times, game will end
        {
            DeadMenu.SetActive(true);
            Cursor.visible = true;
            Smashbtn.SetActive(false);
        }
        yield return new WaitForSecondsRealtime(1f);

    }

    IEnumerator ChaseAgain()
    {
        yield return new WaitForSecondsRealtime(3f);
        nav.speed = 150; //Reset dog's speed after freezing
        frozen = false;
       // freezeCandies--;
    }

    IEnumerator ResetSpeed()
    {
        yield return new WaitForSecondsRealtime(6f);
        nav.speed = 150; //Reset speed after being slowed down
        slowed = false;
       // slowCandies--;
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Player")) //Checking for collision with player
        {
            Time.timeScale = 0; //Pause game
            Smashbtn.SetActive(true); //Activate UI
            DogActive = false;
            Caught = true;
            StartCoroutine(Reactivate());

        }

    }

    //Checking which power up is equipped, checking when it is used
    void CandyManagement()
    {
        if(Input.GetKey("1"))
        {
            freeze = true;
            slow = false;
        }

        if (Input.GetKey("2"))
        {
            freeze = false;
            slow = true;
        }

       /* if(freezeCandies > 4)
        {
            freeze = false;
            frozen = false;
        } */

        if(slowCandies > 4)
        {
            slowed = false;
            frozen = false;
        }

        if(freeze)
        {
            if(Input.GetMouseButtonDown(0) /*&& freezeCandies < 4*/)
            {
                frozen = true;
                slowed = false;
              //  freezeCandies++;
            }
        }

        if (slow)
        {
            if (Input.GetMouseButtonDown(0) && slowCandies < 4)
            {
                slowed = true;
                frozen = false;
                slowCandies++;
            }
        }


    }







    


}
