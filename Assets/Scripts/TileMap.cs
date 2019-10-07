using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



[System.Serializable]
public class TileMap : MonoBehaviour
{

    public GameObject tile;
    Vector3 pos = new Vector3(-2f,-2f,0);



    public Dictionary<int,GameObject> Tiles = new Dictionary<int, GameObject>();
    public Dictionary<int, int[]> colorid = new Dictionary<int, int[]>();
    public int[] colorID = new int[25];



    private void OnEnable()
    {
        colorid.Clear();
        Events.drawScreen += NewProject;
        Events.Destroytiles += DestroyTiles;
        Events.recallProject += RetriveProject;
        Events.saveButton += UpdateColor;
    }

    private void OnApplicationQuit()
    {
        Events.drawScreen -= NewProject;
        Events.Destroytiles -= DestroyTiles;
        Events.recallProject -= RetriveProject;
        Events.saveButton -= UpdateColor;
    }

    public void NewProject()
    {
        Tiles.Clear();
        int k = 0;
        for (int i = 0; i <= 4; i += 1)
        {
            for (int j = 0; j <= 4; j += 1)
            {

                GameObject tempTile = Instantiate(tile, new Vector3(i + pos.x, j + pos.y, 0), Quaternion.identity);
                tempTile.name = "Tiles " + j.ToString() + " " + i.ToString();
                Tiles.Add(k, tempTile);
                k++;
            }
        }

    }

    public void RetriveProject(int[] colorData , int project_id)
    {
        Tiles.Clear();
        //int[] Color_data = colorid[project_id];
        //foreach(int id in colorData)
        //{
         //   Color_data = colorData;

        //}
        int k = 0;
        for (int i = 0; i <= 4; i += 1)
        {
            for (int j = 0; j <= 4; j += 1)
            {

                GameObject tempTile = Instantiate(tile, new Vector3(i + pos.x, j + pos.y, 0), Quaternion.identity);
                tempTile.GetComponent<TileBehaviour>().ChangeColorWithID(colorData[k]);
                tempTile.name = "Tiles " + j.ToString() + " " + i.ToString();
                Tiles.Add(k, tempTile);
                
                k++;
            }
        }

    }


    public void UpdateColor(int _projectId)
    {
        Debug.Log("COLOEEE");
        int k = 0;


        //colorid.Clear();
        /*if(colorid[_projectId] == Colo)
        {
            colorid.Remove(_projectId);
        }*/


        //for (int t = 0; t < colorID.Length; t++)
        //{
        //    colorID[t] = 0;
        //}

        /*
        if (colorid[_projectId] == null)
        {
            int[] Color_data = colorid[_projectId];
            foreach (int id in colorID)
            {
                colorID = Color_data;

            }
        }
        */

        foreach (KeyValuePair<int,GameObject> tile in Tiles)
        {
            //bool colorChange = tile.Value.GetComponent<TileBehaviour>().ColorChanged();
            int colorNum = tile.Value.GetComponent<TileBehaviour>().returnColor();
            //if (colorNum != 0)
            //{
                //colorid.Remove(k);
                //colorid.Add(k, colorNum);
                //colorID[k] = 0;
                colorID[k] = colorNum;
                
            //}
            //Debug.Log(colorid + " " + tile.Value.name);
            k++;
        }
        Debug.Log("Savepre-EVENT" + _projectId);

        colorid[_projectId] = colorID;


        Debug.Log("SaveEVENT");
        Events.saveProject(colorid[_projectId]);
    }


    public void DestroyTiles()
    {
        foreach(var tempTile in Tiles)
        {
            Destroy(tempTile.Value);
        }
    }
}
