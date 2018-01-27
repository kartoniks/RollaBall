using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public class node
    {
        public int x;
        public int z;
    }
    public int boardsize = 20;
    List<node> board = new List<node>(); 
    public int blockCount;
    public int enemyCount;
    public int towerCount;
    public int objectiveCount;

    public Transform boardTransform;
    public GameObject block;
    public GameObject tower;
    public GameObject enemy;
    public GameObject objective;

    private void Awake()
    {
        objectiveCount = LevelManager.objectiveCount;
        blockCount = LevelManager.blockCount;
        enemyCount = LevelManager.enemyCount;
        towerCount = LevelManager.towerCount;

        InitialiseBoard();
        GenerateBlocks();
        GenerateEnemies();
        GenerateObjectives();
    }

    void InitialiseBoard()
    {
        for (int i = 1; i < boardsize-1; i++)
        {
            for (int j = 1; j < boardsize-1; j++)
            {
                node newNode = new node();
                newNode.x = i;
                newNode.z = j;
                board.Add(newNode);
            }
        }
    }

    private void Generate(GameObject toGenerate)
    {
        int position = Random.Range(0, board.Count);
        node toPlace = board[position];
        if(toGenerate.tag == "Ground" || toGenerate.name =="Tower")
            board.RemoveAt(position);
        Vector3 place = new Vector3(toPlace.x, 0.5f, toPlace.z);
        Instantiate(toGenerate, place, Quaternion.identity);

    }

    public void GenerateBlocks()
    {
        for (int i = 0; i < blockCount; i++)
        {
            Generate(block);   
        }
    }
    public void GenerateObjectives()
    {
        for(int i=0; i < objectiveCount; i++)
        {
            Generate(objective);
        }
    }
    public void GenerateEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Generate(enemy);
        }
        for (int i = 0; i < towerCount; i++)
        {
            Generate(tower);
        }
    }
}
