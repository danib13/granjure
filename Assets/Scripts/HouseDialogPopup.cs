using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseDialogPopup : MonoBehaviour
{
    // public
    public Text dialog; // attached to the correct text in inspector

    // private
    private HouseReaction houseReaction;
    private string item;
    private bool setName = false;

    // Start is called before the first frame update
    void Start()
    {
        //houseReaction = FindObjectOfType<HouseReaction>();
        //updateDialog();
        //Debug.Log("3 ItemName" + houseReaction.ItemName);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("4 ItemName" + houseReaction.ItemName);
        updateDialog();
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("hit & enter");
            Destroy(gameObject);
        }
    }

    public void updateDialog()
    {
        if (setName) {
            Debug.Log("updateDialog() with itemname:" + item);
            dialog.text = "It's just " + item;
        }
        /*Debug.Log("updateDialog() with itemname:"+houseReaction.ItemName);
        dialog.text = "It's just a " + houseReaction.ItemName;*/
    }

    public void setItemName(string name)
    {
        item = name;
        setName = true;
    }


}
