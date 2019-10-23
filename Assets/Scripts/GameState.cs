using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameState : MonoBehaviour
{
    public List<Notices> notices = new List<Notices>();
    public List< Project> projects = new List<Project>();

    public Dictionary<int, Color> DefaultColors = new Dictionary<int, Color>();
    public Dictionary<int, Color> inGameColors = new Dictionary<int, Color>();

    public GameObject WhiteButton;
    public GameObject BlackButton;
    public GameObject RedButton;
    public GameObject BlueButton;
    public GameObject GreenButton;
    public GameObject YellowButton;

    public Color White;
    public Color Black;
    public Color Red;
    public Color Blue;
    public Color Green;
    public Color Yellow;

    public int dayCount = 0;
    int projectId;
    int currentProject;
    public GameObject projectButtonPrefab;
    public Transform projectScreen;
    public GameObject drawscreen;


    public int Score;
    public int GameDay = 0;
    public int daySeconds = 15;
    public int noticeDay = 5;
    public int difficulty=0;
    public int Projectcap = 4;
    public int realdifficulty;
    public string DayOfWeek;

    public Text ScoreBoard;
    public Text NoticeText;
    string HistoryOfnotices;

    public int CoundownSeconds;
    public Text CountdownTextPs;
    public Text CountdownTextDs;
    public Text StoryText;
    public Text Projectdetails;

    public Color SelectedColor;
    public int SelectedColorID;
    public GameObject pickedColor;


    void Start()
    {
        DefaultColors.Add(0, Color.gray);
        DefaultColors.Add(1, White);
        DefaultColors.Add(2, Black);
        DefaultColors.Add(3, Red);
        DefaultColors.Add(4, Blue);
        DefaultColors.Add(5, Green);
        DefaultColors.Add(6, Yellow);

        foreach(int key in DefaultColors.Keys)
        {
            inGameColors.Add(key, DefaultColors[key]);
        }

        UpdateStory(GameDay);

        projects.Clear();

    }

    public void StartDay()
    {
        gameObject.GetComponent<Life>().UpdateLifeStats();
        Events.ReportScreen();
        dayCount++;
        StartCoroutine(CountdownClock());
        CoundownSeconds = daySeconds;
        if (GameDay >= noticeDay)
        {
            StartCoroutine(NoticeDay());
        }
    }

    public void EndDay()
    {
        if(CoundownSeconds > 1)
        {
            Debug.Log("EndDay buttonClick");
            difficulty++;
        }

        if (drawscreen.activeInHierarchy == true)
        {
            Events.saveButton(currentProject);
            ProjectScreenCall();
        }
        UpdateStory(GameDay);
        Events.ReportScreen();
        StopAllCoroutines();
        if (dayCount != GameDay)
        {
            Score = 0;
            foreach (Project project in projects)
            {
                bool _isPass = project.CrossCheck();
                if (_isPass)
                {
                    Score++;
                }
            }
            GameDay++;
        }
        gameObject.GetComponent<Life>().UpdateLifeStats();
        //GAME END STATE
        if(gameObject.GetComponent<Life>().Money <= 0)
        {
            UpdateStory(7);
            Events.EndGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("7DaysScene",LoadSceneMode.Single);
    }

    private void Update()
    {
        CountdownTextPs.text = CoundownSeconds.ToString(); 
        CountdownTextDs.text = CoundownSeconds.ToString();


        string score = Score.ToString();
        ScoreBoard.text = DayOfWeek;

        pickedColor.GetComponent<Image>().color = SelectedColor;

    }

    public void CheckProjectCorrectness()
    {
        Events.CheckProjectStatus();
    }


    private void OnEnable()
    {
        Events.saveProject += saveProject;
        Events.ButtonCall += RecallProject;
        Events.ChangeColor += SelectedClrChange;
        Events.ColorId += SelectedClrIDChange;
    }

    private void OnDisable()
    {
        Events.saveProject -= saveProject;
        Events.ButtonCall -= RecallProject;
        Events.ChangeColor -= SelectedClrChange;
        Events.ColorId -= SelectedClrIDChange;
    }

    public void SelectedClrChange(Color clr)
    {
        SelectedColor = clr;
    }

    public void SelectedClrIDChange(int clrID)
    {
        SelectedColorID = clrID;
    }

    public void showNoticeHistory()
    {
        Events.NoticeHistory();
    }

    public void UpdateStory(int Day)
    {
        switch (Day)
        {
            case 0:
                StoryText.text = "My Name is John i used to work here..." +
                    "\n now you are gonna..." +
                    "\n All the best Budd";
                DayOfWeek = "Monday";
                break;
            case 1:
                StoryText.text = "You know the dril";
                DayOfWeek = "Tuesday";
                break;
            case 2:
                StoryText.text = "lets work out Some Deal okay???";
                DayOfWeek = "Wednesday";
                break;
            case 3:
                StoryText.text = "Story line 4";
                DayOfWeek = "Thursday";
                break;
            case 4:
                StoryText.text = "Story line 5";
                DayOfWeek = "Friday";
                break;
            case 5:
                StoryText.text = "Story line 6";
                DayOfWeek = "Saturday";
                break;
            case 6:
                StoryText.text = "Story line 7";
                DayOfWeek = "Sunday";
                break;
            case 7:
                StoryText.text = "Story line 8";
                DayOfWeek = "Judgement Day!!!";
                break;
        }
    }

    public void NewProject()
    {
        if (projects.Count < 20)
        {

            

            realdifficulty = Mathf.Clamp(realdifficulty, 3, 7);

            if (projects.Count > Projectcap)
            {
                if(realdifficulty < 7)
                {
                    realdifficulty++;
                }
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
            Projectdetails.text = projects[currentProject].ProjectDetails;
            Events.drawScreen();
            gameObject.GetComponent<TileMap>().LoadQuestion(projects[currentProject].QuestionData);
            if (notices != null)
            {
                foreach (Notices notice in notices)
                {
                    Debug.Log("swaping data in project = " + projectId.ToString());
                    int col1 = notice.colorID_1;
                    int col2 = notice.colorID_2;
                    projects[currentProject].swapData(col1, col2);

                }
            }
        }
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

    public void updateNoticeText(string OneNotice)
    {
        HistoryOfnotices = HistoryOfnotices + "\n" + OneNotice;
        NoticeText.text = HistoryOfnotices;
    }


    public void RecallProject(int _currentProject)
    {
        currentProject = _currentProject;
        int[] data = projects[_currentProject].ReturnTiledata();
        Events.recallProject(data,currentProject);
        Projectdetails.text = projects[_currentProject].ProjectDetails;
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
    
    IEnumerator CountdownClock()
    {
        while (true)
        {
            CoundownSeconds--;
            yield return new WaitForSeconds(1);
            
            if (CoundownSeconds <=1)
            {
                EndDay();
            }

            if(CoundownSeconds == (daySeconds / 2))
            {
                if(difficulty >=3 && projects.Count > 10)
                {
                    StartCoroutine(NoticeDay());
                }
            }

            if(CoundownSeconds == (daySeconds - (daySeconds / 3)))
            {
                if (difficulty >= 5 && projects.Count > 19)
                {
                    StartCoroutine(NoticeDay());
                }
            }
        }
    }



    IEnumerator NoticeDay()
    {

            int color1 = Random.Range(1,7);
            int color2 = Random.Range(1,7);
            


            if(color1 == color2)
            {
                int tempNum = Random.Range(2, 3);
                color2 = Mathf.Clamp(color2 + tempNum, 1, 7);
            }

            Notices notices1 = new Notices(color1, color2);

            foreach(var project in projects)
            {
                project.swapData(color1, color2);
            }
            notices.Add(notices1);
            notices1.ChangecolorMeaning();
            noticeDay += 1;

            string tempString = notices1.NoticeMessage ;

            updateNoticeText(notices1.NoticeMessage);
            Events.ChangeNotice(tempString);
            Events.noticeScreen();

            //Debug.Log("next notice day is on " + noticeDay.ToString());
            //StartCoroutine(Daytimer());
            yield return new WaitForSeconds(daySeconds + 1f);

        
        
    }

    
    
    
}
