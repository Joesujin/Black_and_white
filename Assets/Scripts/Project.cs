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

    public bool isPass = false;

    public int[] QuestionData = new int[25];
    public int[] decodedQuestionData = new int[25];



    public Project(int _projectId, int QuestionDifficulty)
    {
        this.projectId = _projectId;
        CreateQuestion(QuestionDifficulty);
    }

    public void CreateQuestion(int randomRangeincrease)
    {
        for(int k =0; k<QuestionData.Length; k++)
        {
            QuestionData[k] = Random.Range(1, randomRangeincrease);
            decodedQuestionData[k] = QuestionData[k];
        }
        
    }



    public bool CrossCheck()
    {
        //Debug.Log("CrossCheckin...");
        for (int k = 0; k < QuestionData.Length; k++)
        {
            if(decodedQuestionData[k] == tileData[k])
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

    public void swapData(int color1, int color2)
    {
        
        for (int i = 0; i < decodedQuestionData.Length; i++)
        {
            if(decodedQuestionData[i] == color1)
            {
                decodedQuestionData[i] = color2;
            }
            else if(decodedQuestionData[i] == color2)
            {
                decodedQuestionData[i] = color1;
            }
        }
    }

}
