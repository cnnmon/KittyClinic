using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadManager : MonoBehaviour {

    public TextMeshProUGUI dayTxt;
    public LevelChanger levelChanger;

	void Start () {
        dayTxt.text = GameManager.GM.day[(int)GameManager.GM.dayInt];
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            levelChanger.FadeToLevel("Main");
        }
	}
}
