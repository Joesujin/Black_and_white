using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public class GameState : MonoBehaviour
{
    public List<Notices> notices = new List<Notices>();
    public List<Project> projects = new List<Project>();
    public ColorPairs[] NoticeColors = new ColorPairs[15];
    public List<ColorPairs> UsedPairs = new List<ColorPairs>();

    public Dictionary<int, Color> DefaultColors = new Dictionary<int, Color>();
    public Dictionary<int, Color> inGameColors = new Dictionary<int, Color>();

    public GameObject WhiteButton;
    public GameObject BlackButton;
    public GameObject RedButton;
    public GameObject BlueButton;
    public GameObject GreenButton;
    public GameObject YellowButton;

    public Color Gray;
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
    public int difficulty = 0;
    public int Projectcap = 4;
    public int realdifficulty;
    public string DayOfWeek;

    public Text ScoreBoard;
    public Text NoticeText;
    string HistoryOfnotices;

    public int CoundownSeconds;
    public Text CountdownTextPs;
    public Text CountdownTextDs;
    //public Text StoryText;
    public TextMeshProUGUI StoryText;
    public Text Projectdetails;

    public Color SelectedColor;
    public int SelectedColorID;
    public GameObject pickedColor;

    public GameObject NoticePanel;
    public GameObject Noticedetails;


    void Start()
    {
        DefaultColors.Add(0, Gray);
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
        int k = 0;
        for (int i = 1; i < 7; i++)
        {
            for (int j = 1; j < 7; j++)
            {
                if (i != j)
                {
                    bool pairExists = false;
                    foreach (var colorPair in NoticeColors)
                    {
                        if (colorPair.Color1 == i)
                        {
                            if (colorPair.Color2 == j)
                            {
                                pairExists = true;
                            }

                        }
                        if (colorPair.Color1 == j)
                        {
                            if (colorPair.Color2 == i)
                            {
                                pairExists = true;
                            }

                        }
                    }
                    if (pairExists == false)
                    {
                        NoticeColors[k].Color1 = i;
                        NoticeColors[k].Color2 = j;
                        k++;
                    }

                }


            }
        }


        UpdateStory(GameDay);

        projects.Clear();
        UsedPairs.Clear();

    }

    public void StartDay()
    {
        difficulty = 0;
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
        if(UsedPairs.Count == 3)
        {
            UsedPairs.Clear();
        }
        GameDay++;
        if (CoundownSeconds > 1)
        {
            Debug.Log("EndDay buttonClick");
            difficulty++;
        }

        if (drawscreen.activeInHierarchy == true)
        {
            Events.saveButton(currentProject);
            ProjectScreenCall();
        }

        StopAllCoroutines();

        Score = 0;
        foreach (Project project in projects)
        {
            bool _isPass = project.CrossCheck();
            if (_isPass)
            {
                Score++;
            }
        }


        UpdateStory(GameDay);
        Events.ReportScreen();
        gameObject.GetComponent<Life>().UpdateLifeStats();
        //GAME END STATE
        if (gameObject.GetComponent<Life>().Money <= 0)
        {
            UpdateStory(7);
            Events.EndGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("7DaysScene", LoadSceneMode.Single);
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
                StoryText.text = "<size=200%>Dear applicant" +
                    "\n<line-indent=15%><size=100%>This is your Probation period for the job application we recieved from you.</line-indent>" +
                    "\n\n<u><b>Instructions are as follows.</u></b>" +
                    "\n<line-indent=8%> -Find the <b><size=120%>Big Red Button<size=100%></b>" +
                    "\n -Use the Colors Match the grid with the Job Sheet" +
                    "\n -<i>Submit.</i>" +
                    "\n -<color=#009500>Green tick</color> is good,<color=#950000> Red cross</color> is bad</line-indent>" +
                    "\n\n<size=150%><i><b>All the best</i></b>";
                DayOfWeek = "Day 1";
                break;
            case 1:
                StoryText.text = "Well Done of your first day." +
                    "\n you've done " + projects.Count.ToString() + " out of which " + Score.ToString() + "are Valid" +
                    "\n\n you can checkout those projects whenever you like and correct them" +
                    "\nKeep up the good work" +
                    "\n oh and look out for the notices";
                DayOfWeek = "Day 2";
                break;
            case 2:
                StoryText.text = "Notices are office memos that are passed down by the people above" +
                    "\n they have no idea whats going on, But they always want to change the meaning of on thing to another" +
                    "\n so we need to keep our projects up to date." +
                    "\n\n you'll lose money for all the invalid projects you have.";
                DayOfWeek = "Day 3";
                break;
            case 3:
                StoryText.text = "Story line 4";
                DayOfWeek = "Day 4";
                break;
            case 4:
                StoryText.text = "Story line 5";
                DayOfWeek = "Day 5";
                break;
            case 5:

                StoryText.text = "Story line 6";
                DayOfWeek = "Day 6";
                break;
            case 6:
                StoryText.text = "Story line 7";
                DayOfWeek = "Day 7";
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
        Events.recallProject(data, currentProject);
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

            if (CoundownSeconds <= 1)
            {
                EndDay();
            }
            /*
            if(CoundownSeconds == (daySeconds / 2) && difficulty >= 3 && projects.Count > 10)
            {

                    StartCoroutine(NoticeDay());

            }

            if((CoundownSeconds == daySeconds / 3) && difficulty >= 5 && projects.Count > 19)
            {

                    StartCoroutine(NoticeDay());

            }
            */
        }
    }

    public void NoticeControl()
    {
        


    }


    IEnumerator NoticeDay()
    {

        //int color1 = (int)Random.Range(1, 7);
        //int color2 = (int)Random.Range(1, 7);


        /*
         if(color1 == color2)
         {
             int tempNum = Random.Range(2, 3);
             color2 = Mathf.Clamp(color2 + tempNum, 1, 6);
         }
         */


        bool vaildPair = false;
        ColorPairs selectedPair = new ColorPairs(0, 0);
        while (vaildPair == false) 
        {
            int address = (int)Random.Range(0, NoticeColors.Length);
            selectedPair = NoticeColors[address];
            if (UsedPairs.Count != 0)
            {
                foreach (var pair in UsedPairs)
                {
                    if (selectedPair.Color1 == pair.Color1 || selectedPair.Color1 == pair.Color2 || selectedPair.Color2 == pair.Color1 || selectedPair.Color2 == pair.Color2)
                    {
                        vaildPair = false;
                        break;
                    }
                    else
                    {
                        vaildPair = true;
                    }
                }
            }
            else
            {
                vaildPair = true;
            }
            if (vaildPair)
            {
                UsedPairs.Add(selectedPair);
            }
        }

        //=============================================

        Notices notices1 = new Notices(selectedPair.Color1, selectedPair.Color2);

        foreach (var project in projects)
        {
            project.swapData(selectedPair.Color1, selectedPair.Color2);
        }
        notices.Add(notices1);
        notices1.ChangecolorMeaning();
        noticeDay += 1;
        notices1.NoticeID = notices.Count;

        GameObject Button;
        Button = Instantiate(Noticedetails, new Vector2(2, 2), Quaternion.identity, NoticePanel.transform);
        Button.GetComponent<NoticeDetails>().NoticeInfoChange(notices1.C1, notices1.C2, notices1.NoticeID);
        string tempString = notices1.NoticeMessage;

        //updateNoticeText(notices1.NoticeMessage);
        Events.ChangeNotice(notices1.C1, notices1.C2, tempString);
        Events.noticeScreen();

        //Debug.Log("next notice day is on " + noticeDay.ToString());
        //StartCoroutine(Daytimer());
              

        yield return new WaitForSeconds(daySeconds + 1f);
    }




}
