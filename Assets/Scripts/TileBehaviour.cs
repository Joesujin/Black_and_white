using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileBehaviour : MonoBehaviour
{
    /*
    public GameObject WhiteButton = GameObject.FindGameObjectWithTag("WhiteButton");
    public GameObject BlackButton = GameObject.FindGameObjectWithTag("BlackButton");
    public GameObject RedButton = GameObject.FindGameObjectWithTag("RedButton");
    public GameObject BlueButton = GameObject.FindGameObjectWithTag("BlueButton");
    public GameObject GreenButton = GameObject.FindGameObjectWithTag("GreenButton");
    public GameObject YellowButton = GameObject.FindGameObjectWithTag("YellowButton");
    */

    Dictionary<int, Color> defaultColors = new Dictionary<int, Color>();
    Dictionary<int, Color> inGamecolors = new Dictionary<int, Color>();


    public Color selectedColor;
    public int color_id;
    public int ownColor;

    bool colorChanged;
    GameObject GameManager;


    private void OnEnable()
    {
        defaultColors.Add(0, Color.gray);
        defaultColors.Add(1, Color.white);
        defaultColors.Add(2, Color.black);
        defaultColors.Add(3, Color.red);
        defaultColors.Add(4, Color.blue);
        defaultColors.Add(5, Color.green);
        defaultColors.Add(6, Color.yellow);

        foreach(int key in defaultColors.Keys)
        {
            inGamecolors.Add(key, defaultColors[key]);
        }

        GameManager = GameObject.Find("GameManager");

        List<Notices> NoticesCopy = GameManager.GetComponent<GameState>().notices;

        if(NoticesCopy != null)
        {
            int k = 0;
            foreach (Notices notices in NoticesCopy)
            {
                int tempC1 = NoticesCopy[k].colorID1;
                int tempC2 = NoticesCopy[k].colorID2;

                /*
                Color TempCol = inGamecolors[tempC1];
                inGamecolors[tempC1] = inGamecolors[tempC2];
                inGamecolors[tempC2] = TempCol;
                */
                
              if(inGamecolors[tempC1] == defaultColors[tempC1] && inGamecolors[tempC2] == defaultColors[tempC2])
              {
                    inGamecolors[tempC1] = defaultColors[tempC2];
                    inGamecolors[tempC2] = defaultColors[tempC1];
              }
              else
              {
                    inGamecolors[tempC1] = inGamecolors[tempC2];
                    inGamecolors[tempC2] = inGamecolors[tempC1];
              }
             
            }
            k++;
        }


        this.GetComponent<SpriteRenderer>().color = Color.grey;
        ownColor = 0;
        colorChanged = false;
        Events.ChangeColor += changeColor;
        Events.ColorId += changeColorId;
        Events.refreshTile += ChangeColorWithID;
    }

    private void OnDisable()
    {
        Events.ChangeColor -= changeColor;
        Events.ColorId -= changeColorId;
        Events.refreshTile -= ChangeColorWithID;
    }

    
    
    private void OnMouseDown()
    {
        this.GetComponent<SpriteRenderer>().color = selectedColor;
        this.colorChanged = true;
        this.ownColor = color_id;
    }
    
    private void OnMouseEnter()
    {
        if(Input.GetMouseButton(0) == true)
        {
            this.GetComponent<SpriteRenderer>().color = selectedColor;
            this.colorChanged = true;
            this.ownColor = color_id;
        }
    }
    

    private void changeColor(Color color)
    {
        this.selectedColor = color;
    }

    public void ChangeColorWithID(int _colorId)
    {
        int Colorid = _colorId;
        this.ownColor = _colorId;

        switch (Colorid)
        {
            case 0:
                this.changeColor(inGamecolors[_colorId]);
                break;
            case 1:
                this.changeColor(inGamecolors[_colorId]);
                break;
            case 2:
                this.changeColor(inGamecolors[_colorId]);
                break;
            case 3:
                this.changeColor(inGamecolors[_colorId]);
                break;
            case 4:
                this.changeColor(inGamecolors[_colorId]);
                break;
            case 5:
                this.changeColor(inGamecolors[_colorId]);
                break;
            case 6:
                this.changeColor(inGamecolors[_colorId]);
                break;
        }
        GetComponent<SpriteRenderer>().color = selectedColor;


    }

    private void changeColorId(int colorid)
    {
        this.color_id = colorid;
    }

    public int returnColor()
    {
        return(ownColor);
    }

    public bool ColorChanged()
    {
        return (colorChanged);
    }

    public void swapColors(int c1, int c2)
    {
        Color Col1 = inGamecolors[c1];
        Color Col2 = inGamecolors[c2];

        inGamecolors[c2] = Col1;
        inGamecolors[c1] = Col2;
    }
}
