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

    public Dictionary<int, Color> defaultColors = new Dictionary<int, Color>();
    public Dictionary<int, Color> inGameColors = new Dictionary<int, Color>();
    
    public Color selectedColor;
    public int color_id;
    public int ownColor;

    bool colorChanged;

    public GameObject gameManager;

    private void OnEnable()
    {
        gameManager = GameObject.Find("GameManager");

        defaultColors.Add(0, Color.gray);
        defaultColors.Add(1, Color.white);
        defaultColors.Add(2, Color.black);
        defaultColors.Add(3, Color.red);
        defaultColors.Add(4, Color.blue);
        defaultColors.Add(5, Color.green);
        defaultColors.Add(6, Color.yellow);

        foreach (int key in defaultColors.Keys)
        {
            inGameColors.Add(key, defaultColors[key]);
        }

        List<Notices> noticesCopy = gameManager.GetComponent<GameState>().notices;

        if(noticesCopy != null)
        {
            int k = 0;
            foreach (Notices notices in noticesCopy)
            {
                int tempc1 = noticesCopy[k].col1Id;
                int tempc2 = noticesCopy[k].col2Id;

                Color TempCol = inGameColors[tempc1];
                inGameColors[tempc1] = inGameColors[tempc2];
                inGameColors[tempc2] = TempCol;
                /*
                if(inGameColors[tempc1] == defaultColors[tempc1] && inGameColors[tempc2] == defaultColors[tempc2])
                {
                    inGameColors[tempc1] = defaultColors[tempc2];
                    inGameColors[tempc2] = defaultColors[tempc1];

                }
                else
                {
                    inGameColors[tempc1] = inGameColors[tempc2];
                    inGameColors[tempc2] = inGameColors[tempc1];

                }
                */




                k++;
            }
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
                this.changeColor(inGameColors[Colorid]);
                break;
            case 1:
                this.changeColor(inGameColors[Colorid]);
                break;
            case 2:
                this.changeColor(inGameColors[Colorid]);
                break;
            case 3:
                this.changeColor(inGameColors[Colorid]);
                break;
            case 4:
                this.changeColor(inGameColors[Colorid]);
                break;
            case 5:
                this.changeColor(inGameColors[Colorid]);
                break;
            case 6:
                this.changeColor(inGameColors[Colorid]);
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
        Color Col1 = inGameColors[c1];
        Color Col2 = inGameColors[c2];

        inGameColors[c2] = Col1;
        inGameColors[c1] = Col2;
    }
}
