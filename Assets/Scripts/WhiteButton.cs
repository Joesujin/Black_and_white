using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteButton : MonoBehaviour
{
    int WhitecolorId;

    // Start is called before the first frame update
    void Start()
    {
        WhitecolorId = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.white);
    }
}
