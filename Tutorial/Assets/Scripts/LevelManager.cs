﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static int level = 1;
    public static int objectiveCount = 1;
    public static int towerCount = 1;
    public static int enemyCount = 1;
    public static int blockCount = 20;
    public GameObject theManager;
    public GameObject Player;
    MapGenerator theGenerator;
    private void Start()
    {
         theGenerator = theManager.GetComponent<MapGenerator>();
    }
    private void Update()
    {
        if (objectiveCount <= 0)
        {
            FinishLevel();
            return;
        }
        if(Player.GetComponent<PlayerHealth>().health <= 0)
        {
            EndGame();
            return;
        }
    }


    private void FinishLevel()
    {
        level += 1;
        objectiveCount = level;
        theGenerator.objectiveCount = objectiveCount;
        theGenerator.GenerateEnemies();           //makes the game a lot harder
        theGenerator.GenerateObjectives();
        
    }
    void EndGame()
    {
        Time.timeScale = 0;
        int bestScore = PlayerPrefs.GetInt("bestScore");
        if (bestScore < level)
            bestScore = level;
        PlayerPrefs.SetInt("bestScore", bestScore);
        Debug.Log(bestScore);
        Player.GetComponent<PlayerHealth>().health = 1;
    }
}
