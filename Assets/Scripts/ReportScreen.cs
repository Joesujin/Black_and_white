using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportScreen : MonoBehaviour
{
    /*THIS ENABLES AND DISABLES DRAWING CANVAS*/

    public bool visible;

    private void Start()
    {
        visible = true;
        gameObject.SetActive(visible);
        Events.ReportScreen += visiblity;
    }

    private void OnApplicationQuit()
    {
        Events.ReportScreen -= visiblity;
    }


    public void visiblity()
    {
        visible = !visible;
        gameObject.SetActive(visible);

    }
}
