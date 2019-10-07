using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Project
{
    public int projectId;
    public int[] tileData = new int[25];
    GameObject projectButton;

    bool buttonCreated = true;




    public Project(int _projectId)
    {
        this.projectId = _projectId;
    }
    

    public void UpdateTiledata(int[] colorData)
    {
        for(int i =0; i < colorData.Length; i++)
        {
            if (tileData[i] != colorData[i])
            {
                tileData[i] = colorData[i];
            }
            
        }

    }


    public int[] ReturnTiledata()
    {
        return this.tileData;
    }

    public bool ButtonCreated()
    {
        if (buttonCreated)
        {
            
            return (buttonCreated);
        }
        else
        {
            buttonCreated = true;
            return (false);
            
        }


    }

}
