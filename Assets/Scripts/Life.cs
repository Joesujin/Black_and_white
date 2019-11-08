using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Life : MonoBehaviour
{
    public float Money;
    public float WalletMoney;
    public float TomoExpense;
    public float income;
    public float totalPenalty;


    public TextMeshProUGUI LifeText;
    public string temptext;
    
    public int noofCorrectproject;

    private void Start()
    {
        Money = 100;
        WalletMoney = Money;
        TomoExpense = 100;
    }


    public void UpdateLifeStats()
    {
        WalletMoney = Money;

        income = 0;
        totalPenalty = 0;
        List<Project> ActiveProjects = gameObject.GetComponent<GameState>().projects;

        foreach(Project _project in ActiveProjects)
        {
            if (_project.isPass)
            {
                Money = Money + _project.ProjectWorth;
                income = income + _project.ProjectWorth;
            }
            else if (!_project.isPass)
            {
                Money = Money - _project.penalty;
                totalPenalty = totalPenalty + _project.penalty;
            }
        }

        
        //Money = Money - TomoExpense;

        //TomoExpense = (int)Random.Range(100, Money);
        temptext = "Wallet = " + WalletMoney.ToString() + 
            "\n" +
            "\nIncome = " + income.ToString() +
            "\nTotal Penalty = " + totalPenalty.ToString()+
            "\nExpence = " + TomoExpense.ToString()+
            "\n" +
            "\nBalance =" + Money.ToString();
        //LifeText.text = temptext;
    }

    public void DeductMoney(int _amount)
    {
        Money = Money - _amount;
    }
}
