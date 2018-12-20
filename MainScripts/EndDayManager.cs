using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndDayManager : MonoBehaviour {

    public Slider slider;
    public LevelChanger levelChanger;
    public TextMeshProUGUI sumTxt;
    public TextMeshProUGUI commentTxt;

    string[] posComments = { "great job!", "keep it up!", "good work." };
    string[] negComments = { "need to work harder...", "maybe next time.", "gotta be more careful" };

    void Start () {
        slider.value = GameManager.GM.moodMeterInt;

        int sum = GameManager.GM.sumMeterChange;
        if(sum > 0)
        {
            sumTxt.text = "+" + GameManager.GM.sumMeterChange.ToString();
            commentTxt.text = posComments[Random.Range(0, 2)];
        }
        else
        {
            sumTxt.text = GameManager.GM.sumMeterChange.ToString();
            commentTxt.text = negComments[Random.Range(0, 2)];
        }

        GameManager.GM.sumMeterChange = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            levelChanger.FadeToLevel("Load");
        }
    }
}
