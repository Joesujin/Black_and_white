using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    /*THIS IS A BUTTON SCRIPT WHICH SETS THE INK OF THE CLICK TO RED*/

    //BUTTON ID CHANGABLE AT NOTICE

    int ButtonId = 3;

    public int RedbuttonId = 3;
    public Color Redcolor = Color.red;

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Redcolor);
        Events.ColorId(RedbuttonId);
    }

    public void ChangeColor(int colorID)
    {
        RedbuttonId = colorID;
    }

    public void ChangeColorID(Color fakeColor)
    {
        Redcolor = fakeColor;

    }

    private void resetDefault()
    {
        RedbuttonId = ButtonId;
        Redcolor = Color.red;
    }
}

