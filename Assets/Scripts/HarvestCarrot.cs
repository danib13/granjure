using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestCarrot : MonoBehaviour
{
	// public
	// connect to pocket script
	public Pocket pocket;

    // private
    private PlayerManager playerManager;
    private bool collected = false;

    // audio
    GameObject audioCarrotGameObj;
    AudioSource m_MyAudio;
    public AudioClip collectCarrotSound;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        if(playerManager == null) {
            Debug.Log("PlayerManager NOT Found!");
        }

        // find by script Pocket.cs, attached to player or some Pocket gameobject
        pocket = FindObjectOfType<Pocket>();

        // find audio
        // find audio
        audioCarrotGameObj = GameObject.Find("AudioSource-Carrot");
        m_MyAudio = audioCarrotGameObj.GetComponent<AudioSource>();
        /* need to have audiosource as a separate gameobj because sound wont play 
         * if the obj is destroyed upon collision */
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_MyAudio.Play();// play when collide
            collected = true;
            pocket.AddCarrot();
            Debug.Log("collected a carrot!");
            
            Destroy(gameObject);
        }
    }
}

