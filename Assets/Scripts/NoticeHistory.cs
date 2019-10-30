using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeHistory : MonoBehaviour
{
    /*THIS ENABLES AND DISABLES DRAWING CANVAS*/

    public bool visible;

    private void Start()
    {
        visible = false;
        gameObject.SetActive(visible);
        Events.NoticeHistory += visiblity;
    }

    private void OnDestroy()
    {
        Events.NoticeHistory -= visiblity;
    }


    public void visiblity()
    {
        visible = !visible;
        gameObject.SetActive(visible);

    }
}
