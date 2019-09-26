using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int dayCount = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Daytimer());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    IEnumerator Daytimer()
    {

        while (gameObject)
        {
            dayCount++;
            Debug.Log(dayCount);
            yield return new WaitForSeconds(2);
        }
        
    }
    
}
