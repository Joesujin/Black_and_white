using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{

    public bool visible;
    public GameObject gamemanager;

    //void Start()
    //{
    //    this.gameObject.SetActive(false);
    //}



    public void visiblity()
    {
        visible = !visible;
        gameObject.SetActive(visible);
    }
}
