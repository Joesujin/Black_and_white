using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{

    public int RedbuttonId = 2;

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
        Events.ChangeColor(Color.red);
        Events.ColorId(RedbuttonId);
    }
}
