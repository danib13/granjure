using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathToTown : MonoBehaviour {

    //public
    //private
    private Vector3 townEntrance = new Vector3(7.5f, 0.2f, 0);

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
            DontDestroyOnLoad(gameObject);

            // AsyncOperation https://docs.unity3d.com/2017.2/Documentation/ScriptReference/AsyncOperation.html
            AsyncOperation loadAsync = SceneManager.LoadSceneAsync("TownScene");
            // when async op complete it invokes the event
            loadAsync.completed += (asyncOp) => {

                PlayerManager playerManager = FindObjectOfType<PlayerManager>();
                if (playerManager) {
                    Debug.Log("FOUND PLAYER MANAGER");
                }
                
                GameObject portal = GameObject.Find("ForestPath");
                Vector3 portalVector = portal.transform.position;
                playerManager.SetPlayerPosition(portalVector);
                
                Destroy(gameObject);
            };
        }
    }
}
