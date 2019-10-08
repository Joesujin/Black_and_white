using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameState : MonoBehaviour
{
    public List< Project> projects = new List<Project>();
    public int dayCount = 0;
    int projectId;
    int currentProject;
    public GameObject projectButtonPrefab;
    public Transform projectScreen;

    public int Score;
    public int GameDay = 0;
    public int daySeconds = 15;


    public Text ScoreBoard;


    void Start()
    {
        
        StartCoroutine(Daytimer());
        projects.Clear();

    }

    
    private void Update()
    {
        
        
        if(dayCount != GameDay)
        {
            Score = 0;
            foreach(Project project in projects)
            {
                bool _isPass = project.CrossCheck();
                if (_isPass)
                {
                    Score++;
                }
            }
            GameDay++;
        }
        string score = Score.ToString();
        ScoreBoard.GetComponent<UnityEngine.UI.Text>().text =  score;
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

        gameObject.GetComponent<TileMap>().LoadQuestion(projects[currentProject].QuestionData);
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

        gameObject.GetComponent<TileMap>().LoadQuestion(projects[currentProject].QuestionData);
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
            yield return new WaitForSeconds(daySeconds);
        }
        
    }
    
    
}
