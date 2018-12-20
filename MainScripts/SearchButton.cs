using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchButton : MonoBehaviour {

    public TMP_InputField inputField;
    public GameObject errorMsg;
    File currentFile;

    string inputTxt;

    public void OnSearch()
    {
        inputTxt = inputField.text.ToLower();
        bool foundFile = false;

        //adds all keywords into keyword list in order to check if it fits
        foreach (File file in GameManager.GM.files)
        {
            if (file.keywords.Contains(inputTxt))
            {
                currentFile = file;
                foundFile = true;
                break;
            }
        }

        if (foundFile)
        {
            Office.Instance.FileInit(currentFile);
        }
        else
        {
            StartCoroutine("WaitAndDestroy");
        }

    }

    public IEnumerator WaitAndDestroy()
    {
        errorMsg.SetActive(true);
        yield return new WaitForSeconds(2);
        errorMsg.SetActive(false);
    }

}
