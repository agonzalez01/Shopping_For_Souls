using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyMusic : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Invoke("myMethod", 2f);
    }

    /*  void myMethod()
      {
          SceneManager.LoadScene("game");
          DontDestroyOnLoad(musicManager);
      } */
}
