using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowCarrot : MonoBehaviour
{
    // public
    // public Sprite smallSprite, mediumSprite, grownSprite;
    public Sprite[] growthSprites; // better to have an array than single sprites
    public int growthStages = 4; // base- 0, seedling- 1, sprout- 2, veggie- 3
    public bool touch = false, water = false;
    public GameObject veggiePrefab;
    

    // private
    private PlayerManager playerManager;
    private SpriteRenderer spriteRenderer;
    private int currentStage = 0;
    private bool hasBeenCollided = false;
    private Vector2 distanceWatering; // x and y coordinate distance
    private float distanceW;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        playerManager = FindObjectOfType<PlayerManager>();
        if(playerManager == null) {
            Debug.Log("PlayerManager NOT Found!");
        }
    }


    //try 3
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // when collide carrot with player raise flag
            hasBeenCollided = true;
            Debug.Log("hasBeenCollided = true");
            distanceWatering = playerManager.transform.position - other.transform.position;
            distanceW = distanceWatering.magnitude;
        }
    }

    private void Update()
    {
        if (hasBeenCollided && playerManager.currentPlayerState == PlayerState.Watering)
        {
            // grow into the next stage, not passing the max growth stages. 4 stages but 3 is the highest (0,1,2,3)
            currentStage = Mathf.Clamp(currentStage + 1, 0, growthStages - 1);

            // grow the sprite.
            if (currentStage < growthSprites.Length)
            {
                spriteRenderer.sprite = growthSprites[currentStage];
                Debug.Log("Growing sprite: stage "+currentStage);
            }

            // reset flag to avoid continuous growth.
            Debug.Log("Reset flag & set idle state");
            hasBeenCollided = false;
            playerManager.currentPlayerState = PlayerState.Idle;
        }
        if (hasBeenCollided && playerManager.currentPlayerState == PlayerState.Harvesting) {
            Debug.Log("Player state harvesting!! stage:"+currentStage);
            if (currentStage == growthStages - 1) { // if 4th stage (0,1,2,3)
                Debug.Log("current stage == max");
                // create collectible veggie
                Instantiate(veggiePrefab, transform.position, Quaternion.identity);

                // delete the growing carrot stage
                Destroy(gameObject);

                // reset
                hasBeenCollided = false;
            }
        }
        // gave issues so reset when walk away was removed.
        //else if (hasBeenCollided && playerManager.currentPlayerState == PlayerState.Walking) {
            //reset since you walked away
            // Debug.Log("Reset flag since you walked away");
            // hasBeenCollided = false;
        // }
        // float dist;
        // dist = (playerManager.transform.position - gameObject.transform.position).magnitude;
        // if (distanceW != dist) {
        //     hasBeenCollided = false;
        // }
    }
}

// TRY 2
// private void Update()
//     {
//         // continuously check if the player is near and watering.
//         Debug.Log("Player State is: "+playerManager.currentPlayerState);
//         if (IsPlayerNear() && playerManager.currentPlayerState == PlayerState.Watering)
//         {
//             // grow into the next stage, not passing the max growth stages.
//             currentStage = Mathf.Clamp(currentStage + 1, 0, growthStages);

//             // grow the sprite.
//             if (currentStage < growthSprites.Length)
//             {
//                 spriteRenderer.sprite = growthSprites[currentStage];
//             }
//         }
//     }

//     private bool IsPlayerNear()
//     {
//         // cast ray from the carrot to player.
//         Vector2 carrotPosition = transform.position;
//         Vector2 playerPosition = playerManager.transform.position;
//         Vector2 direction = playerPosition - carrotPosition;
//         float distanceToPlayer = direction.magnitude;

//         // raycast to check if the player is near.
//         RaycastHit2D hit = Physics2D.Raycast(carrotPosition, direction, distanceToPlayer);

//         if (hit.collider != null && hit.collider.CompareTag("Player"))
//         {   
//             Debug.Log("COLLIDE: Carrot Position:"+carrotPosition+", Player Position:"+playerPosition);
//             return true;
//         }

//         return false;
//     }
// }


    //TRY 1
    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     // TODO: when click a key -- water
    //     if (other.gameObject.CompareTag("Player")) {
    //         Debug.Log("Player collide carrot, state:"+playerManager.currentPlayerState);

    //         if (playerManager.currentPlayerState == PlayerState.Watering){
    //             Debug.Log("Watering State");
    //             // grow into next stage, not passing "growthstages" max of 4 stages
    //             currentStage = Mathf.Clamp(currentStage + 1,  0, growthStages);
                
    //             // grow the sprite
    //             if (currentStage < growthSprites.Length) {
    //                 spriteRenderer.sprite = growthSprites[currentStage];
    //             }
    //         }
    //         // // grow into next stage, not passing "growthstages" max of 4 stages
    //         // currentStage = Mathf.Clamp(currentStage + 1,  0, growthStages);
            
    //         // // grow the sprite
    //         // if (currentStage < growthSprites.Length) {
    //         //     spriteRenderer.sprite = growthSprites[currentStage];
    //         // }
    //     }
    //     // TODO: when click a key -- harvest
    //     // if (harvest) {
    //     // add carrot to inventory,
    //     // delete carrot grow object(remove the carrot from farmscene)}
    // }
// }
