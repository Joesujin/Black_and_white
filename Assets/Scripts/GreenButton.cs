using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButton : MonoBehaviour
{

    public int GreenbuttonId = 4;
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
        Events.ChangeColor(Color.green);
        Events.ColorId(GreenbuttonId);
    }
}
