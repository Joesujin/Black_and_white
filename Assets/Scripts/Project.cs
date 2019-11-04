using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Project
{
    public int projectId;
    public int[] tileData = new int[25];

    int QCol1;
    int QCol2;
    int QCol3;

    public List<QuestionSet> PossibleQuestionPool = new List<QuestionSet>();
    public int ProjectWorth;
    public int penalty;
    public string ProjectDetails;


    bool buttonCreated = true;

    public bool isPass = false;

    public int[] QuestionData = new int[25];
    public int[] decodedQuestionData = new int[25];



    public Project(int _projectId, int QuestionDifficulty)
    {
        this.projectId = _projectId;
        CreateQuestion(QuestionDifficulty);


        this.ProjectWorth = (_projectId * 10) + (QuestionDifficulty * 5);
        this.penalty = ProjectWorth + 5;

        this.ProjectDetails = "Worth = " + this.ProjectWorth.ToString() + "\nPenalty =" + this.penalty.ToString();
    }

    public void CreateQuestion(int difficulty)
    {

        if (difficulty > 3)
        {
            for (int i = 1; i <= difficulty-1; i++)
            {
                for (int j = 1; j <= difficulty-1; j++)
                {
                    for (int k = 1; k <= difficulty-1; k++)
                    {
                        if (i != j && j != k && i != k)
                        {
                            bool pairExists = false;
                            if (PossibleQuestionPool.Count != 0)
                            {
                                foreach (var set in PossibleQuestionPool)
                                {
                                    if (set.Color1 == i)
                                    {
                                        if (set.Color2 == j)
                                        {
                                            if (set.Color3 == k)
                                            {
                                                pairExists = true;
                                            }
                                        }
                                        else if(set.Color2 == k)
                                        {
                                            if(set.Color3 == j)
                                            {
                                                pairExists = true;
                                            }
                                        }

                                    }
                                    if (set.Color1 == j)
                                    {
                                        if (set.Color2 == k)
                                        {
                                            if (set.Color3 == i)
                                            {
                                                pairExists = true;
                                            }
                                        }
                                        if(set.Color2 == i)
                                        {
                                            if(set.Color3 == k)
                                            {
                                                pairExists = true;
                                            }
                                        }
                                    }
                                    if (set.Color1 == k)
                                    {
                                        if (set.Color2 == i)
                                        {
                                            if (set.Color3 == j)
                                            {
                                                pairExists = true;
                                            }
                                        }
                                        if (set.Color2 == j)
                                        {
                                            if (set.Color3 == i)
                                            {
                                                pairExists = true;
                                            }
                                        }
                                    }
                                }
                            }

                            if(pairExists == false)
                            {
                                PossibleQuestionPool.Add(new QuestionSet(i, j, k));
                            }
                        }
                    }
                }
            }

            int setSelector = Random.Range(0, PossibleQuestionPool.Count);
            QCol1 = PossibleQuestionPool[setSelector].Color1;
            QCol2 = PossibleQuestionPool[setSelector].Color2;
            QCol3 = PossibleQuestionPool[setSelector].Color3;


            for (int k = 0; k < QuestionData.Length; k++)
            {
                int RandTemp = Random.Range(1, 4);

                switch (RandTemp)
                {
                    case 1:
                        QuestionData[k] = QCol1;
                        break;
                    case 2:
                        QuestionData[k] = QCol2;
                        break;
                    case 3:
                        QuestionData[k] = QCol3;
                        break;
                }

                decodedQuestionData[k] = QuestionData[k];
            }
        }
        else
        {
            for (int k = 0; k < QuestionData.Length; k++)
            {
                QuestionData[k] = Random.Range(1, difficulty);
                decodedQuestionData[k] = QuestionData[k];
            }
        }


    }



    public bool CrossCheck()
    {
        //Debug.Log("CrossCheckin...");
        for (int k = 0; k < QuestionData.Length; k++)
        {
            if (decodedQuestionData[k] == tileData[k])
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


    //this is cheat code
    public void cheatSheet()
    {
        for (int k = 0; k < QuestionData.Length; k++)
        {
            tileData[k] = decodedQuestionData[k];
        }
    }
    public void UpdateTiledata(int[] colorData)
    {
        for (int i = 0; i < colorData.Length; i++)
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
            if (decodedQuestionData[i] == color1)
            {
                decodedQuestionData[i] = color2;
            }
            else if (decodedQuestionData[i] == color2)
            {
                decodedQuestionData[i] = color1;
            }
        }
    }

    [System.Serializable]
    public class QuestionSet
    {
        public int Color1;
        public int Color2;
        public int Color3;

        public QuestionSet(int _c1, int _c2, int _c3)
        {
            Color1 = _c1;
            Color2 = _c2;
            Color3 = _c3;
        }
    }
}
