using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpan = 0;
    public float tileLength = 30;
    public int levelNumber;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tilePrefabs.Length; i++)
        {
            if (i== 0) {
                spanTile(0);
            }
            else
            {
                spanTile(Random.Range(0, tilePrefabs.Length));
            }
       
        }
      //  spanTile(tilePrefabs.Length-1);

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z -35 > zSpan - (tilePrefabs.Length * tileLength))
        {
            spanTile(Random.Range(0, tilePrefabs.Length));
            deleteTile();
        }
    }

    private void deleteTile()
    {
         Destroy(activeTiles[0]);
         activeTiles.RemoveAt(0);     
    }

    public void spanTile(int tileIndex) {
      GameObject newTile =  Instantiate(tilePrefabs[tileIndex], transform.forward * zSpan, transform.rotation);
        activeTiles.Add(newTile);
        zSpan += tileLength;
    }
}
