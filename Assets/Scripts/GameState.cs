using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;


[System.Serializable]
public class GameState : MonoBehaviour
{
    public List<Notices> notices = new List<Notices>();
    public List<Project> projects = new List<Project>();
    public ColorPairs[] NoticeColors = new ColorPairs[15];
    public List<ColorPairs> UsedPairs = new List<ColorPairs>();
    public List<QuestionSet> UsedTriplets = new List<QuestionSet>();

    public Dictionary<int, Color> DefaultColors = new Dictionary<int, Color>();
    public Dictionary<int, Color> inGameColors = new Dictionary<int, Color>();

    public GameObject CameraMain;

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

    public TextMeshProUGUI ScoreBoard;
    public Text NoticeText;
    string HistoryOfnotices;
    public GameObject NoticeScreen;
    public bool isRebelious = false;
    public bool isBroke = false;
    public int Rebel;

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
    public IEnumerator Ringtime;
    public GameObject Phone;
    public GameObject PhoneIndicator;
    public GameObject PhoneScreen;
    public int CalloftheDay;
    public int callerID;
    public string Callertext;
    public string AcceptMessage;
    public int MoneyCost;
    public int totalNumberofCalls;
    public List<bool> CallStatus = new List<bool>();
    public bool PhonePicked;

    public TextMeshProUGUI LiveUpdate;
    public TextMeshProUGUI ExtraText;
    public Sprite[] Newspapers = new Sprite[8];
    public GameObject NewsPaperImg;
    public int DayendMoney;


    public AudioClip tapRight;
    public AudioClip tapWrong;
    public AudioClip PhoneRing;

    public bool CheatON = false;

    void Start()
    {
        PhonePicked = false;
        totalNumberofCalls = 2;
        GameDay = 0;
        CalloftheDay = 0;
        callerID = 1;
        Callertext = TheStory.SamDialogues;
        AcceptMessage = "Accept";
        count = CountdownClock();
        Ringtime = PhoneRingTime();

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

    private void OnEnable()
    {
        Events.saveProject += saveProject;
        Events.ButtonCall += RecallProject;
        Events.ChangeColor += SelectedClrChange;
        Events.ColorId += SelectedClrIDChange;
        Events.AddTriplet += AddUsedTriplets;
    }

    private void OnDisable()
    {
        Events.saveProject -= saveProject;
        Events.ButtonCall -= RecallProject;
        Events.ChangeColor -= SelectedClrChange;
        Events.ColorId -= SelectedClrIDChange;
        Events.AddTriplet -= AddUsedTriplets;
    }



    private void Update()
    {
        CountdownTextPs.text = CoundownSeconds.ToString();
        CountdownTextDs.text = CoundownSeconds.ToString();


        string score = Score.ToString();
        ScoreBoard.text = DayEndReport + LiveUpdate.text;

        pickedColor.GetComponent<Image>().color = SelectedColor;

        //Cheat Code=================================================
        if (CheatON)
        {
            foreach (var project in projects)
            {
                project.cheatSheet();
            }
        }
        //Cheat Code=================================================

        LiveUpdate.text = LiveUpdatestring();
        StoryText.text = "<size=200%><b>DAY " + dayCount.ToString() + " Summary</b> \n\n\n<size=150%>" + LiveUpdate.text;
        if (SelectedColorID == 0)
        {
            gameObject.GetComponent<AudioSource>().clip = tapWrong;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().clip = tapRight;
        }
    }


    public void StartDay()
    {

        PhoneIndicator.GetComponent<Image>().color = Color.white;


        DayendMoney = (int)gameObject.GetComponent<Life>().Money;

        if (GameDay >= 2)
        {
            totalNumberofCalls = 3;
        }
        CallStatus.Clear();
        ringPhone = false;
        CalloftheDay = 0;
        CoundownSeconds = daySeconds;
        difficulty = 0;
        //gameObject.GetComponent<Life>().UpdateLifeStats();
        //Events.ReportScreen();
        dayCount++;
        StartCoroutine(count);

        if (GameDay >= noticeDay)
        {
            StartCoroutine(NoticeDay());
        }
        ExtraText.text = null;
    }

    public void EndDay()
    {
        foreach (var project in projects)
        {
            if (project.isPass)
            {
                DayendMoney = DayendMoney + project.ProjectWorth;
            }
            else if (!project.isPass)
            {
                DayendMoney = DayendMoney - project.penalty;
            }
        }

        if (UsedPairs.Count == 3)
        {
            UsedPairs.Clear();
        }


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
        Rebel = 0;
        Score = 0;
        foreach (Project project in projects)
        {
            bool _isPass = project.CrossCheck();
            if (_isPass)
            {
                Score++;
            }
            if (project.isRebel)
            {
                Rebel++;
            }

        }


        Events.ReportScreen();
        gameObject.GetComponent<Life>().UpdateLifeStats();



        for (int k = 0; k < totalNumberofCalls; k++)
        {
            if (CallStatus.Count != 0)
            {
                if (CallStatus[k] == true)
                {
                    if (k == 1)
                    {
                        if (dayCount != 2)
                        {
                            ExtraText.text = ExtraText.text + "<size=150%>\n\nWife : " + TheStory.WifeNeeds;
                            gameObject.GetComponent<Life>().DeductMoney(TheStory.WifeNeeds);
                        }
                        else if (dayCount == 2)
                        {
                            ExtraText.text = ExtraText.text + "<size=150%>\nRon : " + TheStory.RonNeeds;
                            gameObject.GetComponent<Life>().DeductMoney(TheStory.RonNeeds);
                        }
                    }
                    if (k == 2)
                    {
                        ExtraText.text = ExtraText.text + "<size=150%>\nRon : " + TheStory.RonNeeds;
                        gameObject.GetComponent<Life>().DeductMoney(TheStory.RonNeeds);
                    }
                }
            }
        }
        int money = (int)gameObject.GetComponent<Life>().Money;
        if (CallStatus.Count != 0)
        {

            ExtraText.text = ExtraText.text + "\n\n<size=150%>Final Balance : " + money.ToString();

        }
        GameDay++;
        UpdateStory(GameDay);

        //GAME END STATE

        if (money <= 0)
        {
            isBroke = true;
            if (Rebel == 20)
            {
                isRebelious = true;
                UpdateStory(9);
                Events.EndGame();
            }
            else
            {
                UpdateStory(7);
                Events.EndGame();
            }
        }



    }

    public void EndButtonAction()
    {
        if (CallStatus.Count != 0)
        {
            if (CallStatus.Count != totalNumberofCalls)
            {
                for (int k = 0; k <= totalNumberofCalls; k++)
                {
                    if (CallStatus[k] = true || CallStatus[k] == false)
                    {
                        break;
                    }
                    else
                    {
                        CallStatus[k] = false;
                    }
                }
            }
        }
        EndDay();
    }

    public void RestartGame()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("7DaysScene", LoadSceneMode.Single);
    }


    public string LiveUpdatestring()
    {
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
        //int money = (int)gameObject.GetComponent<Life>().Money;

        string text = "No.of  Projects : " + ProjectCount.ToString() + " " +
            "\nValid Projects :" + ValidProjects.ToString() + " " +
            "\nPenalty : " + penalty.ToString() + "" +
            "\n<b>Income :" + income.ToString() + " " +
            "\nBank balance :" + DayendMoney.ToString() + " </b>";
        return (text);
    }

    public void PhoneCall()
    {
        if (dayCount == 2 && CalloftheDay == 2)
        {
            CalloftheDay = 3;
        }

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
                AcceptMessage = TheStory.RonAccept.ToString();
                MoneyCost = TheStory.RonNeeds;
                break;
        }
        Events.PhoneCall(callerID, Callertext, AcceptMessage);
    }

    public void CheckProjectCorrectness()
    {
        Events.CheckProjectStatus();
    }

    public void AddUsedTriplets(QuestionSet questionSet)
    {
        UsedTriplets.Add(questionSet);
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

        if (Day > 6)
        {
            if (isBroke)
            {
                NewsPaperImg.GetComponent<Image>().sprite = Newspapers[7];
            }
            else
            {
                NewsPaperImg.GetComponent<Image>().sprite = Newspapers[6];
            }
        }
        else if (Day <= 5)
        {
            if (isRebelious)
            {
                NewsPaperImg.GetComponent<Image>().sprite = Newspapers[8];
            }
            else
            {
                NewsPaperImg.GetComponent<Image>().sprite = Newspapers[Day];
            }
        }
        if (isRebelious)
        {
            NewsPaperImg.GetComponent<Image>().sprite = Newspapers[8];
        }
        //StoryText.text = TheStory.NewsPaperText;
        DayEndReport = TheStory.DayEndReport;
        //totalNumberofCalls = TheStory.NumberoftotalCalls;
    }

    public void PhoneIsRinging()
    {
        PhoneIndicator.GetComponent<Image>().color = Color.red;
        CameraMain.GetComponent<AudioSource>().Play();
        CalloftheDay++;
        PhoneCall();
        StartCoroutine(Ringtime);
        PhonePicked = false;
    }

    IEnumerator PhoneRingTime()
    {
        Debug.Log("before ringTimeUP - Ienumerator");
        yield return new WaitForSeconds(10);
        Debug.Log("After ringTimeUP - Ienumerator");

        if (!PhonePicked)
        {
            DenyCall();
        }

        PhoneIdle();
        PhonePicked = false;
    }
    public void PhoneIdle()
    {
        PhoneIndicator.GetComponent<Image>().color = Color.white;
        CameraMain.GetComponent<AudioSource>().Stop();

        ringPhone = false;

        StopCoroutine(Ringtime);
        Debug.Log("phone shut - PhoneIdle");
    }


    public void acceptCall()
    {

        CallStatus.Add(true);
        PhonePicked = false;
    }

    public void DenyCall()
    {
        CallStatus.Add(false);
        PhonePicked = false;

    }

    public void pickUpPhone()
    {
        StopCoroutine(Ringtime);
        PhonePicked = true;

        if (ringPhone)
        {
            PhoneScreen.GetComponent<PhoneScript>().visiblity();
            PauseTimer();
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

            if (dayCount < 6)
            {
                if (totalNumberofCalls == 2)
                {
                    if (CoundownSeconds == (daySeconds / 3) || CoundownSeconds == ((daySeconds / 3) * 2))
                    {
                        Ringtime = PhoneRingTime();

                        ringPhone = true;
                        if (ringPhone)
                        {
                            Debug.Log("ringPhone set - CountdownClock");
                            PhoneIsRinging();
                        }
                    }
                }
                if (totalNumberofCalls == 3)
                {
                    if (CoundownSeconds == (daySeconds / 4) || CoundownSeconds == ((daySeconds / 4) * 3) || CoundownSeconds == daySeconds / 2)
                    {
                        Ringtime = PhoneRingTime();
                        
                        ringPhone = true;
                        if (ringPhone)
                        {
                            PhoneIsRinging();
                        }
                    }
                }
            }

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


        PauseTimer();
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
