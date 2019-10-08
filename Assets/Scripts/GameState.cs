using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameState : MonoBehaviour
{
    public List< Project> projects = new List<Project>();
    public int dayCount = 0;
    int projectId;
    int currentProject;
    public GameObject projectButtonPrefab;
    public Transform projectScreen;


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
        projects.Add(tempP);
        GameObject Button;
        Button = Instantiate(projectButtonPrefab, new Vector2(2, 2), Quaternion.identity, projectScreen);
        Button.GetComponent<ProjectButton>().GetbuttonID(currentProject);
        Events.saveInital(currentProject);
        projectId++;
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
        currentProject = _currentProject;
        int[] data = projects[_currentProject].ReturnTiledata();
        Events.recallProject(data,currentProject);
        Events.RecallDrawscreen();
    }
 
    
    public void saveProject(int[] projectData)
    {
        projects[currentProject].UpdateTiledata(projectData);
    }

    public int[] returnTileData(int Id)
    {
        return (projects[Id].tileData);
    }
    
    IEnumerator Daytimer()
    {

        while (gameObject)
        {
            dayCount++;
            yield return new WaitForSeconds(2);
        }
        
    }
    
    
}
