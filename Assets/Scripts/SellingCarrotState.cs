using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingCarrotState : MonoBehaviour
{
    // public
    // connect to pocket script
    public Pocket pocket;

    // private
    private PlayerManager playerManager;
    private bool collected = false;
    
    // audio
    AudioSource m_MyAudioSource;

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
        m_MyAudioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            while(pocket.carrotCount > 0){
                pocket.RemoveCarrot();
                Debug.Log("Removed a carrot!");
                m_MyAudioSource.Play(); // only play coin sound if sold
            }
            
            // we dont destroy npc since we want to sell many times
        }
    }
}
