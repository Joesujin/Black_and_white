using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButton : MonoBehaviour
{
    /*THIS IS A BUTTON SCRIPT WHICH SETS THE INK OF THE CLICK TO BLUE*/

    //BUTTON ID CHANGABLE AT NOTICE
    int ButtonId = 4;


    public int BluebuttonId = 4;
    public Color Bluecolor = Color.blue;

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Bluecolor);
        Events.ColorId(BluebuttonId);

    }

    public void ChangeColor(int colorID)
    {
        BluebuttonId = colorID;
    }

    public void ChangeColorID(Color fakeColor)
    {
        Bluecolor = fakeColor;

    }

    private void resetDefault()
    {
        BluebuttonId = ButtonId;
        Bluecolor = Color.blue;
    }
}
