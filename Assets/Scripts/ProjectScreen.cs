using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectScreen : MonoBehaviour
{
    public bool visible;
    public GameObject gamemanager;

    private void Start()
    {
        visible = true;
        gameObject.SetActive(visible);
        Events.drawScreen += visiblity;
        Events.projectScreen += visiblity;
        Events.RecallDrawscreen += visiblity;
    }

    private void Update()
    {
        if(gamemanager.GetComponent<GameState>().projects.Count != 0)
        {
            gamemanager.GetComponent<GameState>().CheckProjectCorrectness();
        }
    }

    private void OnDestroy()
    {
        Events.drawScreen -= visiblity;
        Events.projectScreen -= visiblity;
        Events.RecallDrawscreen -= visiblity;
    }


    public void visiblity()
    {
        visible = !visible;
        gameObject.SetActive(visible);
        if (visible)
        {
            Events.CheckProjectStatus();
        }
        
    }
}
