﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawScreen : MonoBehaviour
{
    public bool visible;

    private void Start()
    {
        visible = false;
        gameObject.SetActive(visible);
        Events.drawScreen += visiblity;
        Events.projectScreen += visiblity;
        Events.RecallDrawscreen += visiblity;
    }

    private void OnApplicationQuit()
    {
        Events.drawScreen -= visiblity;
        Events.projectScreen -= visiblity;
        Events.RecallDrawscreen -= visiblity;

    }


    public void visiblity()
    {
        visible = !visible;
        gameObject.SetActive(visible);

    }
}
