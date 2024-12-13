using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyController : MonoBehaviour
{
    //public
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public GameObject weaponPrefab;
    public float shootInterval = 1f;
    public float bulletSpeed = 5f;

    //private
    private PlayerManager playerManager;
    private Health health; // if defeatable enemy w health bar
    private Coroutine weapon_coroutine;
    private bool isRunning_weaponThrow = false;

    // Start is called before the first frame update
    void Start()
    {
        health = new Health(30);
        //health = GetComponent<HealthBar>();
        if (health == null)
        {
            Debug.LogError("Health component NOT found!");
        }
        playerManager = FindObjectOfType<PlayerManager>();
        if (playerManager == null)
        {
            Debug.Log("PlayerManager NOT Found!");
        }
        StartCoroutine(ShootBullets(bulletPrefab,bulletSpawnPoint));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && !isRunning_weaponThrow)
        {
            isRunning_weaponThrow = true;
            ShootWeapon(weaponPrefab, bulletSpawnPoint, playerManager.transform.position);
            Invoke("ResetWeaponFlag", 0.5f);// reset after delay
        }
    }

    private IEnumerator ShootBullets(GameObject bulletPrefab, Transform bulletSpawnPoint, bool towardsEnemy = true)
    {
        while (true)
        {
            // create a bullet at the spawn point
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // have it go in some direction (this is towards player)
            Vector2 aimDirection = (playerManager.transform.position - bulletSpawnPoint.position).normalized;

            bulletRigidbody.velocity = aimDirection * bulletSpeed;

            yield return new WaitForSeconds(shootInterval);
        }
    }

    private void ShootWeapon(GameObject weaponPrefab, Transform targetPoint, Vector3 player_loc_at_throw)
    {
        Debug.Log($"SHOOT WEAPON {targetPoint},{player_loc_at_throw}");
        // have it go in some direction (this is towards player)
        Vector2 aimDirection = (player_loc_at_throw - targetPoint.position).normalized;

        // weapon passed in
        Vector2 spawn2 = (Vector2)player_loc_at_throw + aimDirection * (-.05f);
        Vector3 spawn3 = new Vector3(spawn2.x, spawn2.y, 0);
        GameObject bullet = Instantiate(weaponPrefab, spawn3, Quaternion.identity);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        bulletRigidbody.velocity = -aimDirection * bulletSpeed * 2;

        return;
    }

    // if chicken gets hit with the projectile = die / game over
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log($"Hit ENEMY with {other.gameObject.name}");
            Destroy(other.gameObject);
            health.TakeDamage(4, gameObject);
        }
    }

    private void ResetWeaponFlag()
    {
        isRunning_weaponThrow = false;
    }
}