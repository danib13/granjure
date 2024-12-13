using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    // counts of items in pocket
    public int goodMushCount = 0;
    public int badMushCount = 0;
    public int carrotCount = 0;
    public int coins = 0;

    // connect to PockettUI & Canvas UI scripts
    public PocketUI pocketUI;
    public CanvasUI canvasUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // handle mushrooms
    public void AddMushroom(MushroomType mushroomType) {
        if (mushroomType == MushroomType.Good) {
            goodMushCount++;
        } else if (mushroomType == MushroomType.Bad) {
            badMushCount++;
        }
        pocketUI.UpdatePocket();
    }

    public void RemoveMushroom(MushroomType mushroomType) {
        if (mushroomType == MushroomType.Good && goodMushCount > 0) {
            goodMushCount--;
            coins += 10;
        } else if (mushroomType == MushroomType.Bad && badMushCount > 0) {
            badMushCount--;
            coins += 1;
        } else {
            Debug.Log("Insufficient stock: Cannot remove mushroom you don't have.");
        }
        pocketUI.UpdatePocket();
    }

    // handle carrots
    public void AddCarrot(){
        carrotCount++;
        pocketUI.UpdatePocket();
    }

    public void RemoveCarrot(){
        if (carrotCount > 0) {
            carrotCount--;
            coins += 100;
            pocketUI.UpdatePocket();
        } else {
            Debug.Log("Insufficient stock: Cannot remove carrot you don't have.");
        }
    }
}
