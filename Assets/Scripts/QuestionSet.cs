using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
