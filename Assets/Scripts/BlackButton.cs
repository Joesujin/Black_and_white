using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackButton : MonoBehaviour
{
    int colorId;

    // Start is called before the first frame update
    void Start()
    {
        colorId = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        //return (colorId);      
        Events.ChangeColor(Color.black);
    }
}
