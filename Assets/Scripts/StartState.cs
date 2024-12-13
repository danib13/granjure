using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartState : MonoBehaviour
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
            // async so that we can load both. if it was normal loadscene the second loadscene would be ignored since it would already jump to farmscene
            SceneManager.LoadSceneAsync("FarmScene");
            SceneManager.LoadSceneAsync("OpeningState", LoadSceneMode.Additive);
            // we want the instructions menu aka how to play, to be shown once we start up the game, along with the game scene=farm.
        }
    }
}