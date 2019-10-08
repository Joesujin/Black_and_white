using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButton : MonoBehaviour
{
    /*THIS IS A BUTTON SCRIPT WHICH SETS THE INK OF THE CLICK TO BLUE*/

    //BUTTON ID CHANGABLE AT NOTICE
    public int BluebuttonId = 4;

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.blue);
        Events.ColorId(BluebuttonId);

    }
}
