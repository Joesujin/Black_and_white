using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyreportScreen : MonoBehaviour
{
    /*THIS ENABLES AND DISABLES DRAWING CANVAS*/

    public bool visible;

    private void Start()
    {
        visible = true;
        gameObject.SetActive(visible);
        Events.DailyReport += visiblity;
        //Events.drawScreen += visiblity;

    }

    private void OnApplicationQuit()
    {
        Events.DailyReport -= visiblity;
        //Events.drawScreen -= visiblity;


    }


    public void visiblity()
    {
        visible = !visible;
        gameObject.SetActive(visible);
        
    }
}
