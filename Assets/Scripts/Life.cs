using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public float Money;
    public float WalletMoney;
    public float TomoExpense;
    public int gameDay;

    public Text LifeText;
    public string temptext;
    
    public int noofCorrectproject;

    private void Start()
    {
        Money = 100;
        WalletMoney = Money;
    }

    private void Update()
    {
        if (gameObject.GetComponent<GameState>().dayCount != gameDay)
        {
            
            int score = gameObject.GetComponent<GameState>().Score;
            int addMoney = score * 5;
            Money = addMoney + Money - TomoExpense;
            gameDay++;
            TomoExpense = Random.Range(1, gameDay * 2);
        }

        temptext = "Money = " + Money.ToString() + "\nTomorrows Expense = " + TomoExpense.ToString();
        LifeText.text = temptext;
    }
}
