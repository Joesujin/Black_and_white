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
        Debug.Log("im stiiiiiiiillllll here");

        projectButton = this.GetComponent<Button>();
        projectButton.onClick.AddListener(() => ButtonClicked());
        //projectButton.GetComponent<Text>().text = projectId.ToString();
        this.gameObject.GetComponentInChildren<Text>().text =  projectId.ToString();
    }

    public void GetbuttonID(int currentProjectID)
    {
        projectId = currentProjectID;
        this.name = "Project "+projectId.ToString();
        //this.gameObject.GetComponent<Text>().text = "Project " + projectId.ToString();
        
    }

    void ButtonClicked()
    {
        Debug.Log("eat shit!");
        Events.ButtonCall(this.projectId);
        //Events.preButtonCall(this.projectId);

    }

    public int returnButtonID()
    {
        return (this.projectId);
    }


}
