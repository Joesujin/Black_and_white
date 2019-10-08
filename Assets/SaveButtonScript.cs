using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButtonScript : MonoBehaviour
{

    public int projectId;
    Button SaveButton;

    void Start()
    {
        //projectId = 4;

        Events.ButtonCall += getProjectID;
        Events.saveInital += getProjectID;
        SaveButton = GetComponent<Button>();
       // Debug.Log("im here");
        SaveButton.onClick.AddListener(() => callProject());

       // Debug.Log("still here");
    }

    void getProjectID(int _tempid)
    {
        //Debug.Log("under ma ffeeeett");
        this.projectId = _tempid;
    }

    void callProject()
    {
        //Debug.Log("MOFOIDDDD " + projectId);

        Events.saveButton(projectId);
        //Debug.Log("savebutton"+projectId);
        //projectId++;
    }

}

