using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocketUI : MonoBehaviour
{
    // public
    public Text goodMushCountText, badMushCountText, carrotCountText, coinText;

    //private
    private Pocket pocket; // pocket inventory
    
    // Start is called before the first frame update
    void Start()
    {
        // find by script Pocket.cs, attached to player or some Pocket gameobject
        pocket = FindObjectOfType<Pocket>();
        UpdatePocketUI();
    }

    // Update is called once per frame
    void Update()
    {  
        //commented since decided pocket should always be visible
        // open and close pocket by using the "p" key
        /*if (Input.GetKeyDown(KeyCode.P)) {
            Debug.Log("P key pressed");
            gameObject.SetActive(!gameObject.activeSelf);
        }*/
    }

    private void UpdatePocketUI() {
        // items
        goodMushCountText.text = "" + pocket.goodMushCount;
        badMushCountText.text = "" + pocket.badMushCount;
        carrotCountText.text = "" + pocket.carrotCount;

        // coins
        coinText.text = "" + pocket.coins;
        // save to playerpref for game over screen
        PlayerPrefs.SetInt("Coins", pocket.coins);
    }

    public void UpdatePocket() {
        UpdatePocketUI();
    }
}
