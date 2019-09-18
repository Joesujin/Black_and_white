using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{

    Color selectedColor;


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
    }

    private void OnDisable()
    {
        Events.ChangeColor -= changeColor;
    }

    private void OnMouseDrag()
    {
        GetComponent<SpriteRenderer>().color = selectedColor;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = selectedColor;
    }

    private void changeColor(Color colorid)
    {
        //change the color
        selectedColor = colorid;

    }
}
