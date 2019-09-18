using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    int dayCount = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    IEnumerator Daytimer()
    {
        dayCount++;
        yield return new WaitForSeconds(60);
    }
    
}
