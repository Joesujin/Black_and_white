using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameState : MonoBehaviour
{
    //public Dictionary<int, Project> projects = new Dictionary<int, Project>();
    public List< Project> projects = new List<Project>();
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
       // Debug.Log("BEFORE_projectId " + projectId + " current id " + currentProject);
        Project tempP = new Project(projectId);
        currentProject = projectId;
        //Debug.Log("AFTER_projectId " + projectId + " current id " + currentProject);
        /*
        for (int i = 0; i< 10; i++)
        {
            if (projects.ContainsKey(i))
            {
                projectId++;
                break;
            }
            else
            {*/
                projects.Add(tempP);


        
            //}
        //}

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
        /*
        GameObject Button;
        
        bool buttonstatus = projects[currentProject].ButtonCreated();
        if (buttonstatus)
        {
            //currentProject = Button.GetComponent<ProjectButton>().returnButtonID();
            //GameObject Button = Instantiate(projectButtonPrefab, new Vector2(2, 2), Quaternion.identity, projectScreen);
            //Button.GetComponent<ProjectButton>().projectId = currentProject;
        }
        else if (!buttonstatus)
        {
            Button = Instantiate(projectButtonPrefab, new Vector2(2, 2), Quaternion.identity, projectScreen);
            Button.GetComponent<ProjectButton>().GetbuttonID(currentProject);
        }
        //Button.GetComponent<ProjectButton>().projectId = currentProject;
        */

        //Debug.Log("SaveON");
        projects[currentProject].UpdateTiledata(projectData);

       // Debug.Log("SaveOFF");

        //temp++;
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
            //Debug.Log(dayCount);
            yield return new WaitForSeconds(2);
        }
        
    }
    
    
}
