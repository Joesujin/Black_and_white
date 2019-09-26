using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteButton : MonoBehaviour
{
    public int WhitebuttonId= 0;

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.white);
        Events.ColorId(WhitebuttonId);
    }
}
