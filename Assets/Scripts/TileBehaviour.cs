﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileBehaviour : MonoBehaviour
{
    
    public GameObject gameState;

    public Color selectedColor;
    public int color_id;
    public int ownColor;

    bool colorChanged;



    private void OnEnable()
    {
        gameState = GameObject.Find("GameManager");
        this.GetComponent<SpriteRenderer>().color = Color.grey;
        ownColor = 0;
        colorChanged = false;
        selectedColor = gameState.GetComponent<GameState>().SelectedColor;
        color_id = gameState.GetComponent<GameState>().SelectedColorID;


        Events.ChangeColor += changeColor;
        Events.ColorId += changeColorId;
        Events.refreshTile += ChangeColorWithID;
    }

    private void OnDisable()
    {
        Events.ChangeColor -= changeColor;
        Events.ColorId -= changeColorId;
        Events.refreshTile -= ChangeColorWithID;
    }

    
    
    private void OnMouseDown()
    {
        this.GetComponent<SpriteRenderer>().color = selectedColor;
        this.colorChanged = true;
        this.ownColor = color_id;
    }
    
    private void OnMouseEnter()
    {
        if(Input.GetMouseButton(0) == true)
        {
            this.GetComponent<SpriteRenderer>().color = selectedColor;
            this.colorChanged = true;
            this.ownColor = color_id;
        }
    }
    

    private void changeColor(Color color)
    {
        this.selectedColor = color;
    }

    public void ChangeColorWithID(int _colorId)
    {
        int Colorid = _colorId;
        this.ownColor = _colorId;

        switch (Colorid)
        {
            case 0:
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
            case 1:
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
            case 2:
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
            case 3:
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
            case 4:
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
            case 5:
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
            case 6:
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
        }
        GetComponent<SpriteRenderer>().color = selectedColor;
        selectedColor = gameState.GetComponent<GameState>().SelectedColor;
        color_id = gameState.GetComponent<GameState>().SelectedColorID;

    }

    private void changeColorId(int colorid)
    {
        this.color_id = colorid;
    }

    public int returnColor()
    {
        return(ownColor);
    }

    public bool ColorChanged()
    {
        return (colorChanged);
    }
}
