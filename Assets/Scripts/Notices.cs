using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Notices 
{
    public GameObject color_1;
    public GameObject color_2;
    public int NoticeID = 0;
    GameObject gamestate = GameObject.Find("GameManager");


    public int colorID_1;
    public int colorID_2;
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
                colorID_1 = _clr1;
                Color1Name = gamestate.GetComponent<GameState>().DefaultColors[_clr1].ToString();
                break;
            case 2:
                color_1 = gamestate.GetComponent<GameState>().BlackButton;
                colorID_1 = _clr1;
                Color1Name = gamestate.GetComponent<GameState>().DefaultColors[_clr1].ToString();
                break;
            case 3:
                color_1 = gamestate.GetComponent<GameState>().RedButton;
                colorID_1 = _clr1;
                Color1Name = gamestate.GetComponent<GameState>().DefaultColors[_clr1].ToString();
                break;
            case 4:
                color_1 = gamestate.GetComponent<GameState>().BlueButton;
                colorID_1 = _clr1;
                Color1Name = gamestate.GetComponent<GameState>().DefaultColors[_clr1].ToString();
                break;
            case 5:
                color_1 = gamestate.GetComponent<GameState>().GreenButton;
                colorID_1 = _clr1;
                Color1Name = gamestate.GetComponent<GameState>().DefaultColors[_clr1].ToString();
                break;
            case 6:
                color_1 = gamestate.GetComponent<GameState>().YellowButton;
                colorID_1 = _clr1;
                Color1Name = gamestate.GetComponent<GameState>().DefaultColors[_clr1].ToString();
                break;
        }

        switch (_clr2)
        {
            case 0:
                break;
            case 1:
                color_2 = gamestate.GetComponent<GameState>().WhiteButton;
                colorID_1 = _clr1;
                Color1Name = gamestate.GetComponent<GameState>().DefaultColors[_clr1].ToString();
                break;
            case 2:
                color_2 = gamestate.GetComponent<GameState>().BlackButton;
                colorID_1 = _clr1;
                Color1Name = gamestate.GetComponent<GameState>().DefaultColors[_clr1].ToString();
                break;
            case 3:
                color_2 = gamestate.GetComponent<GameState>().RedButton;
                colorID_1 = _clr1;
                Color1Name = gamestate.GetComponent<GameState>().DefaultColors[_clr1].ToString();
                break;
            case 4:
                color_2 = gamestate.GetComponent<GameState>().BlueButton;
                colorID_1 = _clr1;
                Color1Name = gamestate.GetComponent<GameState>().DefaultColors[_clr1].ToString();
                break;
            case 5:
                color_2 = gamestate.GetComponent<GameState>().GreenButton;
                colorID_1 = _clr1;
                Color1Name = gamestate.GetComponent<GameState>().DefaultColors[_clr1].ToString();
                break;
            case 6:
                color_2 = gamestate.GetComponent<GameState>().YellowButton;
                colorID_1 = _clr1;
                Color1Name = gamestate.GetComponent<GameState>().DefaultColors[_clr1].ToString();
                break;
        }

        NoticeID++;
        //colorID_1 = color_1.GetComponent<WhiteButton>().ColorbuttonId;
        //colorID_2 = color_2.GetComponent<WhiteButton>().ColorbuttonId;


    }

    public void ChangecolorMeaning()
    {
        /*
        int tempC1 = color_1.GetComponent<WhiteButton>().ColorbuttonId;
        int tempC2 = color_2.GetComponent<WhiteButton>().ColorbuttonId;


        string NameC1 = color_1.GetComponent<WhiteButton>().colorName;
        string NameC2 = color_2.GetComponent<WhiteButton>().colorName;
        */
        

        Color tempcol = gamestate.GetComponent<GameState>().inGameColors[this.colorID_1];
        gamestate.GetComponent<GameState>().inGameColors[this.colorID_1] = gamestate.GetComponent<GameState>().inGameColors[this.colorID_2];
        gamestate.GetComponent<GameState>().inGameColors[this.colorID_2] = tempcol;

        //color_1.GetComponent<WhiteButton>().ChangeColorID(tempC2);
        //color_2.GetComponent<WhiteButton>().ChangeColorID(tempC1);

        //color_1.GetComponent<WhiteButton>().ChangeColorName(NameC2);
        //color_2.GetComponent<WhiteButton>().ChangeColorName(NameC1);

        NoticeMessage = this.Color1Name.ToString() + " is " + this.Color2Name.ToString() + " and " + this.Color2Name.ToString() + " is "+this.Color1Name.ToString() ;
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
