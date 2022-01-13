using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class StartUI : MonoBehaviour
{
    public Text BestScore;
    public InputField EnterName;


    public void Start()
    {
        ShowBestScoreAndPlayer();
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        StartManager.Instance.SaveHighScoreAndHname();

    }

    public void getName()
    {
        StartManager.Instance.playerName = EnterName.text;
    }

    private void ShowBestScoreAndPlayer()
    {
        BestScore.text = "BestScore: " + StartManager.Instance.HighScore + "Name: " + StartManager.Instance.HplayerName;
    }


}
