using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    string projectileName = "";
    // Start is called before the first frame update
    void Start()
    {
        projectileName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log($"Projectile {projectileName} COLLIDED with {other.gameObject.name}");
        if (projectileName == "AxeWeapon" && other.gameObject.name == "Player")
        {
            return;
        }
        else if (gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            // regardless of what it hits, it should be destroyed upon a collision
        }
        else if (other.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
        else if (projectileName == "AxeWeapon")
        {
            Destroy(gameObject);
            // only destroy if it collides against anything that is not player
        }
    }
}
