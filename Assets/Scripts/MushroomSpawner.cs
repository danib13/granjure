using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; // Tilemap documentation https://docs.unity3d.com/2017.2/Documentation/ScriptReference/Tilemaps.Tilemap.html

public class MushroomSpawner : MonoBehaviour
{
    //public
    public GameObject goodMushroomPrefab;
    public GameObject badMushroomPrefab;
    public Tilemap tilemap;

    public int goodMushCount = 5;
    public int badMushCount = 5;
    //private

    // Start is called before the first frame update
    void Start()
    {
        GrowMushrooms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GrowMushrooms() {
        // get the tilemap in order to determine where to grow mushrooms
        BoundsInt bounds = tilemap.cellBounds; // returns boundaries of TileMap https://docs.unity3d.com/2017.2/Documentation/ScriptReference/Tilemaps.Tilemap-cellBounds.html
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds); // returns arrray of tiles from bounds

        // grow # of good mush
        for (int i = 0; i < goodMushCount; i++)
        {
            SpawnMushroom(goodMushroomPrefab, bounds);
        }

        // grow # of bad mush
        for (int i = 0; i < badMushCount; i++)
        {
            SpawnMushroom(badMushroomPrefab, bounds);
        }
    }

    void SpawnMushroom(GameObject mushroomPrefab, BoundsInt bounds) {
        // we want to continuously search for a position
        while (true) {
            // search through the bounds
            Vector3Int randomPosition = new Vector3Int(
                Random.Range(bounds.x, bounds.x + bounds.size.x),
                Random.Range(bounds.y, bounds.y + bounds.size.y),
                0); // position at (random x within bounds, random y within bounds, z = 0)
            // check tile at the position https://docs.unity3d.com/ScriptReference/Tilemaps.Tilemap.GetTile.html
            TileBase tileAtRandomPosition = tilemap.GetTile(randomPosition); // returns tile placed at cell location at the vector3int parameter

            // if the space is empty, we can place a mushroom!
            if (tileAtRandomPosition == null)
            {
                // spawning mushroom at the center of the tile by instantiating at "spawn position"
                Vector3 spawnPosition = tilemap.GetCellCenterWorld(randomPosition); // get the logical center coordinate of a grid cell in world space.
                Instantiate(mushroomPrefab, spawnPosition, Quaternion.identity);
                
                // we HAVE to break, otherwise the while loop would NEVER stop
                break;
            }
        }
    }
}
