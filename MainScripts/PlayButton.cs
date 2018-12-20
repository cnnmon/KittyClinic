using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour {

    public LevelChanger levelChanger;

	public void OnClick () {
        GameManager.GM.dayInt = 0f;
        GameManager.GM.currentPat = 0;
        GameManager.GM.moodMeterInt = 15;

        levelChanger.FadeToLevel("Load");
	}
	
}
