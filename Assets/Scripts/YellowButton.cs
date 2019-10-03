using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowButton : MonoBehaviour
{

    public int YellowbuttonId = 6;


    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.yellow);
        Events.ColorId(YellowbuttonId);
    }
}
