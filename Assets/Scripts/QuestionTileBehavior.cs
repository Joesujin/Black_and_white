using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTileBehavior : MonoBehaviour
{
    public Color selectedColor;
    public int color_id;
    public int ownColor;


    private void OnEnable()
    {
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
                selectedColor = Color.gray;
                break;
            case 1:
                selectedColor = Color.white;
                break;
            case 2:
                selectedColor = Color.black;
                break;
            case 3:
                selectedColor = Color.red;
                break;
            case 4:
                selectedColor = Color.blue;
                break;
            case 5:
                selectedColor = Color.green;
                break;
            case 6:
                selectedColor = Color.yellow;
                break;
        }
        GetComponent<SpriteRenderer>().color = selectedColor;


    }

}
