using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathTownToForest : MonoBehaviour {

    //public
    
    //private
    private Vector3 townEntrance = new Vector3(-7.5f, 1f, 0);

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
            loadAsync.completed += (asyncOp) => {

                PlayerManager playerManager = FindObjectOfType<PlayerManager>();
                if (playerManager) {
                    Debug.Log("FOUND PLAYER MANAGER");
                }
                
                GameObject Parent = GameObject.Find("TownPath");
                Transform portal = null;
                if (Parent) {
                    portal = Parent.transform.Find("TownEntrance");
                    if (portal) {
                        Debug.Log("FOUND PORTAL");
                    }
                }
                Vector3 portalVector = portal.position;
                playerManager.SetPlayerPosition(portalVector);
            };
            // destroy old gameobject since we finished
            Destroy(gameObject);
        }
    }
}
