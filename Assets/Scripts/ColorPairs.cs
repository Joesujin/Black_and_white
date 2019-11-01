using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorPairs 
{
    public int Color1;
    public int Color2;

    public ColorPairs(int _c1,int _c2)
    {
        Color1 = _c1;
        Color2 = _c2;
    }
}
