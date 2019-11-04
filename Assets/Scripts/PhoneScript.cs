using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PhoneScript : MonoBehaviour
{

    public bool visible;
    public GameObject gamemanager;
    public GameObject Phone;

    public int CallerID;
    public Sprite Wife;
    public Sprite SupSam;
    public Sprite RevRon;

    public string callDialogue;
    public string Money;

    public GameObject CallerImage;
    

    public TextMeshProUGUI callText;
    public Text MoneytobeSpent;

    void Start()
    {
        visible = false;
        gameObject.SetActive(visible);
        Events.PhoneCall += PhoneCall;
    }

    private void OnDestroy()
    {
        Events.PhoneCall -= PhoneCall;
    }


    public void visiblity()
    {
        gamemanager.GetComponent<GameState>().PhoneIdle();
        visible = !visible;
        gameObject.SetActive(visible);
    }

    public void PhoneCall(int _callerId, string _calltext, string _moneyCost)
    {

        CallerID = _callerId;
        callDialogue = _calltext;
        Money = _moneyCost;
        switch (CallerID)
        {
            case 1:
                CallerImage.GetComponent<Image>().sprite = SupSam;
                break;
            case 2:
                CallerImage.GetComponent<Image>().sprite = Wife;
                break;
            case 3:
                CallerImage.GetComponent<Image>().sprite = RevRon;
                break;
        }

        callText.text = callDialogue;
        MoneytobeSpent.text = Money;
    }
}
