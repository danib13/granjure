using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathToForest : MonoBehaviour {
    //public
    //public Vector3 playerChange;
    //private
    private Vector3 farmEntrance = new Vector3(-0.5f, -4f, 0);

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
            AsyncOperation loadAsync = SceneManager.LoadSceneAsync("ForestScene");
            // when async op complete it invokes the event
            /* "+=" attaches the event handler(https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/classes#158-events),
             * "=>{...}" is an anonymous function */
            loadAsync.completed += (asyncOp) => {

                PlayerManager playerManager = FindObjectOfType<PlayerManager>();
                if (playerManager) {
                    Debug.Log("FOUND PLAYER MANAGER");
                }
                
                GameObject Parent = GameObject.Find("FarmPath");
                Transform portal = null;
                if (Parent) {
                    portal = Parent.transform.Find("FarmEntrance");
                    if (portal) {
                        Debug.Log("FOUND PORTAL");
                    }
                }
                Vector3 portalVector = portal.position;
                playerManager.SetPlayerPosition(portalVector);
                
                // destroy old gameobject since we finished
                Destroy(gameObject);
            };
        }
    }
}
