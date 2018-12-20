using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Ink;
using TMPro;

public class Office : MonoBehaviour {

    public static Office Instance;
    public Slider moodMeter;
    public TextMeshProUGUI moodMeterTxt;

    public Canvas canvas;
    public GameObject cat;
    public GameObject moodChange;

    public Color color1;
    public Color color2;

    public Toggle togglePrefab;

    public GameObject papersBase;
    public GameObject puzzlePrefab;
    public GameObject searchBase;

    public Canvas overlayCanvas;
    public Button goodNote, badNote;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Initiate mood meter, patient, day
        Patient currentPat = GameManager.GM.patients[GameManager.GM.currentPat];
        cat.GetComponent<Image>().sprite = currentPat.sprite;
        moodMeter.value = GameManager.GM.moodMeterInt;
        moodMeterTxt.text = GameManager.GM.moodMeterInt.ToString();
        GameManager.GM.dayInt += 0.5f;
    }

    public void ChangeMood(int num)
    {
        GameManager.GM.moodMeterInt += num;
        GameManager.GM.sumMeterChange += num;

        moodMeter.value = GameManager.GM.moodMeterInt;
        GameObject moodTxt = Instantiate(moodChange, new Vector2(4.5f, 0), Quaternion.identity, canvas.transform);
        moodTxt.GetComponent<TextMeshProUGUI>().text = num.ToString();
        moodMeterTxt.text = GameManager.GM.moodMeterInt.ToString();

        Image meter = moodMeter.transform.GetChild(2).GetComponentInChildren<Image>(); 
        if (meter.color == color1)
        {meter.color = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, 2));}
        else
        {meter.color = Color.Lerp(color2, color1, Mathf.PingPong(Time.time, 2));}
    }

    public void NoteInit(int resultInt)
    {
        if(resultInt > 0)
        {
            Button note = Instantiate(goodNote) as Button;
            note.transform.SetParent(overlayCanvas.transform, false);
        }
        else if (resultInt < 0)
        {
            Button note = Instantiate(badNote) as Button;
            note.transform.SetParent(overlayCanvas.transform, false);
        }
    }


    public void FileInit(File file)
    {
        searchBase.SetActive(false);
        papersBase.SetActive(true);

        foreach (Sprite sprite in file.puzzPieces)
        {
            GameObject puzzPiece = Instantiate(puzzlePrefab, papersBase.transform);
            puzzPiece.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

    public void DrawerInit()
    {
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("puzzle");
        foreach(GameObject piece in pieces)
        {
            Destroy(piece);
        }

        searchBase.SetActive(true);
        papersBase.SetActive(false);
    }

}
