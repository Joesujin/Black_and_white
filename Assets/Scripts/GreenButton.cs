using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButton : MonoBehaviour
{
    /*THIS IS A BUTTON SCRIPT WHICH SETS THE INK OF THE CLICK TO GREEN*/

    //BUTTON ID CHANGABLE AT NOTICE

    int ButtonId = 5;

    public int GreenbuttonId = 5;
    public Color Greencolor = Color.green;

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Greencolor);
        Events.ColorId(GreenbuttonId);
    }

    public void ChangeColor(int colorID)
    {
        GreenbuttonId = colorID;
    }

    public void ChangeColorID(Color fakeColor)
    {
        Greencolor = fakeColor;

    }

    private void resetDefault()
    {
        GreenbuttonId = ButtonId;
        Greencolor = Color.green;
    }
}