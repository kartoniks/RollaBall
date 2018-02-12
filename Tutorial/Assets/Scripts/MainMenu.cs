using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("test");
    }

    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }

    public void DisplayScore()
    {
        int bestScore = PlayerPrefs.GetInt("bestScore");
        GameObject.Find("HighscoreButton").GetComponentInChildren<Text>().text = bestScore.ToString();
    }
}
