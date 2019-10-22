using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameState : MonoBehaviour
{
    public List<Notices> notices = new List<Notices>();
    public List<Project> projects = new List<Project>();

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
    public GameObject Clockhand;

    public int Score;
    public int GameDay = 0;
    public int daySeconds = 15;
    public int noticeDay = 3;
    public int difficulty = 3;
    public int Projectcap = 4;
    public int realdifficulty;

    bool isonDrawscreen;
    public Text ScoreBoard;
    public Text NoticeText;
    string HistoryOfnotices;

    public Color SelectedColor;
    public int SelectedColorID;
    public GameObject PickedColor;

    void Start()
    {
        DefaultColors.Add(0, Color.gray);
        DefaultColors.Add(1, White);
        DefaultColors.Add(2, Black);
        DefaultColors.Add(3, Red);
        DefaultColors.Add(4, Blue);
        DefaultColors.Add(5, Green);
        DefaultColors.Add(6, Yellow);

        foreach (int key in DefaultColors.Keys)
        {
            inGameColors.Add(key, DefaultColors[key]);
        }
        //StartCoroutine(Daytimer());
        //Events.DailyReport();
        projects.Clear();
    }

    public void StartTheday()
    {
        StartCoroutine(Daytimer());
        Events.DailyReport();
        //Events.projectScreen();
        //if (GameDay >= noticeDay)
        //{
            //Events.drawScreen();
            StartCoroutine(NoticeDay());
        //}
    }

    public void EndOfDay()
    {
        gameObject.GetComponent<TileMap>().UpdateColor(currentProject);

        Events.projectScreen();
        Events.DailyReport();
        
    }
    private void Update()
    {

        
        PickedColor.GetComponent<Image>().color = SelectedColor;
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
        string score = Score.ToString();
        ScoreBoard.text = "Day - " + GameDay.ToString() + "\nScore - " + score.ToString();

        
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
        Events.ChangeColor += Selectedcolor;
        Events.ColorId += SelectedcolorID;
    }

    private void OnDisable()
    {
        Events.saveProject -= saveProject;
        Events.ButtonCall -= RecallProject;
        Events.resumeDayCounter -= resumeDayTimer;
        Events.ChangeColor -= Selectedcolor;
        Events.ColorId -= SelectedcolorID;

    }

    public void Selectedcolor(Color selectedColor)
    {
        SelectedColor = selectedColor;
        
    }

    public void SelectedcolorID(int ColorID)
    {
        SelectedColorID = ColorID;
    }

    public void showNoticeHistory()
    {
        Events.NoticeHistory();
    }

    public void NewProject()
    {
        if (projects.Count < 20)
        {



            realdifficulty = Mathf.Clamp(realdifficulty, 3, 7);

            if (projects.Count > Projectcap)
            {
                if (realdifficulty < 7)
                {
                    realdifficulty++;
                }
                Projectcap += 3;
            }

            Project tempP = new Project(projectId, realdifficulty);
            currentProject = projectId;
            projects.Add(tempP);
            GameObject Button;
            Button = Instantiate(projectButtonPrefab, new Vector2(2, 2), Quaternion.identity, projectScreen);
            Button.GetComponent<ProjectButton>().GetbuttonID(currentProject);
            Events.saveInital(currentProject);
            projectId++;
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
        Events.recallProject(data, currentProject);
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

            dayCount++;

            Debug.Log(dayCount);
            yield return new WaitForSeconds(daySeconds);
            
            EndOfDay();
        

    }

    IEnumerator NoticeDay()
    {
        //if (isonDrawscreen)
        //{
            //StopCoroutine(Daytimer());

            //int color1 = Random.Range(1, Mathf.Clamp(difficulty, 1, 7));
            //int color2 = Random.Range(1, Mathf.Clamp(difficulty, 1, 7));

            int color1 = Random.Range(1,  7);
            int color2 = Random.Range(1,  7);
            // color1 = 1;
            // int color2 = tempCOlID;

            if (color1 == color2)
            {
                int tempNum = Random.Range(2, 3);
                color2 = color2 + Mathf.Clamp(tempNum, 1, 7);
            }

            Notices notices1 = new Notices(color1, color2);

            foreach (var project in projects)
            {
                project.swapData(color1, color2);
            }
            notices.Add(notices1);
            //notices1.ChangecolorLooks();
            notices1.ChangecolorMeaning();
            noticeDay += 1;
            int temp = noticeDay + GameDay;
            string tempString = notices1.NoticeMessage + "\n \n Next notice can be expected on \nDay -" + noticeDay.ToString();

            updateNoticeText(notices1.NoticeMessage);
            Events.ChangeNotice(tempString);
            Events.noticeScreen();

            //Debug.Log("next notice day is on " + noticeDay.ToString());
            //StartCoroutine(Daytimer());
            yield return new WaitForSeconds(daySeconds + 1f);
        //}


    }




}
