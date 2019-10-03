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
        projectId = 4;
        Events.ButtonCall += getProjectID;
        SaveButton = this.GetComponent<Button>();
        Debug.Log("im here");
        SaveButton.onClick.AddListener(() => callProject(projectId));

        Debug.Log("still here");
    }

    void getProjectID(int _tempid)
    {
        projectId = _tempid;
    }

    void callProject(int _tepid)
    {
        Events.saveButton(_tepid);
        Debug.Log(_tepid);
        //projectId++;
    }

}

