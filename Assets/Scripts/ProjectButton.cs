using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectButton : MonoBehaviour
{
    public string projectName;
    public int projectId;
    Button projectButton;


    private void Start()
    {
        projectButton = this.GetComponent<Button>();
        projectButton.onClick.AddListener(() => ButtonClicked(projectId));
        //this.gameObject.GetComponent<Text>().text = "Project " + projectId.ToString();
    }

    public void GetbuttonID(int currentProjectID)
    {
        projectId = currentProjectID;
        this.name = "Project "+projectId.ToString();
        //this.gameObject.GetComponent<Text>().text = "Project " + projectId.ToString();
        
    }

    void ButtonClicked(int _projectId)
    {
        Events.ButtonCall(_projectId);
    }


}
