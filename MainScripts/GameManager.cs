using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager GM;
    public Patient[] patients;
    public int currentPat;

    public string[] day = new string[] { "wed.", "thurs.", "fri." };
    public float dayInt;

    public int moodMeterInt;
    public int sumMeterChange;
    public File[] files;

    private void Awake()
    {
        JustMonika();
        DontDestroyOnLoad(gameObject);

        currentPat = 0;
        dayInt = 0f;
        moodMeterInt = 15;
    }

    void JustMonika()
    {
        if (GM == null)
        {
            GM = this;
        }
        else
        {
            if (GM != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public void AccessChangeMood(int resultInt)
    {
        StartCoroutine(WaitChangeMood(resultInt));
    }

    IEnumerator WaitChangeMood(int resultInt)
    {
        yield return new WaitForSeconds(3.5f);
        Office.Instance.NoteInit(resultInt);
        Office.Instance.ChangeMood(resultInt);
    }

}
