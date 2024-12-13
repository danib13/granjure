
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathToFarm : MonoBehaviour {

    //public
    //private

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Scene currentScene = SceneManager.GetActiveScene();

        if (other.CompareTag("Player")) {
            // protect the object until we finish teleporting
            DontDestroyOnLoad(gameObject);

            // AsyncOperation https://docs.unity3d.com/2017.2/Documentation/ScriptReference/AsyncOperation.html
            AsyncOperation loadAsync = SceneManager.LoadSceneAsync("FarmScene");
            // when async op complete it invokes the event
            /* "+=" attaches the event handler(https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/classes#158-events),
             * "=>{...}" is an anonymous function */
            loadAsync.completed += (asyncOp) => {
                PlayerManager playerManager = FindObjectOfType<PlayerManager>();
                if (playerManager) {
                    Debug.Log("FOUND PLAYER MANAGER");
                }


                GameObject portal = GameObject.Find("PathSpawnPoint");
                if (portal) {
                    Debug.Log("FOUND portal");
                    Vector3 portalVector = portal.transform.position;
                    playerManager.SetPlayerPosition(portalVector);
                } else {
                    Debug.LogError("Portal (PathSpawnPoint) not found!");
                }
                
                // destroy old gameobject since we finished
                Destroy(gameObject);
            };
        }
    }
}
