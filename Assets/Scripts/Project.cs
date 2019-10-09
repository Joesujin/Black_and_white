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

    bool isPass = false;

    public int[] QuestionData = new int[25];

          
    public Project(int _projectId)
    {
        this.projectId = _projectId;
        CreateQuestion();
    }

    public void CreateQuestion()
    {
        for(int k =0; k<QuestionData.Length; k++)
        {
            QuestionData[k] = Random.Range(1,3 );
        }
    }

    public bool CrossCheck()
    {
        //Debug.Log("CrossCheckin...");
        for (int k = 0; k < QuestionData.Length; k++)
        {
            if(QuestionData[k] == tileData[k])
            {
                isPass = true;
            }
            else
            {
                isPass = false;
                break;
            }
           
        }
        return isPass;
    }

    public void UpdateTiledata(int[] colorData)
    {
        for(int i =0; i < colorData.Length; i++)
        {
            if (tileData[i] != colorData[i])
            {
                tileData[i] = colorData[i];
            }
            else
            {
                tileData[i] = tileData[i];
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
