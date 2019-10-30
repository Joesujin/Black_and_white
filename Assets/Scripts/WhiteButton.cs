using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteButton : MonoBehaviour
{
    /*THIS IS A BUTTON SCRIPT WHICH SETS THE INK OF THE CLICK TO WHITE*/

    //BUTTON ID CHANGABLE AT NOTICE


    public int DefaultButtonId=0;
    public string colorName;
    public int ColorbuttonId=0;
    public Color color= Color.gray;
    /*
public GameObject gameState = GameObject.Find("GameManager");
private void OnEnable()
{
    switch (this.DefaultButtonId)
    {
        case 1:
            this.color = gameState.GetComponent<GameState>().DefaultColors[this.DefaultButtonId];
            this.gameObject.GetComponent<SpriteRenderer>().color = this.color;
            break;
        case 2:
            this.color = gameState.GetComponent<GameState>().DefaultColors[this.DefaultButtonId];
            this.gameObject.GetComponent<SpriteRenderer>().color = this.color;
            break;
        case 3:
            this.color = gameState.GetComponent<GameState>().DefaultColors[this.DefaultButtonId];
            this.gameObject.GetComponent<SpriteRenderer>().color = this.color;
            break;
        case 4:
            this.color = gameState.GetComponent<GameState>().DefaultColors[this.DefaultButtonId];
            this.gameObject.GetComponent<SpriteRenderer>().color = this.color;
            break;
        case 5:
            this.color = gameState.GetComponent<GameState>().DefaultColors[this.DefaultButtonId];
            this.gameObject.GetComponent<SpriteRenderer>().color = this.color;
            break;
        case 6:
            this.color = gameState.GetComponent<GameState>().DefaultColors[this.DefaultButtonId];
            this.gameObject.GetComponent<SpriteRenderer>().color = this.color;
            break;

    }
}
*/

    public void onClick()
    {
        Events.ChangeColor(this.color);
        Events.ColorId(this.ColorbuttonId);
    }

    public void ChangeColorID(int colorID)
    {
        this.ColorbuttonId = colorID;
    }

    public void ChangeColor(Color fakeColor)
    {
        this.color = fakeColor;
    }

    public void ChangeColorName(string fakeColor)
    {
        this.colorName = fakeColor;
    }

    private void resetDefault()
    {
        this.ColorbuttonId = DefaultButtonId;
        this.color = Color.white;
    }
}
