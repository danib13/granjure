using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterExitHouse : MonoBehaviour
{
    // public PlayerManager playerManager;
    //public SpawnManager spawnManager;

    // two entrances for FarmScene
    private Vector3 insideDoor = new Vector3(-0.5f, -2.1f, 0);
    private Vector3 outsideDoor = new Vector3(-5.5f, -0.5f, 0);
    private Vector3 SpawnLocation;
    //GameObject doorSpawn, pathSpawn;

    private void Start() {
     //   spawnManager = GetComponent<SpawnManager>();
    }
    
    // if collision between player and door -- move scenes
    private void OnTriggerEnter2D(Collider2D other) {
        // get active scene (can only be 1 of 2)
        Scene currentScene = SceneManager.GetActiveScene();

        Debug.Log("Collision detected with player");
        if (other.CompareTag("Player")) {
            if (currentScene.name == "HouseScene") {
                // protect the object until we finish
                DontDestroyOnLoad(gameObject);

                Debug.Log("Loading scene.....");
                AsyncOperation loadAsync = SceneManager.LoadSceneAsync("FarmScene");
                Scene targetScene = SceneManager.GetSceneByName("FarmScene");
                Debug.Log("Loading FarmScene"); 
                
                loadAsync.completed += (asyncOp) => {
                    // if (targetScene.IsValid())
                    // {
                    //     if (!targetScene.isLoaded)
                    //     {
                    //         Debug.Log("FarmScene is not loaded yet.");
                    //         SceneManager.LoadScene("FarmScene", LoadSceneMode.Single); // Load the scene if not loaded.
                    //     }
                    //     else
                    //     {
                    //         Debug.Log("FarmScene is already loaded.");
                    //     }
                    // }
                    // else
                    // {
                    //     Debug.LogError("FarmScene does not exist in the Build Settings.");
                    // }
                    Debug.Log("PlayerManager search");
                    PlayerManager playerManager = FindObjectOfType<PlayerManager>();
                    if (playerManager) {
                        Debug.Log("FOUND PLAYER MANAGER");
                    }

                    GameObject portal = GameObject.Find("DoorSpawnPoint");
                    Vector3 portalVector = portal.transform.position;
                    playerManager.SetPlayerPosition(portalVector);
                    Debug.Log("Set position");
                    
                };
                Destroy(gameObject);
            } else {
                DontDestroyOnLoad(gameObject);
                // Have to use async so we can still access doorportal in this script
                AsyncOperation loadAsync = SceneManager.LoadSceneAsync("HouseScene");
                loadAsync.completed += (asyncOp) => {
                    Debug.Log("PlayerManager search");
                    PlayerManager playerManager = FindObjectOfType<PlayerManager>();
                    if (playerManager) {
                        Debug.Log("FOUND PLAYER MANAGER");
                    }
                    GameObject portal = GameObject.Find("DoorPortal");
                    Vector3 portalVector = portal.transform.position;
                    // have the player in front of door
                    playerManager.SetPlayerPosition(portalVector);
                    
                };
                Destroy(gameObject);
            }
        }
    }
}
