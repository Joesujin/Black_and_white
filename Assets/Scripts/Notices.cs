using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Notices 
{
    public GameObject color_1;
    public GameObject color_2;

    GameObject gamestate = GameObject.Find("GameManager");

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
                color_1 = gamestate.GetComponent<GameState>().WhiteButton;
                break;
            case 2:
                color_1 = gamestate.GetComponent<GameState>().BlackButton;
                break;
            case 3:
                color_1 = gamestate.GetComponent<GameState>().RedButton;
                break;
            case 4:
                color_1 = gamestate.GetComponent<GameState>().BlueButton;
                break;
            case 5:
                color_1 = gamestate.GetComponent<GameState>().GreenButton;
                break;
            case 6:
                color_1 = gamestate.GetComponent<GameState>().YellowButton;
                break;
        }

        switch (_clr2)
        {
            case 0:
                break;
            case 1:
                color_2 = gamestate.GetComponent<GameState>().WhiteButton;
                break;
            case 2:
                color_2 = gamestate.GetComponent<GameState>().BlackButton;
                break;
            case 3:
                color_2 = gamestate.GetComponent<GameState>().RedButton;
                break;
            case 4:
                color_2 = gamestate.GetComponent<GameState>().BlueButton;
                break;
            case 5:
                color_2 = gamestate.GetComponent<GameState>().GreenButton;
                break;
            case 6:
                color_2 = gamestate.GetComponent<GameState>().YellowButton;
                break;
        }




    }

    public void ChangecolorMeaning()
    {
        int tempC1 = color_1.GetComponent<WhiteButton>().ColorbuttonId;
        int tempC2 = color_2.GetComponent<WhiteButton>().ColorbuttonId;

        string NameC1 = color_1.GetComponent<WhiteButton>().colorName;
        string NameC2 = color_2.GetComponent<WhiteButton>().colorName;

        Color tempcol = gamestate.GetComponent<GameState>().inGameColors[tempC1];
        gamestate.GetComponent<GameState>().inGameColors[tempC1] = gamestate.GetComponent<GameState>().inGameColors[tempC2];
        gamestate.GetComponent<GameState>().inGameColors[tempC2] = tempcol;

        //color_1.GetComponent<WhiteButton>().ChangeColorID(tempC2);
        //color_2.GetComponent<WhiteButton>().ChangeColorID(tempC1);

        //color_1.GetComponent<WhiteButton>().ChangeColorName(NameC2);
        //color_2.GetComponent<WhiteButton>().ChangeColorName(NameC1);

        NoticeMessage = NameC1.ToString() + " is " + NameC2.ToString() + " and " + NameC2.ToString() + " is "+NameC1.ToString() ;
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
