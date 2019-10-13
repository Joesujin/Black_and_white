using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeScreen : MonoBehaviour
{
    public bool visible;

    public Text noticeText;

    private void Start()
    {
        visible = false;
        gameObject.SetActive(visible);
        
        Events.noticeScreen += visiblity;
        Events.ChangeNotice += changeNoticeText;
    }


    private void OnApplicationQuit()
    {
        Events.ChangeNotice -= changeNoticeText;

        Events.noticeScreen -= visiblity;
    }


    public void visiblity()
    {
        visible = !visible;
        gameObject.SetActive(visible);
    }

    public void changeNoticeText(string tempText)
    {
        noticeText.text = tempText;
    } 

    public void closeNoticeScreen()
    {
        visible = !visible;
        gameObject.SetActive(visible);
        //Events.resumeDayCounter();
    }
}
