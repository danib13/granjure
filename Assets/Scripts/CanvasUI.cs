using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    
    // public
    public Text coinText, popUpText;

    //private
    private Pocket pocket; // pocket inventory
    
    // Start is called before the first frame update
    void Start()
    {
        // find by script Pocket.cs, attached to player or some Pocket gameobject
        pocket = FindObjectOfType<Pocket>();
        UpdateCanvasUI();
    }

    // Update is called once per frame
    void Update()
    {  
        /*// open and close pocket by using the "p" key
        if (Input.GetKeyDown(KeyCode.P)) {
            Debug.Log("P key pressed");
            gameObject.SetActive(!gameObject.activeSelf);
        }//commented out this since decided pocket should always be visible*/
    }

    private void UpdateCanvasUI() {
        coinText.text = "" + pocket.coins;
        // coin image to the left so "Coins:"+pocket.coins; updated
    }

    public void UpdateCanvas() {
        UpdateCanvasUI();
    }
}
