using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameState : MonoBehaviour
{
    public List<Notices> notices = new List<Notices>();
    public List< Project> projects = new List<Project>();
    public int dayCount = 0;
    int projectId;
    int currentProject;
    public GameObject projectButtonPrefab;
    public Transform projectScreen;
    public GameObject drawscreen;
    public GameObject Clockhand;

    public int Score;
    public int GameDay = 0;
    public int daySeconds = 15;
    public int noticeDay = 5;
    public int difficulty=3;
    public int Projectcap = 5;
    public int realdifficulty;

    bool isonDrawscreen;
    public Text ScoreBoard;


    void Start()
    {
        
        StartCoroutine(Daytimer());
        projects.Clear();

    }

    
    private void Update()
    {

        Clockhand.transform.eulerAngles = new Vector3(0, 0, -Time.realtimeSinceStartup*12);
       
        if (drawscreen.activeInHierarchy)
        {
            isonDrawscreen = true;
        }
        else
        {
            isonDrawscreen = false;
        }
        
        if (dayCount != GameDay)
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
        ScoreBoard.text =  "Day - " + GameDay.ToString() + "\nScore - "  + score.ToString();
        
        if(GameDay >= noticeDay)
        {
            StartCoroutine(NoticeDay());
        }
        //noticeDay = 0;
    }

    public void CheckProjectCorrectness()
    {
        Events.CheckProjectStatus();
    }

    public void resumeDayTimer()
    {
        StartCoroutine(Daytimer());
    }

    private void OnEnable()
    {
        Events.saveProject += saveProject;
        Events.ButtonCall += RecallProject;
        Events.resumeDayCounter += resumeDayTimer;
    }

    private void OnDisable()
    {
        Events.saveProject -= saveProject;
        Events.ButtonCall -= RecallProject;
        Events.resumeDayCounter -= resumeDayTimer;
    }


    public void NewProject()
    {
        
        realdifficulty = Mathf.Clamp(realdifficulty, 3, 7);

        if (projects.Count > Projectcap)
        {
            realdifficulty++;
            Projectcap += 3;
        }


        Project tempP = new Project(projectId,realdifficulty);
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
        //Events.CheckProjectStatus();

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
        //dayCount = 0;
        while (gameObject)
        {
            dayCount++;
            if(GameDay%5 == 0)
            {
                difficulty++;
            }
            Debug.Log(dayCount);
            yield return new WaitForSeconds(daySeconds);
        }
        
    }

    IEnumerator NoticeDay()
    {
        if (isonDrawscreen)
        {
            //StopCoroutine(Daytimer());

            int color1 = Random.Range(1,Mathf.Clamp(difficulty,1,7));
            int color2 = Random.Range(1, Mathf.Clamp(difficulty, 1, 7));

            if(color1 == color2)
            {
                int tempNum = Random.Range(2, 3);
                color2 = color2 +Mathf.Clamp(tempNum, 1, 7);
            }

            Notices notices1 = new Notices(color1, color2);

            foreach(var project in projects)
            {
                project.swapData(color1, color2);
            }

            //gameObject.GetComponent<TileBehaviour>().swapColors(color1, color2);
            notices.Add(notices1);
            notices1.ChangecolorLooks();
            notices1.ChangecolorMeaning();
            noticeDay += Random.Range(5, 10);
            int temp = noticeDay + GameDay;

            string tempString = notices1.NoticeMessage + "\n \n Next notice can be expected on \nDay -" + noticeDay.ToString();

            Events.ChangeNotice(tempString);
            Events.noticeScreen();

            //Debug.Log("next notice day is on " + noticeDay.ToString());

            //StartCoroutine(Daytimer());
            yield return new WaitForSeconds(daySeconds + 1f);
        }
        
        
    }

    
    
    
}
