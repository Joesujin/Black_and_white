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
        projectButton.onClick.AddListener(() => ButtonClicked());
        this.gameObject.GetComponentInChildren<Text>().text =  projectId.ToString();
    }

    public void GetbuttonID(int currentProjectID)
    {
        projectId = currentProjectID;
        this.name = "Project "+projectId.ToString();
    }

    void ButtonClicked()
    {
        Events.ButtonCall(this.projectId);
    }

    public int returnButtonID()
    {
        return (this.projectId);
    }


}
