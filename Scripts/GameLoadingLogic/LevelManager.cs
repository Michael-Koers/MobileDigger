using System;
using System.Collections;
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
    public int baseSquare = 4;  //Base size of field
    public int levelGrowth = 5; // amount of levels before field grows
    private int square; //Current size of field
    public static int level = 1; // Current level

    //Tiles to be placed on the board
    public GameObject exit; //Exit tile NOT object
    public GameObject[] dirtTiles; //Array of dirt tiles NOT objects

    //Controller of the level fading
    public LevelFaderController levelFader;

    //UI Text displaying current level
    private GameObject currentLevel;

    //Objects on the board
    private Transform boardHolder; //Empty gameobject holding all objects
    private List<Vector3> gridPositions = new List<Vector3>();

    //Collection of all the levels by level number
    private Dictionary<int, Transform> levels = new Dictionary<int, Transform>();

    private void Awake()
    {
        square = baseSquare;
        currentLevel = GameObject.FindGameObjectWithTag("CurrentLevelText").gameObject;
        levelFader = GameObject.FindGameObjectWithTag("LevelCanvas").GetComponent<LevelFaderController>();
    }

    private void InitialiseGridList()
    {
        gridPositions.Clear();

        for (int x = 0; x < square; x++)
        {
            for (int y = 0; y < square; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0.0f));
            }
        }
    }

    private void BoardSetup()
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

    private Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);

        Debug.Log("Randomindex: " + randomIndex + ", grid count: " + gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    private void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    private void PlaceExit()
    {
        GameObject exitObject = Instantiate(exit, RandomPosition(), Quaternion.identity);
        Debug.Log("exit placed @: " + exitObject.transform.position);
        exitObject.transform.SetParent(boardHolder);
    }

    public void SetupLevel()
    {
        IncreaseDirtFieldSize();
        BoardSetup();
        InitialiseGridList();
        PlaceExit();
        UpdateLevelCanvas();
        SaveLevel();
    }

    private void IncreaseDirtFieldSize()
    {
        //Increase the  size of the field every x levels
        square = baseSquare + (int)Mathf.Floor(level / levelGrowth);
    }

    private void UpdateLevelCanvas()
    {
        currentLevel.GetComponent<Text>().text = "Level " + level;
    }

    private void SaveLevel()
    {
        levels.Add(level, boardHolder);
        Debug.Log("amount of levels saved: " + levels.Count);
    }

    private void ClearLevel()
    {
        Destroy(boardHolder.gameObject);
    }

    public IEnumerator NextLevel()
    {
        level++;
        //Start showing the new level 
        StartCoroutine(levelFader.DisplayLevel());

        //Wait for the fade in so we change the level while everything is blacked out
        yield return new WaitForSeconds(levelFader.fadeInDuration);

        //Clear and setup new level, set camera back to normal
        ClearLevel();

        ResetCamera();

        SetupLevel();
    }

    private void ResetCamera()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TouchCamera>().ResetCamera();
    }
}
