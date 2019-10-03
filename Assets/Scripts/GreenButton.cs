using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButton : MonoBehaviour
{

    public int GreenbuttonId = 5;

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.green);
        Events.ColorId(GreenbuttonId);
    }
}
