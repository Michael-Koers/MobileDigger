using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    //Variables for current level and size of board
    public int square = 4;
    public static int level = 1;

    //Tiles to be placed on the board
    public GameObject exit;
    public GameObject[] dirtTiles;

    //UI Text displaying current level
    private GameObject currentLevel;

    //Objects on the board
    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    //Collection of all the levels by level number
    private Dictionary<int, Transform> levels = new Dictionary<int, Transform>();

    private void Awake()
    {
        currentLevel = GameObject.FindGameObjectWithTag("CurrentLevelText").gameObject;
    }

    void InitialiseGridList()
    {
        gridPositions.Clear();

        for (int x = 1; x < square; x++)
        {
            for (int y = 1; y < square; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0.0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Level" + level).transform;

        for (int x = 0; x < square; x++)
        {
            for (int y = 0; y < square; y++)
            {
                GameObject toInstantiate = dirtTiles[Random.Range(0, dirtTiles.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    void PlaceExit()
    {
        GameObject exitObject = Instantiate(exit, RandomPosition(), Quaternion.identity);
        exitObject.transform.SetParent(boardHolder);
    }

    public void SetupScene()
    {
        Debug.Log("Setting up new scene ");
        BoardSetup();
        InitialiseGridList();
        PlaceExit();
        UpdateLevelCanvas();
        SaveLevel();
    }

    private void UpdateLevelCanvas()
    {
        Debug.Log("Updating current level text ");
        currentLevel.GetComponent<Text>().text = "Level : " + level;
    }

    private void SaveLevel()
    {
        Debug.Log("Saving level");
        levels.Add(level, boardHolder);
        Debug.Log("amount of levels saved: " + levels.Count);
    }

    private void ClearScene()
    {
        Debug.Log("Clearing Scene");
        Destroy(boardHolder.gameObject);
    }

    public void NextLevel()
    {
        Debug.Log("Going to next level .. ");
        ClearScene();
        level++;
        SetupScene();
    }
}
