using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{

    public int RedbuttonId = 3;

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.red);
        Events.ColorId(RedbuttonId);
    }
}
