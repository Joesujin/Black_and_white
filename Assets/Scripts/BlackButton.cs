using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackButton : MonoBehaviour
{
    public int BlackbuttonId =2;


    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.black);
        Events.ColorId(BlackbuttonId);
    }
}
