using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TheStory
{

    public static string NewsPaperText;
    public static string DayEndReport;
    public static int NumberoftotalCalls;

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
                NumberoftotalCalls = 2;
                break;
            case 1:
                NewsPaperText = "<size=200%>Massive meteore strikes again" +
                    "\n\n<size= 250%>EVERYTHING CHANGES";
                DayEndReport = "End of Day 1" + "Well Done of your first day." +
                    "\n you've done out of which are Valid" +
                    "\n\n you can checkout those projects whenever you like and correct them" +
                    "\nKeep up the good work" +
                    "\n oh and look out for the notices";
                NumberoftotalCalls = 2;
                break;
            case 2:
                NewsPaperText = "The meaning of everything changed now it has happened again. the swapping phenomenon" +
                    "\n<size=200%>EXPECT WORKPLACE CHANGES";
                DayEndReport = "End of Day 2 " + "Notices are office memos that are passed down by the people above" +
                    "\n they have no idea whats going on, But they always want to change the meaning of on thing to another" +
                    "\n so we need to keep our projects up to date." +
                    "\n\n you'll lose money for all the invalid projects you have.";
                NumberoftotalCalls = 3;
                break;
            case 3:
                NewsPaperText = "People have started to lose their jobs again." +
                    "\nEvery working individual is advised to prioritize work to sustain in this society";
                DayEndReport = "End of Day 3";
                NumberoftotalCalls = 3;
                break;
            case 4:
                NewsPaperText = "Story line 5";
                DayEndReport = "End of Day 4";
                NumberoftotalCalls = 3;
                break;
            case 5:

                NewsPaperText = "Story line 6";
                DayEndReport = "End of Day 5";
                NumberoftotalCalls = 3;
                break;
            case 6:
                Debug.Log("Revolution...");
                NewsPaperText = "Story line 7";
                DayEndReport = "End of Day 6";
                NumberoftotalCalls = 3;
                break;
            case 7:
                NewsPaperText = "Story line 8";
                DayEndReport = "Judgement Day!!!";
                NumberoftotalCalls = 3;
                break;
        }

    }

    public static void PhoneCalls(int Day)
    {
        switch (Day)
        {
            case 0:
                WifeNeeds = 400;
                RonNeeds = 1000;
                SamDialogues = "<size=150%>Hey Rookie... \n<size=100%>Sam Here..." +
                    "\nFound the Red Button yet? " +
                    "\nRemember,More Projects More Money," +
                    "\nInvalid Projects will cost its penality" +
                    "\n\nAnd also" +
                    "\nThis phone only <b>recieves</b> calls" +
                    "\nThe <b>Timer Stops</b> while on call" +
                    "\n\nNOW GET BACK TO WORK...";
                SamAccept = "Yes Sir";
                WifeDialogues = "<size=200%>Hey Honey... \n<size=100%>\n" +
                    "I found your number on the phonebook" +
                    "\nLike you said I looked up John " +
                    "\nSad that he got fired...Which is good for us." +
                    "\n\nSo How's Work?? \nDo you wanna go out for dinner??" +
                    "\nWe can take betty to the carnival too" +
                    "\nShe's been in her room ever since we arrived." +
                    "\nLet's go celebrate your new job..." +
                    "\n\nWhat do you say..??\n\n<i>( will Cost - " + WifeNeeds.ToString() + ")</i>";
                WifeAccept = "Give - " + WifeNeeds.ToString();
                RonDialogues = "Ron dialogue day1";
                RonAccept = "Give - "+ RonNeeds.ToString();
                break;
            case 1:
                RonNeeds = 1000;
                WifeNeeds = 500;
                SamDialogues = "<size=150%>Hey... \n<size=100%>Sam again..." +
                    "\nDid you here about the Meteor??" +
                    "\nIts bad man... <b>REAL BAD</b>" +
                    "\nThere will be notices any time soon" +
                    "\nThe colors... they change what it means..." +
                    "\n\nKeep up with it" +
                    "\nWhite will mean Black and black will mean white" +
                    "\nWho knows <b>Different Meteor</b> Different notices" +
                    "\n\nNOW GET BACK TO WORK...";
                SamAccept = "Whatever man";
                WifeDialogues = "";
                WifeAccept = "Give - " + WifeNeeds.ToString();
                RonDialogues = "<size=150%>Hello Sir... \n<size=100%>\nI'm Ron" +
                    "\nRon the Rebel" +
                    "\nI was a friend of John's " +
                    "\nSad that he got fired...but he did good..." +
                    "\n\nI would like to talk you about the Meteor" +
                    "\nWe are stating a revolution again" +
                    "\nBut we need your help in this." +
                    "\nSome Financial Support Sir.." +
                    "\n\nWhat do you say..??\n\n<i>( will Cost : " + RonNeeds.ToString() + ")</i>";
                RonAccept = "Give - " + RonNeeds.ToString();
                break;
            case 2:
                WifeNeeds = 500;
                RonNeeds = 500;
                SamDialogues = "<size=150%>Hey... \n<size=200%>Listen" +
                    "\n<size=100%>I didn't tell u about the notices much" +
                    "\nDidnt expect one today" +
                    "\nBut anyways" +
                    "\nThe colors... they basically swap" +
                    "\n\njust change them on the projects" +
                    "\nThere will be invalid projects because of this" +
                    "\n<b>Change it</b> before the day ends to avoid penalty" +
                    "\n\nNOW GET BACK TO WORK...";
                SamAccept = "R U Serious???";
                WifeDialogues = "<size=120%>:( \n<size=100%>\nHoney" +
                    "\nI got FIRED" +
                    "\nThey changed the name of a Knife" +
                    "\nI didnt know... and I used it on..." +
                    "\n<i>sob... sob... sob...</i>" +
                    "\n\nI'm gonna wait for betty to get back" +
                    "\nIt's her first day at school" +
                    "\nYou have to do good at your job honey" +
                    "\n\n<i>(Extra household expences : "+WifeNeeds.ToString()+")</i>";
                WifeAccept = "Give - " + WifeNeeds.ToString();
                RonDialogues = "<size=150%> Hello Sir... \n<size=100%>\nRon here" +
                    "\nRon the Rebel" +
                    "\nHave the notices started coming in??" +
                    "\nThis is just the beginning" +
                    "\n\nThey are going to be sending you these" +
                    "\n<size=150%>EVERYDAY" +
                    "\n<size=100%>so we need your help in this." +
                    "\nSome Financial Support Sir.." +
                    "\n\nWhat do you say..??\n\n<i>( will Cost : " + RonNeeds.ToString() + ")</i>";
                RonAccept = "Give - " + RonNeeds.ToString();
                break;
            case 3:
                WifeNeeds = 2000;
                RonNeeds = 500;
                SamDialogues = "<size=150%>$*#@&!!! \n<size=200%>Man.." +
                    "\n<size=100%>These notices are so Stupid" +
                    "\nI almost got fired today..." +
                    "\nAnyways" +
                    "\nDon't lose your money." +
                    "\n\nMoney is EVERYTHING in this world" +
                    "\nFocus on the work. keep the numbers up" +
                    "\n<b>MAKE MORE MONEY</b>" +
                    "\n\nNOW GET BACK TO WORK...";
                SamAccept = "#@%&$!!!";
                WifeDialogues = "<size=200%>:( \n<size=100%>\nHoney" +
                    "\nI just got a call from betty's school" +
                    "\nThere has been an accident" +
                    "\nI didnt know what happened..." +
                    "\n<i>sob... sob... sob...</i>" +
                    "\n\nI'm rushing there now" +
                    "\n\n<i>(Hospital expences : " + WifeNeeds.ToString() + ")</i>";
                WifeAccept = "Give - " + WifeNeeds.ToString();
                RonDialogues = "<size=150%> Hello Sir... \n<size=100%>\nRon here" +
                    "\nRon the Rebel" +
                    "\nPeople are dying everywhere" +
                    "\nBecause of all this confusion" +
                    "\n\nKeep your family close Sir..." +
                    "\nPeople think Money is Everything" +
                    "\nPower dictates" +
                    "\nBut <b>WE HAVE TO TAKE A STAND</b>" +
                    "\n\nWhat do you say..??\n\n<i>( Donate : " + RonNeeds.ToString() + ")</i>";
                RonAccept = "Donate - " + RonNeeds.ToString();

                break;
            case 4:
                WifeNeeds = 500;
                RonNeeds = 1000;
                SamDialogues = "<size=100%>hey man... " +
                    "\n<size=100%>Isn't it funny...?" +
                    "\nNot one of your projects look like its job sheet" +
                    "\n" +
                    "\n<size=200%>I GOT FIRED" +
                    "\n\n<size=100%>Yea I couldn't keep up" +
                    "\nI should probably join the rebels" +
                    "\nanyways... i have to say this... it is habitual at this point" +
                    "\n\nNOW GET BACK TO WORK... SO LONG"; ;
                SamAccept = "Loser :D";
                WifeDialogues = "<size=200%>:( \n<size=100%>\nHoney" +
                    "\nI am still in the hospital..." +
                    "\nshe is fine now..." +
                    "\nbut the Doc said we need to take more tests..." +
                    "\n<i>You dont worry...</i>" +
                    "\nI'll take care of her" +
                    "\nFocus on the job in hand." +
                    "\n\n<i>(Hospital expences : " + WifeNeeds.ToString() + ")</i>";
                WifeAccept = "Give - " + WifeNeeds.ToString();
                RonDialogues = "<size=150%>Brother... \n<size=100%>\nRon here" +
                    "\nRon the Rebel" +
                    "\n</b>It is Starting</b>" +
                    "\nWe sent out notices" +
                    "\n\nYou CAN help us..." +
                    "\nIn your position it will be more impactful" +
                    "\nMAKE HEARTS EVERYWHERE" +
                    "\nBut <b>WE HAVE TO TAKE A STAND</b>" +
                    "\n\nWhat do you say..??\n\n<i>( Donate : " + RonNeeds.ToString() + ")</i>";
                RonAccept = "Donate - " + RonNeeds.ToString();
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

