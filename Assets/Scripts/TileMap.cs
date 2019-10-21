using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



[System.Serializable]
public class TileMap : MonoBehaviour
{

    public GameObject tile;
    public GameObject QuestionTile;
    public GameObject panal;
    public Vector3 pos = new Vector3(-2f,-2f);
    public Vector3 QuestionPos = new Vector3(-4f, -8f);

    public Dictionary<int,GameObject> Tiles = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> questionTiles = new Dictionary<int, GameObject>();

    public Dictionary<int, int[]> colorid = new Dictionary<int, int[]>();
    public int[] colorID = new int[25];
    public float QuestionTileGap;



    private void OnEnable()
    {
        colorid.Clear();
        Events.drawScreen += NewProject;
        Events.Destroytiles += DestroyTiles;
        Events.recallProject += RetriveProject;
        Events.saveButton += UpdateColor;
        Events.preButtonCall += loadColorData;
    }

    private void OnApplicationQuit()
    {
        Events.drawScreen -= NewProject;
        Events.Destroytiles -= DestroyTiles;
        Events.recallProject -= RetriveProject;
        Events.saveButton -= UpdateColor;
        Events.preButtonCall -= loadColorData;
    }

    public void NewProject()
    {
        int k = 0;
        for (int i = 0; i <= 4; i += 1)
        {
            for (int j = 0; j <= 4; j += 1)
            {
                GameObject tempTile = Instantiate(tile, new Vector3(i + pos.x, j + pos.y, 0), Quaternion.identity);
                tempTile.name = "Tiles " + j.ToString() + " " + i.ToString();
                Tiles[k] = tempTile;
                k++;
            }
        }

    }

    public void RetriveProject(int[] colorData , int project_id)
    {
        //colorID = colorData;
        int k = 0;
        for (int i = 0; i <= 4; i += 1)
        {
            for (int j = 0; j <= 4; j += 1)
            {

                GameObject tempTile = Instantiate(tile, new Vector3(i + pos.x, j + pos.y, 0), Quaternion.identity);
                tempTile.GetComponent<TileBehaviour>().ChangeColorWithID(colorData[k]);
                tempTile.name = "Tiles " + j.ToString() + " " + i.ToString();
                Tiles[k]= tempTile;
                
                k++;
            }
        }
    }

    public void LoadQuestion(int[] QuestionData)
    {
        int k = 0;
        for (int i = 0; i <= 4; i += 1)
        {
            for (int j = 0; j <= 4; j += 1)
            {
                GameObject tempTile = Instantiate(QuestionTile, new Vector3((i*QuestionTileGap) + panal.transform.position.x, (j* QuestionTileGap )+ panal.transform.position.y, 0), Quaternion.identity);

                //GameObject tempTile = Instantiate(QuestionTile, new Vector3((i + QuestionPos.x) *QuestionTileGap,(j+ QuestionPos.y)*QuestionTileGap, 0), Quaternion.identity);
                tempTile.GetComponent<QuestionTileBehavior>().ChangeColorWithID(QuestionData[k]);
                tempTile.name = "QuestionTiles " + j.ToString() + " " + i.ToString();
                questionTiles[k] = tempTile;
                k++;
            }
        }

    }


    public void UpdateColor(int _projectId)
    {
        int k = 0;
        int[] tempData = gameObject.GetComponent<GameState>().projects[_projectId].tileData;
        colorID = tempData;
        

        foreach (KeyValuePair<int,GameObject> tile in Tiles)
        {
            int colorNum = tile.Value.GetComponent<TileBehaviour>().returnColor();
            if (tempData[k] != colorNum)
            {
               colorID[k] = colorNum;
            }
            k++;
        }

        colorid[_projectId] = colorID;
        Events.saveProject(colorid[_projectId]);
    }


    public void loadColorData(int project_id)
    {
        int k = 0;
        foreach (KeyValuePair<int, GameObject> tile in Tiles)
        {
            int colorNum = tile.Value.GetComponent<TileBehaviour>().returnColor();
            colorID[k] = colorNum;
            k++;
        }
        colorID = colorid[project_id];
    }

    public void clearTileColors(int project_id)
    {
        foreach (var tempTile in Tiles)
        {
            Destroy(tempTile.Value);
        }
        int k = 0;
        for (int i = 0; i <= 4; i += 1)
        {
            for (int j = 0; j <= 4; j += 1)
            {

                GameObject tempTile = Instantiate(tile, new Vector3(i + pos.x, j + pos.y, 0), Quaternion.identity);
                tempTile.GetComponent<TileBehaviour>().ChangeColorWithID(0);
                tempTile.name = "Tiles " + j.ToString() + " " + i.ToString();
                Tiles[k] = tempTile;

                k++;
            }
        }
    }

    public void DestroyTiles()
    {
        foreach(var tempTile in Tiles)
        {
            Destroy(tempTile.Value);
        }
        foreach (var tempTile in questionTiles)
        {
            Destroy(tempTile.Value);
        }
    }
}
