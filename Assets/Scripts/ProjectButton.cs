using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectButton : MonoBehaviour
{
    public GameObject Gamemanager;

    public string projectName;
    public int projectId;
    Button projectButton;

    public int projectStatus =0;

    public Color Correct;
    public Color inCorrect;

    public Sprite CorrectSprite;
    public Sprite IncorrectSptite;
    public Sprite NormalSprite;
    public Sprite rebelSprite;

    private void Start()
    {
        Gamemanager = GameObject.Find("GameManager");
        projectButton = this.GetComponent<Button>();
        projectButton.onClick.AddListener(() => ButtonClicked());
        int IDonButton = projectId + 1;
        this.gameObject.GetComponentInChildren<Text>().text = IDonButton.ToString();
        Events.CheckProjectStatus += statusMarker;
    }

    private void OnDestroy()
    {
        Events.CheckProjectStatus -= statusMarker;

    }

    public void GetbuttonID(int currentProjectID)
    {
        projectId = currentProjectID;
        int IDonButton = projectId + 1;
        this.name = "Project "+ IDonButton.ToString();
    }

    void ButtonClicked()
    {
        Events.ButtonCall(this.projectId);
    }

    public int returnButtonID()
    {
        return (this.projectId);
    }

    public void statusMarker()
    {

        bool ISPAss =Gamemanager.GetComponent<GameState>().projects[projectId].CrossCheck();
        bool isRebel = Gamemanager.GetComponent<GameState>().projects[projectId].RebelCheck();
        if (ISPAss)
        {
            projectStatus = 1;
        }
        else if(!ISPAss)
        {
            projectStatus = 2;
        }

        if (isRebel)
        {
            projectStatus = 3;
        }


        switch (projectStatus)
        {
            case 0:
                gameObject.GetComponent<Image>().sprite = NormalSprite;
                break;
            case 1:
                gameObject.GetComponent<Image>().sprite = CorrectSprite;
                //gameObject.GetComponent<Image>().color = Correct;
                break;
            case 2:
                gameObject.GetComponent<Image>().sprite = IncorrectSptite;
                //gameObject.GetComponent<Image>().color = inCorrect;
                break;
            case 3:
                gameObject.GetComponent<Image>().sprite = rebelSprite;
                //gameObject.GetComponent<Image>().color = inCorrect;
                break;
        }
    }
}
