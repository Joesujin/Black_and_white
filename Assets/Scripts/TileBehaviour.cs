using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class TileBehaviour : MonoBehaviour
{
    
    public GameObject gameState;

    public Color selectedColor;
    public int color_id;
    public int ownColor;
    public Sprite stroke1;
    public Sprite stroke2;
    public Sprite stroke3;
    public Sprite stroke4;
    public Sprite stroke5;
    public Sprite stroke6;

    public int spriteSelection;

    bool colorChanged;
    public AudioSource taptap;


    private void OnEnable()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        gameState = GameObject.Find("GameManager");
        selectedColor = gameState.GetComponent<GameState>().SelectedColor;
        color_id = gameState.GetComponent<GameState>().SelectedColorID;

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
        iTween.ScaleFrom(gameObject, iTween.Hash("scale", new Vector3(0.7f,0.7f,0),
            "speed", 20f,
            "easetype", iTween.EaseType.easeInOutQuint));
        SpriteChanger();
        this.GetComponent<SpriteRenderer>().color = selectedColor;
        this.colorChanged = true;
        this.ownColor = color_id;
        //iTween.ScaleTo(gameObject, new Vector3(1f, 1f, 0), 0.3f);
        //gameState.GetComponent<AudioSource>().Play();
    }
    
    private void OnMouseEnter()
    {
        if(Input.GetMouseButton(0) == true)
        {
            //iTween.ScaleFrom(gameObject, iTween.Hash("scale", new Vector3(0.7f, 0.7f, 0),
             //   "speed", 20f,
               // "easetype", iTween.EaseType.easeInOutQuint));
            SpriteChanger();
            this.GetComponent<SpriteRenderer>().color = selectedColor;
            this.colorChanged = true;
            this.ownColor = color_id;
            //iTween.ScaleTo(gameObject, new Vector3(1f, 1f, 0), 0.3f);


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
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
            case 1:
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
            case 2:
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
            case 3:
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
            case 4:
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
            case 5:
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
            case 6:
                this.changeColor(gameState.GetComponent<GameState>().DefaultColors[Colorid]);
                break;
        }
        GetComponent<SpriteRenderer>().color = selectedColor;
        selectedColor = gameState.GetComponent<GameState>().SelectedColor;
        color_id = gameState.GetComponent<GameState>().SelectedColorID;
        SpriteChanger();

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

    public void SpriteChanger()
    {
        spriteSelection = (int)Random.Range(1, 7);
        switch (spriteSelection)
        {
            case 0:
                this.GetComponent<SpriteRenderer>().sprite = null;
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = stroke1;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = stroke2;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = stroke3;
                break;
            case 4:
                this.GetComponent<SpriteRenderer>().sprite = stroke4;
                break;
            case 5:
                this.GetComponent<SpriteRenderer>().sprite = stroke5;
                break;
            case 6:
                this.GetComponent<SpriteRenderer>().sprite = stroke6;
                break;
        }
    }
}
