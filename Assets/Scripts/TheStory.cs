using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TheStory
{

    public static string NewsPaperText;
    public static string DayEndReport;

    public static string WifeDialogues;
    public static string WifeAccept;
    public static int WifeNeeds;
    public static string SamDialogues;
    public static string SamAccept;
    public static string RonDialogues;
    public static string RonAccept;
    public static int RonNeeds;

    public static void StoryText(int Day)
    {
        switch (Day)
        {
            case 0:
                NewsPaperText = "<size=200%>Dear applicant" +
                    "\n<line-indent=15%><size=100%>This is your Probation period for the job application we recieved from you.</line-indent>" +
                    "\n\n<u><b>Instructions are as follows.</u></b>" +
                    "\n<line-indent=8%> -Find the <b><size=120%>Big Red Button<size=100%></b>" +
                    "\n -Use the Colors Match the grid with the Job Sheet" +
                    "\n -<i>Submit.</i>" +
                    "\n -<color=#009500>Green tick</color> is good,<color=#950000> Red cross</color> is bad</line-indent>" +
                    "\n\n<size=150%><i><b>All the best</i></b>";
                DayEndReport = "End of Day 1";
                break;
            case 1:
                NewsPaperText = "<size=200%>Massive meteore strikes again" +
                    "\n\n<size= 250%>EVERYTHING CHANGES";
                DayEndReport = "End of Day 1" + "Well Done of your first day." +
                    "\n you've done out of which are Valid" +
                    "\n\n you can checkout those projects whenever you like and correct them" +
                    "\nKeep up the good work" +
                    "\n oh and look out for the notices";
                break;
            case 2:
                NewsPaperText = "The meaning of everything changed now it has happened again. the swapping phenomenon" +
                    "\n<size=200%>EXPECT WORKPLACE CHANGES";
                DayEndReport = "End of Day 2 " + "Notices are office memos that are passed down by the people above" +
                    "\n they have no idea whats going on, But they always want to change the meaning of on thing to another" +
                    "\n so we need to keep our projects up to date." +
                    "\n\n you'll lose money for all the invalid projects you have.";
                break;
            case 3:
                NewsPaperText = "People have started to lose their jobs again." +
                    "\nEvery working individual is advised to prioritize work to sustain in this society";
                DayEndReport = "End of Day 3";
                break;
            case 4:
                NewsPaperText = "Story line 5";
                DayEndReport = "End of Day 4";
                break;
            case 5:

                NewsPaperText = "Story line 6";
                DayEndReport = "End of Day 5";
                break;
            case 6:
                NewsPaperText = "Story line 7";
                DayEndReport = "End of Day 6";
                break;
            case 7:
                NewsPaperText = "Story line 8";
                DayEndReport = "Judgement Day!!!";
                break;
        }

    }

    public static void PhoneCalls(int Day)
    {
        switch (Day)
        {
            case 0:
                SamDialogues = "Sam dialogue day 1";
                SamAccept = "Accept";
                WifeDialogues = " Wife dialogue day1";
                WifeAccept = "Give - 500";
                WifeNeeds = 500;
                RonDialogues = "Ron dialogue day1";
                RonAccept = "Give - 1000";
                RonNeeds = 1000;
                break;
            case 1:
                SamDialogues = "sam dialogue day 2";
                SamAccept = "Accept";
                WifeDialogues = " Wife dialogue day2";
                WifeAccept = "Give - 500";
                WifeNeeds = 500;
                RonDialogues = "Ron dialogue day2";
                RonAccept = "Give - 1000";
                RonNeeds = 1000;
                break;
            case 2:
                SamDialogues = "sam dialogue day 3";
                SamAccept = "Accept";
                WifeDialogues = " Wife dialogue day3";
                WifeAccept = "Give - 500";
                WifeNeeds = 500;
                RonDialogues = "Ron dialogue day3";
                RonAccept = "Give - 1000";
                RonNeeds = 1000;

                break;
            case 3:
                SamDialogues = "sam dialogue day 4";
                SamAccept = "Accept";
                WifeDialogues = " Wife dialogue day4";
                WifeAccept = "Give - 500";
                WifeNeeds = 500;
                RonDialogues = "Ron dialogue day4";
                RonAccept = "Give - 1000";
                RonNeeds = 1000;
                break;
            case 4:
                SamDialogues = "sam dialogue day 5";
                SamAccept = "Accept";
                WifeDialogues = " Wife dialogue day5";
                WifeAccept = "Give - 500";
                WifeNeeds = 500;
                RonDialogues = "Ron dialogue day5";
                RonAccept = "Give - 1000";
                RonNeeds = 1000;
                break;
            case 5:
                SamDialogues = "sam dialogue day 6";
                SamAccept = "Accept";
                WifeDialogues = " Wife dialogue day6";
                WifeAccept = "Give - 500";
                WifeNeeds = 500;
                RonDialogues = "Ron dialogue day6";
                RonAccept = "Give - 1000";
                RonNeeds = 1000;
                break;
            case 6:
                SamDialogues = "sam dialogue day 7";
                SamAccept = "Accept";
                WifeDialogues = " Wife dialogue day7";
                WifeAccept = "Give - 500";
                WifeNeeds = 500;
                RonDialogues = "Ron dialogue day7";
                RonAccept = "Give - 1000";
                RonNeeds = 1000;
                break;
            case 7:
                SamDialogues = "sam dialogue day 8";
                SamAccept = "Accept";
                WifeDialogues = " Wife dialogue day8";
                WifeAccept = "Give - 500";
                WifeNeeds = 500;
                RonDialogues = "Ron dialogue day8";
                RonAccept = "Give - 1000";
                RonNeeds = 1000;
                break;
        }
    }
}

