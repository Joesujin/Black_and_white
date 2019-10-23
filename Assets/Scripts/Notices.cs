using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Notices
{
    public int NoticeID = 0;
    GameObject gamestate = GameObject.Find("GameManager");


    public int colorID_1;
    public int colorID_2;
    public string Color1Name;
    public string Color2Name;
    public Color C1;
    public Color C2;

    public string NoticeMessage;

    public Notices(int _clr1, int _clr2)
    {

        switch (_clr1)
        {
            case 0:
                break;
            case 1:
                colorID_1 = _clr1;
                C1 = gamestate.GetComponent<GameState>().DefaultColors[_clr1];
                Color1Name = "White";

                break;
            case 2:
                colorID_1 = _clr1;
                C1 = gamestate.GetComponent<GameState>().DefaultColors[_clr1];
                Color1Name = "Black";

                break;
            case 3:
                colorID_1 = _clr1;
                C1 = gamestate.GetComponent<GameState>().DefaultColors[_clr1];
                Color1Name = "Red";

                break;
            case 4:
                colorID_1 = _clr1;
                C1 = gamestate.GetComponent<GameState>().DefaultColors[_clr1];
                Color1Name = "Blue";

                break;
            case 5:
                colorID_1 = _clr1;
                C1 = gamestate.GetComponent<GameState>().DefaultColors[_clr1];
                Color1Name = "Green";

                break;
            case 6:
                colorID_1 = _clr1;
                C1 = gamestate.GetComponent<GameState>().DefaultColors[_clr1];
                Color1Name = "Yellow";

                break;
        }

        switch (_clr2)
        {
            case 0:
                break;
            case 1:
                colorID_2 = _clr2;
                C2 = gamestate.GetComponent<GameState>().DefaultColors[_clr2];
                Color2Name = "White";
                break;
            case 2:
                colorID_2 = _clr2;
                C2 = gamestate.GetComponent<GameState>().DefaultColors[_clr2];
                Color2Name = "Black";
                break;
            case 3:
                colorID_2 = _clr2;
                C2 = gamestate.GetComponent<GameState>().DefaultColors[_clr2];
                Color2Name = "Red";

                break;
            case 4:
                colorID_2 = _clr2;
                C2 = gamestate.GetComponent<GameState>().DefaultColors[_clr2];
                Color2Name = "Blue";

                break;
            case 5:
                colorID_2 = _clr2;
                C2 = gamestate.GetComponent<GameState>().DefaultColors[_clr2];
                Color2Name = "Green";

                break;
            case 6:
                colorID_2 = _clr2;
                C2 = gamestate.GetComponent<GameState>().DefaultColors[_clr2];
                Color2Name = "Yellow";

                break;
        }

        NoticeID++;


    }

    public void ChangecolorMeaning()
    {

        int tempC1 = this.colorID_1;
        int tempC2 = this.colorID_2;

        string NameC1 = this.Color1Name;
        string NameC2 = this.Color2Name;

        Color tempcol = gamestate.GetComponent<GameState>().inGameColors[tempC1];
        gamestate.GetComponent<GameState>().inGameColors[tempC1] = gamestate.GetComponent<GameState>().inGameColors[tempC2];
        gamestate.GetComponent<GameState>().inGameColors[tempC2] = tempcol;

        NoticeMessage = NameC1 + " is " + NameC2 + " and " + NameC2 + " is " + NameC1;
        Debug.Log(NoticeMessage);

    }

    /*
    public void ChangecolorLooks()
    {
        Color ColorC1 = color_1.GetComponent<WhiteButton>().color;
        Color ColorC2 = color_2.GetComponent<WhiteButton>().color;

        color_1.GetComponent<WhiteButton>().ChangeColor(ColorC1);
        color_2.GetComponent<WhiteButton>().ChangeColor(ColorC2);
    }
    */



}
