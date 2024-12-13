using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseReaction : MonoBehaviour
{
    // public
    public string ItemName; // assigned in inspector
    //public Text dialog;
    [SerializeField] GameObject houseCanvasPrefab;

    // private
    private bool hit = false;
    private GameObject instantiatedCanvas;
    private HouseDialogPopup houseDialogPop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (instantiatedCanvas && true)
        {
            //houseDialogPop.updateDialog();
            *//*instantiatedCanvas.GetComponent<Text>().text = "It's just a " + ItemName;*/
            /*GameObject parent1 = instantiatedCanvas.transform.Find("Canvas");
            GameObject parent2 = parent1.transform.Find("Image");
            parent2.GetComponent<Text>().text = "Its just a "+ItemName;*//*
        }*/
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("1 Collided with "+ ItemName);
            var canvasObjects = FindObjectsOfType<HouseDialogPopup>();
            if (canvasObjects.Length == 0)
            {
                instantiatedCanvas = Instantiate(houseCanvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                
            }
            hit = true;

            /* find by script HouseDialogPopup.cs
             * we only find it AFTER the object was created (after collision in this case)*/
            houseDialogPop = FindObjectOfType<HouseDialogPopup>();

            // update dialog if dialog box exists
            if (houseDialogPop)
            {
                Debug.Log("2 ItemName" + ItemName);
                houseDialogPop.setItemName(ItemName);
                houseDialogPop.updateDialog();
            } else
            {
                Debug.LogWarning("houseDialogPop is null.");
            }
            
        }
    }
}
