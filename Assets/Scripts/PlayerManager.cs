using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState {
    Default,
    Idle,
    Walking,
    Watering,
    Harvesting
}

// character controller (2D) of player. takes care of movement, input, player states
public class PlayerManager : MonoBehaviour {
    // public
    public float playerSpeed;
    public PlayerState currentPlayerState;
    public AudioClip wateringCanSound;
    public AudioClip rakeToolSound;
    public AudioSource m_audioSource;

    // private
    private Rigidbody2D playerRigidbody;
    private Vector3 playerPositionChange; // v3 (x,y,z) coordinate
    private Animator animator; // use animations
    private bool isWateringComplete = false, isHarvestingComplete = false;

    // to see if the animation is complete
    public void OnWaterAnimationComplete(){
        Debug.Log("watering animation complete");
        isWateringComplete = true;
        currentPlayerState = PlayerState.Idle;
    }
    public void OnHarvestAnimationComplete(){
        Debug.Log("harvesting animation complete");
        isHarvestingComplete = true;
        currentPlayerState = PlayerState.Idle;
    }

    // Start is called before the first frame update
    void Start() {
        /* https://learn.unity.com/tutorial/2d-game-kit-reference-guide#
         * Their character is put together using Sprite Renderer, Animator,
         * Capsule Collider 2D, and Rigidbody 2D components, as well
         * as a number of custom scripts. --- Therefore, using this as a basis,
         * the character for this game also uses:
         * Sprite Renderer, Animator, BoxCollider2D, Rigidbody2D components, and custom scripts. */

        // find component and link to variable
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isWatering", false);
        animator.SetBool("isHarvesting", false);
        currentPlayerState = PlayerState.Idle;

        // audio
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        // currentPlayerState=PlayerState.Idle;
        // // player state in animator
        // AnimatorStateInfo playerStateInfo = animator.GetCurrentAnimatorStateInfo(0);


        // reset change
        playerPositionChange = Vector3.zero;

        // find input https://docs.unity3d.com/Manual/class-InputManager.html "Using virtual axes in scripts"
        playerPositionChange.x = Input.GetAxisRaw("Horizontal"); // Get the value of the Horizontal input axis.
        playerPositionChange.y = Input.GetAxisRaw("Vertical"); // Get the value of the Vertical input axis.

        // debug print
        // Debug.Log(playerPositionChange);

        /* to check if keyinput detected--G & H keys--works!
        *  https://docs.unity3d.com/Manual/class-InputManager.html "Mapping virtual axes to controls" */
        
        // water (grows carrot)
        if (Input.GetKeyDown(KeyCode.G)) {
            isWateringComplete = false;// re-enable watering animation each time we water
            Debug.Log("G Pressed!");
            animator.SetBool("isWatering", true);
            currentPlayerState = PlayerState.Watering;
            animator.SetBool("isWalking", false);
            animator.SetBool("isHarvesting", false);
            m_audioSource.PlayOneShot(wateringCanSound, 0.7F);//audio
        }

        // harvest (collects carrot)
        if (Input.GetKeyDown(KeyCode.H)) {
            isHarvestingComplete = false;// re-enable harvesting animation each time we harvest
            Debug.Log("H Pressed!");
            animator.SetBool("isHarvesting", true);
            currentPlayerState = PlayerState.Harvesting;
            animator.SetBool("isWalking", false);
            animator.SetBool("isWatering", false);
            m_audioSource.PlayOneShot(rakeToolSound, 0.7F);//audio
        }

        // if change then move
        if (playerPositionChange != Vector3.zero) {
            walk();
            // connect the player position change to the animator change in x and y, makes sure we use the correct direction animation
            animator.SetFloat("changeX", playerPositionChange.x);
            animator.SetFloat("changeY", playerPositionChange.y);
            animator.SetBool("isWalking", true);
            // if we are walking, we reset watering, cus we only water once and leave, same w harvest
            animator.SetBool("isWatering", false);
            animator.SetBool("isHarvesting", false);
            currentPlayerState = PlayerState.Walking;

        }
        else if (currentPlayerState!=PlayerState.Watering && currentPlayerState!=PlayerState.Harvesting){
            // if we are NOT watering, and we are NOT harvesting ==> we ARE IDLE
            animator.SetBool("isWalking", false);
            currentPlayerState = PlayerState.Idle;
        }
        if (isWateringComplete) {
            animator.SetBool("isWatering", false);
        }
        if (isHarvestingComplete) {
            animator.SetBool("isHarvesting", false);
        }
    }

    // move character
    void walk() {
        // walk movement is current position + change
        playerRigidbody.MovePosition(transform.position + playerPositionChange * playerSpeed * Time.deltaTime);
        // original position (x_0,y_0,z_0) + position change (x_1,y_1,z_1) * player speed * time
    }

    // player position (to help with spawn points)
    public void SetPlayerPosition(Vector3 newPosition) {
        // player set to new position
        transform.position = newPosition;
    }

    // if player gets hit with the projectile = die / game over
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log($"Hit player with {other.gameObject.name}");
            // Destroy(gameObject);
            Destroy(transform.parent.gameObject);
            // Player dies we want to remove the whole playerloader, not just the character
            SceneManager.LoadScene("GameOver");
        }
    }

}
/**
 * Player Manager: character controller setting up player movement in x & y, player actions, and character states.
 * This was adapted from a Aug 11, 2018 video "4 Way Movement" by James Taft (https://twitter.com/TaftCreates)
 * https://youtu.be/--N5IgSUQWI?
 */