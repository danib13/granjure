using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuState : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // return since there is no KeyCode.Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // remove the menu once we read it. it will only pop up 1 time at the start of the game.
            SceneManager.UnloadSceneAsync("OpeningState");
        }
    }
}
