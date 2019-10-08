using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackButton : MonoBehaviour
{
    /*THIS IS A BUTTON SCRIPT WHICH SETS THE INK OF THE CLICK TO BLACK*/

    //BUTTON ID CHANGABLE AT NOTICE
    public int BlackbuttonId =2;


    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.black);
        Events.ColorId(BlackbuttonId);
    }
}
