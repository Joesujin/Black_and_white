using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportScreen : MonoBehaviour
{
    /*THIS ENABLES AND DISABLES DRAWING CANVAS*/

    public bool visible;
    public GameObject StartDayButton;
    public GameObject RestartButton;


    private void Start()
    {
        RestartButton.SetActive(false);
        visible = true;
        gameObject.SetActive(visible);
        Events.ReportScreen += visiblity;
        Events.EndGame += DisableStartDayButton;
    }

    private void OnApplicationQuit()
    {
        Events.ReportScreen -= visiblity;
        Events.EndGame -= DisableStartDayButton;
    }


    public void visiblity()
    {
        visible = !visible;
        gameObject.SetActive(visible);

    }

    public void DisableStartDayButton()
    {
        StartDayButton.SetActive(false);
        RestartButton.SetActive(true);
    }
}
