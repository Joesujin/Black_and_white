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
    public string DayEndReport;

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

    public IEnumerator count;
    public int tempTime;


    public bool ringPhone;
    public GameObject Phone;
    public GameObject PhoneScreen;
    public int CalloftheDay;
    public int callerID;
    public string Callertext;
    public string AcceptMessage;
    public int MoneyCost;

    public TextMeshProUGUI LiveUpdate;

    void Start()
    {
        GameDay = 0;
        CalloftheDay = 0;
        callerID = 1;
        Callertext = TheStory.SamDialogues;
        AcceptMessage = "Accept";
        count = CountdownClock();


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
        ringPhone = false;
        CalloftheDay = 0;
        CoundownSeconds = daySeconds;
        difficulty = 0;
        gameObject.GetComponent<Life>().UpdateLifeStats();
        //Events.ReportScreen();
        dayCount++;
        StartCoroutine(count);

        if (GameDay >= noticeDay)
        {
            StartCoroutine(NoticeDay());
        }
    }

    public void EndDay()
    {
        if (UsedPairs.Count == 3)
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
        ScoreBoard.text = DayEndReport;

        pickedColor.GetComponent<Image>().color = SelectedColor;


        foreach (var project in projects)
        {
            //project.cheatSheet();
        }

        int ProjectCount = projects.Count;
        int ValidProjects = 0;
        int income = 0;
        int penalty = 0;
        foreach (Project project in projects)
        {
            bool _isPass = project.CrossCheck();
            if (_isPass)
            {
                ValidProjects++;
                income += project.ProjectWorth;
            }
            else
            {
                penalty += project.penalty;
            }
        }
        int money = (int) gameObject.GetComponent<Life>().Money;

        LiveUpdate.text = "No.of  Projects - " + ProjectCount.ToString() + " " +
            "\nValid Projects -" + ValidProjects.ToString() + " " +
            "\nPenalty - " + penalty.ToString() + "" +
            "\n<b>   Income -" + income.ToString() + " " +
            "\n   Bank balance -" + money.ToString() + " </b>";

    }

    public void PhoneCall()
    {
        switch (CalloftheDay)
        {
            case 1:
                callerID = 1;
                Callertext = TheStory.SamDialogues;
                AcceptMessage = TheStory.SamAccept.ToString();
                break;
            case 2:
                callerID = 2;
                Callertext = TheStory.WifeDialogues;
                AcceptMessage = TheStory.WifeAccept.ToString();
                MoneyCost = TheStory.WifeNeeds;
                break;
            case 3:
                callerID = 3;
                Callertext = TheStory.RonDialogues;
                AcceptMessage =  TheStory.RonAccept.ToString();
                MoneyCost = TheStory.RonNeeds;
                break;
        }
        Events.PhoneCall(callerID, Callertext, AcceptMessage);
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
        TheStory.StoryText(Day);
        TheStory.PhoneCalls(Day);
        StoryText.text = TheStory.NewsPaperText;
        DayEndReport = TheStory.DayEndReport;
    }

    public void PhoneIsRinging()
    {
        Phone.GetComponent<Image>().color = Color.red;
        CalloftheDay++;
        PhoneCall();
    }

    public void PhoneIdle()
    {
        Phone.GetComponent<Image>().color = Color.white;
        ringPhone = false;
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

    public void pickUpPhone()
    {
        if (ringPhone)
        {
            PhoneScreen.GetComponent<PhoneScript>().visiblity();
            PauseTimer();
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

            if (CoundownSeconds == (daySeconds / 4) || CoundownSeconds == ((daySeconds / 4) * 3) || CoundownSeconds == daySeconds / 2)
            {
                ringPhone = true;
                if (ringPhone)
                {
                    PhoneIsRinging();
                }
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

    public void PauseTimer()
    {


        tempTime = CoundownSeconds;
        StopCoroutine(count);
        Debug.Log("stop timer");
        //StopAllCoroutines();
    }

    public void ResumeTimer()
    {
        Debug.Log("restart timer");
        count = CountdownClock();
        CoundownSeconds = tempTime;
        StartCoroutine(count);

    }




    IEnumerator NoticeDay()
    {



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
