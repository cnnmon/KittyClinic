using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    string levelToLoad;
    Image image;

    public void Start()
    {
        //just to make it easier when im working with the ui
        image = GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 100;
        image.color = tempColor;
    }

    public void FadeToLevel(string levelName)
    {
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
