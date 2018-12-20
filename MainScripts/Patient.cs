using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[System.Serializable]
public class Patient : ScriptableObject {

    public string patName = "Name";
    public TextAsset storyJSON;
    public Sprite sprite;
    public List<string> keywords = new List<string>();

    [Serializable]
    public struct Papers
    {
        public Sprite paper;
        public Sprite paper2;
        public string threadName;
    }

    public Papers[] papers;

}
