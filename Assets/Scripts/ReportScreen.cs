using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportScreen : MonoBehaviour
{
    /*THIS ENABLES AND DISABLES DRAWING CANVAS*/

    public bool visible;
    public GameObject StartButton;
    public GameObject RestartButton;
    public GameObject MorningScreen;
    bool isActive =true;

    private void Start()
    {
        RestartButton.SetActive(false);
        visible = false;
        gameObject.SetActive(visible);
        MorningScreen.SetActive(isActive);
        Events.ReportScreen += visiblity;
        Events.EndGame += DisableStartDayButton;
    }

  

    private void OnDestroy()
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
        StartButton.SetActive(false);
        RestartButton.SetActive(true);
    }

    public void NewSScreen()
    {
        isActive = !isActive;
        MorningScreen.SetActive(isActive);
    }
}
