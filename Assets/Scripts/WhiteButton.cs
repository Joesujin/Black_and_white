using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteButton : MonoBehaviour
{
    public int WhitebuttonId= 1;


    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.white);
        Events.ColorId(WhitebuttonId);
    }
}
