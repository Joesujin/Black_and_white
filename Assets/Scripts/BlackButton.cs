using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackButton : MonoBehaviour
{
    /*THIS IS A BUTTON SCRIPT WHICH SETS THE INK OF THE CLICK TO BLACK*/

    //BUTTON ID CHANGABLE AT NOTICE
    int ButtonId = 2;


    public int BlackbuttonId =2;
    public Color Blackcolor = Color.black; 

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Blackcolor);
        Events.ColorId(BlackbuttonId);
    }

    public void ChangeColor(int colorID)
    {
        BlackbuttonId = colorID;
    }
    public void ChangeColorID(Color fakeColor)
    {
        Blackcolor = fakeColor;
    }

    private void resetDefault()
    {
        BlackbuttonId = ButtonId;
        Blackcolor = Color.black;
    }
}
