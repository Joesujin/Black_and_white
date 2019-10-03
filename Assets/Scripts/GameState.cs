using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameState : MonoBehaviour
{
    public Dictionary<int, Project> projects = new Dictionary<int, Project>();
    public int dayCount = 0;
    int projectId;
    int currentProject;
    public GameObject projectButtonPrefab;
    public Transform projectScreen;

    //public int temp =0;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Daytimer());
        projects.Clear();

    }

    private void OnEnable()
    {
        Events.saveProject += saveProject;
        Events.ButtonCall += RecallProject;

    }

    private void OnDisable()
    {
        Events.saveProject -= saveProject;
        Events.ButtonCall += RecallProject;

    }

    public void NewProject()
    {
        Project tempP = new Project(projectId);
        currentProject = projectId;
        Debug.Log("projectId " + projectId + " current id " + currentProject);
        projectId++;
        projects.Add(currentProject,tempP);
        Events.drawScreen();
    }

    public void ProjectScreenCall()
    {
        Events.projectScreen();
        Events.Destroytiles();
    }

    public void DestroyTiles()
    {
        Events.Destroytiles();
    }

    public void RecallProject(int _currentProject)
    {
        int[] data = projects[_currentProject].ReturnTiledata();
        Events.recallProject(data);
        Events.RecallDrawscreen();
    }
 
    public void saveProject(int[] projectData)
    {
        GameObject Button;
        projects[currentProject].UpdateTiledata(projectData);
        bool buttonstatus = projects[currentProject].ButtonCreated();
        if (buttonstatus)
        {
            //GameObject Button = Instantiate(projectButtonPrefab, new Vector2(2, 2), Quaternion.identity, projectScreen);
            //Button.GetComponent<ProjectButton>().projectId = currentProject;
        }
        else if (!buttonstatus)
        {
            Button = Instantiate(projectButtonPrefab, new Vector2(2, 2), Quaternion.identity, projectScreen);
            Button.GetComponent<ProjectButton>().GetbuttonID(currentProject);
        }
        //Button.GetComponent<ProjectButton>().projectId = currentProject;
        
        //temp++;
    }
    
    IEnumerator Daytimer()
    {

        while (gameObject)
        {
            dayCount++;
            //Debug.Log(dayCount);
            yield return new WaitForSeconds(2);
        }
        
    }
    
    
}
