using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn;
    public float tileLenght;
    public int numberOfTiles;
    private List<GameObject> activeTiles; 
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        zSpawn = 0f;
        tileLenght = 60f;
        numberOfTiles = 7;
        activeTiles = new List<GameObject>();

        for (int i= 0; i < numberOfTiles; i++)
        {
            if(i==0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - 65 > zSpawn-(numberOfTiles*tileLenght))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLenght;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}