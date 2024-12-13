using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingBadMushroomState : MonoBehaviour
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
            while(pocket.badMushCount > 0){
                // while we have at least 1 mushroom
                pocket.RemoveMushroom(MushroomType.Bad);
                Debug.Log("Sold Bad Mushroom!");
                m_MyAudioSource.Play(); // only play coin sound if sold
            }

            // we dont destroy npc since we want to sell many times
        }
    }
}
