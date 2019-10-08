using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButton : MonoBehaviour
{
    /*THIS IS A BUTTON SCRIPT WHICH SETS THE INK OF THE CLICK TO GREEN*/

    //BUTTON ID CHANGABLE AT NOTICE
    public int GreenbuttonId = 5;

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.green);
        Events.ColorId(GreenbuttonId);
    }
}
