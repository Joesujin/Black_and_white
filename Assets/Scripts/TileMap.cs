using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



[System.Serializable]
public class TileMap : MonoBehaviour
{

    public GameObject tile;
    Vector3 pos = new Vector3(2f,2f,0);

    public List<GameObject> arrcolorID = new List<GameObject>();

    public Dictionary<int,GameObject> Tiles = new Dictionary<int, GameObject>();
    public Dictionary<int, int> colorid = new Dictionary<int, int>();
    public int[] colorID = new int[25];


    // Start is called before the first frame update
    void Start()
    {

        
        

        int k = 0;
        for (int i =0; i<= 4; i += 1)
        {
            for(int j =0; j<= 4; j += 1)
            {
                
                GameObject tempTile = Instantiate(tile, new Vector3(i-pos.x, j-pos.y, 0), Quaternion.identity);
                tempTile.name = "Tiles " + i.ToString() + " " + j.ToString();
                Tiles.Add(k, tempTile);
                k++;
            }
        }

        //arrcolorID = GameObject.FindGameObjectsWithTag("Tile").ToList();


    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    public void UpdateColor()
    {
        /*foreach( var tile  in arrcolorID)
        {
            //int address = tile.Key;
            //Debug.Log(tile.Key);
            var colorid = tile.GetComponent<TileBehaviour>().returnColor();
            Debug.Log(colorid + " " + tile.name);
        }*/
        int k = 0;
        colorid.Clear();
        foreach (KeyValuePair<int,GameObject> tile in Tiles)
        {
            
            colorid.Add(k,tile.Value.GetComponent<TileBehaviour>().returnColor());
            colorID[k] = tile.Value.GetComponent<TileBehaviour>().returnColor();
            Debug.Log(colorid + " " + tile.Value.name);
            k++;
        }
    }

}
