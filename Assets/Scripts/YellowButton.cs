using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowButton : MonoBehaviour
{
    /*THIS IS A BUTTON SCRIPT WHICH SETS THE INK OF THE CLICK TO YELLOW*/

    //BUTTON ID CHANGABLE AT NOTICE
    int ButtonId = 6;


    public int YellowbuttonId = 6;
    public Color Yellowcolor = Color.yellow;

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Yellowcolor);
        Events.ColorId(YellowbuttonId);
    }

    public void ChangeColor(int colorID)
    {
        YellowbuttonId = colorID;
    }

    public void ChangeColorID(Color fakeColor)
    {
        Yellowcolor = fakeColor;

    }

    private void resetDefault()
    {
        YellowbuttonId = ButtonId;
        Yellowcolor = Color.yellow;
    }
}