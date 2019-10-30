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
        Events.ButtonCall += getProjectID;
        Events.saveInital += getProjectID;
        SaveButton = GetComponent<Button>();
        SaveButton.onClick.AddListener(() => callProject());
    }

    private void OnDestroy()
    {
        Events.ButtonCall -= getProjectID;
        Events.saveInital -= getProjectID;
    }
    void getProjectID(int _tempid)
    {
        this.projectId = _tempid;
    }

    void callProject()
    {
        Events.saveButton(projectId);
        
    }

}

