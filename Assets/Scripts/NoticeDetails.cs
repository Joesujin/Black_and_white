using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeDetails : MonoBehaviour
{
    public Color C1;
    public Color C2;

    public GameObject Color1;
    public GameObject Color2;

    public Text NoticeNumber;

    public void NoticeInfoChange(Color _c1, Color _c2, int _Noticenumber)
    {
        this.Color1.GetComponent<Image>().color = _c1;
        this.Color2.GetComponent<Image>().color = _c2;

        this.NoticeNumber.text = "Notice -" + _Noticenumber.ToString();
    }
}
