using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeScreen : MonoBehaviour
{
    public bool visible;

    public Text noticeText;

    public Color C1;
    public Color C2;

    public GameObject img1;
    public GameObject img2;

    private void Start()
    {
        visible = false;
        gameObject.SetActive(visible);
        
        Events.noticeScreen += visiblity;
        Events.ChangeNotice += changeNoticeText;
    }


    private void OnDestroy()
    {
        Events.ChangeNotice -= changeNoticeText;

        Events.noticeScreen -= visiblity;
    }


    public void visiblity()
    {
        visible = !visible;
        gameObject.SetActive(visible);
    }

    public void changeNoticeText(Color _c1, Color _c2, string tempText)
    {
        img1.GetComponent<Image>().color = _c1;
        img2.GetComponent<Image>().color = _c2;

        //noticeText.text = tempText;
    } 

    public void closeNoticeScreen()
    {
        visible = !visible;
        gameObject.SetActive(visible);
        //Events.resumeDayCounter();
    }
}
