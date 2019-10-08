using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteButton : MonoBehaviour
{
    /*THIS IS A BUTTON SCRIPT WHICH SETS THE INK OF THE CLICK TO WHITE*/

    //BUTTON ID CHANGABLE AT NOTICE
    public int WhitebuttonId= 1;


    public void onClick()
    {
        Events.ChangeColor(Color.white);
        Events.ColorId(WhitebuttonId);
    }
}
