using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndManager : MonoBehaviour {

    public GameObject MedEnd;
    public TextMeshProUGUI percentTxt;

    private void Start()
    {
        if (GameManager.GM.moodMeterInt > 50)
        {
            MedEnd.SetActive(false);
        }
        percentTxt.text = GameManager.GM.moodMeterInt + "%";
    }
}
