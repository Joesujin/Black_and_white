using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButton : MonoBehaviour
{

    public int BluebuttonId = 4;

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.blue);
        Events.ColorId(BluebuttonId);

    }
}
