using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{

    public Color selectedColor;
    public int color_id;
    public int ownColor;
    //List<Color, Vector3>;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        Events.ChangeColor += changeColor;
        Events.ColorId += changeColorId;
    }

    private void OnDisable()
    {
        Events.ChangeColor -= changeColor;
        Events.ColorId -= changeColorId;
    }

    
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = selectedColor;
        //Debug.Log(color_id);
        this.ownColor = color_id;
    }

    private void changeColor(Color color)
    {
        //change the color
        selectedColor = color;

    }

    private void changeColorId(int colorid)
    {
        color_id = colorid;
    }

    public int returnColor()
    {
        return (ownColor);
    }
}
