using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{

    public Color selectedColor;
    public int color_id;
    public int ownColor;

    bool colorChanged;



    private void OnEnable()
    {
        this.GetComponent<SpriteRenderer>().color = Color.grey;
        ownColor = 0;
        colorChanged = true;
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
        //Debug.Log(color_id);
        this.ownColor = color_id;
    }

    private void changeColor(Color color)
    {
        //change the color
        this.selectedColor = color;

    }

    public void ChangeColorWithID(int _colorId)
    {
        int Colorid = _colorId;

        switch (Colorid)
        {
            case 0:
                this.changeColor(Color.grey);
                break;
            case 1:
                this.changeColor(Color.white);
                break;
            case 2:
                this.changeColor(Color.cyan);
                break;
            case 3:
                this.changeColor(Color.red);
                break;
            case 4:
                this.changeColor(Color.blue);
                break;
            case 5:
                this.changeColor(Color.green);
                break;
            case 6:
                this.changeColor(Color.yellow);
                break;
        }
        GetComponent<SpriteRenderer>().color = selectedColor;


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
