using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public GameObject tile;
    Vector3 pos = new Vector3(2f,2f,0);

    public List<GameObject> Tiles = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        

        for(int i = 0; i<25;i++)
        {
            Tiles.Add(tile);
        }

        
        for(int i =0; i<= 4; i += 1)
        {
            for(int j =0; j<= 4; j += 1)
            {
                Instantiate(Tiles[i + j], new Vector3(i-pos.x, j-pos.y, 0), Quaternion.identity);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
