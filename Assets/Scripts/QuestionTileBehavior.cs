using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTileBehavior : MonoBehaviour
{
    public Color selectedColor;
    public int color_id;
    public int ownColor;
    public GameObject gameState;



    private void OnEnable()
    {
        gameState = GameObject.Find("GameManager");

        selectedColor = Color.gray;

        this.GetComponent<SpriteRenderer>().color = selectedColor;
               
    }

    public void ChangeColorWithID(int _colorId)
    {
        int Colorid = _colorId;
        this.ownColor = _colorId;

        switch (Colorid)
        {
            case 0:
                selectedColor = gameState.GetComponent<GameState>().DefaultColors[Colorid];
                break;
            case 1:
                selectedColor = gameState.GetComponent<GameState>().DefaultColors[Colorid];
                break;
            case 2:
                selectedColor = gameState.GetComponent<GameState>().DefaultColors[Colorid];
                break;
            case 3:
                selectedColor = gameState.GetComponent<GameState>().DefaultColors[Colorid];
                break;
            case 4:
                selectedColor = gameState.GetComponent<GameState>().DefaultColors[Colorid];
                break;
            case 5:
                selectedColor = gameState.GetComponent<GameState>().DefaultColors[Colorid];
                break;
            case 6:
                selectedColor = gameState.GetComponent<GameState>().DefaultColors[Colorid];
                break;
        }
        GetComponent<SpriteRenderer>().color = selectedColor;


    }

}
