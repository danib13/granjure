using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverState : MonoBehaviour
{
    // public
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        int coins = PlayerPrefs.GetInt("Coins");
        coinText.text = "Coins: " + coins;
    }

    // Update is called once per frame
    void Update()
    {
        // return since there is no KeyCode.Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PersistingObjectsSpawner persistingObjectsSpawner = FindObjectOfType<PersistingObjectsSpawner>();
            if (persistingObjectsSpawner)
            {
                Debug.Log("PlayerLoader detected");
                Destroy(persistingObjectsSpawner);
            }
            SceneManager.LoadScene("Start");
        }
    }
}
