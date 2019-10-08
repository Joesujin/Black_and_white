using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowButton : MonoBehaviour
{
    /*THIS IS A BUTTON SCRIPT WHICH SETS THE INK OF THE CLICK TO YELLOW*/

    //BUTTON ID CHANGABLE AT NOTICE

    public int YellowbuttonId = 6;


    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.yellow);
        Events.ColorId(YellowbuttonId);
    }
}
