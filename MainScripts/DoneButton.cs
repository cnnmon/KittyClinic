using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DoneButton : MonoBehaviour {

    public TMP_InputField inputField;
    public LevelChanger levelChanger;
    int resultInt = 0;

    public void FinishPatient () {
        Patient currentPat = GameManager.GM.patients[GameManager.GM.currentPat];
        CheckText(currentPat);
        GameManager.GM.currentPat++;

        if (GameManager.GM.currentPat < GameManager.GM.patients.Length)
        {
            if (GameManager.GM.moodMeterInt > 0)
            {
                if (GameManager.GM.dayInt % 1 == 0)
                {
                    Office.Instance.ChangeMood(resultInt);
                    levelChanger.FadeToLevel("EndDay");
                }
                else
                {
                    GameManager.GM.AccessChangeMood(resultInt);
                    levelChanger.FadeToLevel("Main");
                }
            }
            else
            {
                levelChanger.FadeToLevel("Failure");
            }
        }
        else
        {
            Office.Instance.ChangeMood(resultInt);
            levelChanger.FadeToLevel("End");
        }
    
    }

    void CheckText(Patient patient)
    {
        string inputText = inputField.text;
        string[] inputWords = inputText.Split(' ');
        foreach(string word in inputWords)
        {
            if (patient.keywords.Contains(word))
            {
                resultInt = 12;
            }
            else
            {
                resultInt = -12;
            }
        }
    }
	
}
