using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForageMushrooms : MonoBehaviour {
    // public
    //public Camera mainCamera; // ref to scene's cam
    public float mushroomDistance = 2f; // how close to check for foraging
    public MushroomType mushroomType; // set for each mushroom

    // connect to pocket script
    public Pocket pocket;

    // private

    // audio
    GameObject audioMushGameObj;
    AudioSource m_MyAudio;
    public AudioClip forageMushSound;
    
    // Start is called before the first frame update
    void Start()
    {
        // find by script Pocket.cs, attached to player or some Pocket gameobject
        pocket = FindObjectOfType<Pocket>();

        // find audio
        audioMushGameObj = GameObject.Find("AudioSource-Mush");
        m_MyAudio = audioMushGameObj.GetComponent<AudioSource>();
        /* need to have audiosource as a separate gameobj because sound wont play 
         * if the obj is destroyed upon collision */
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            //m_MyAudio.PlayOneShot(forageMushSound, 0.7F);//audio
            m_MyAudio.Play(); // play audio when collide
            string typeFound = "";
            // handle good mush
            if (mushroomType == MushroomType.Good) {
                typeFound = "Good";
                pocket.AddMushroom(mushroomType);
            }
            // handle bad mush
            else if (mushroomType == MushroomType.Bad) {
                typeFound = "Bad";
                pocket.AddMushroom(mushroomType);
            }
            Debug.Log("Foraged "+typeFound+" Mushroom!");
            Destroy(gameObject);
        }
    }
}
