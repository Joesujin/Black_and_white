using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    /*THIS IS A BUTTON SCRIPT WHICH SETS THE INK OF THE CLICK TO RED*/

    //BUTTON ID CHANGABLE AT NOTICE
    public int RedbuttonId = 3;

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.red);
        Events.ColorId(RedbuttonId);
    }
}
