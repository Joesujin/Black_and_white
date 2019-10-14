using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Notices 
{
    public GameObject color_1;
    public GameObject color_2;

    public int colorID1;
    public int colorID2;

    public string Color1Name;
    public string Color2Name;

    public string NoticeMessage;

    public Notices(int _clr1 , int _clr2)
    {

        switch (_clr1)
        {
            case 0:
                break;
            case 1:
                color_1 = GameObject.Find("WhiteButton");
                colorID1 = 1;
                break;
            case 2:
                color_1 = GameObject.Find("BlackButton");
                colorID1 = 2;
                break;
            case 3:
                color_1 = GameObject.Find("RedButton");
                colorID1 = 3;
                break;
            case 4:
                color_1 = GameObject.Find("BlueButton");
                colorID1 = 4;
                break;
            case 5:
                color_1 = GameObject.Find("GreenButton");
                colorID1 = 5;
                break;
            case 6:
                color_1 = GameObject.Find("YellowButton");
                colorID1 = 6;
                break;
        }

        switch (_clr2)
        {
            case 0:
                break;
            case 1:
                color_2 = GameObject.Find("WhiteButton");
                colorID2 = 1;
                break;
            case 2:
                color_2 = GameObject.Find("BlackButton");
                colorID2 = 2;
                break;
            case 3:
                color_2 = GameObject.Find("RedButton");
                colorID2 = 3;
                break;
            case 4:
                color_2 = GameObject.Find("BlueButton");
                colorID2 = 4;
                break;
            case 5:
                color_2 = GameObject.Find("GreenButton");
                colorID2 = 5;
                break;
            case 6:
                color_2 = GameObject.Find("YellowButton");
                colorID2 = 6;
                break;
        }




    }

    public void ChangecolorMeaning()
    {
        int tempC1 = color_1.GetComponent<WhiteButton>().ColorbuttonId;
        int tempC2 = color_2.GetComponent<WhiteButton>().ColorbuttonId;

        //colorID1 = tempC1;
        //colorID2 = tempC2;

        string NameC1 = color_1.GetComponent<WhiteButton>().colorName;
        string NameC2 = color_2.GetComponent<WhiteButton>().colorName;


        color_1.GetComponent<WhiteButton>().ChangeColorID(tempC2);
        color_2.GetComponent<WhiteButton>().ChangeColorID(tempC1);

        color_1.GetComponent<WhiteButton>().ChangeColorName(NameC2);
        color_2.GetComponent<WhiteButton>().ChangeColorName(NameC1);

        NoticeMessage = NameC1.ToString() + " will mean as " +NameC2.ToString()+" and vice versa";
        Debug.Log(NoticeMessage);

    }

    public void ChangecolorLooks()
    {
        Color ColorC1 = color_1.GetComponent<WhiteButton>().color;
        Color ColorC2 = color_2.GetComponent<WhiteButton>().color;

        color_1.GetComponent<WhiteButton>().ChangeColor(ColorC1);
        color_2.GetComponent<WhiteButton>().ChangeColor(ColorC2);

    }




}
