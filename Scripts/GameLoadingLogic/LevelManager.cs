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

    [Serializable]
    public class GemConfiguration
    {
        public GameObject gem;
        public Count levelApperance;
        public int spawnRate;
    }

    public List<GemConfiguration> gems;

    //Variables for current level and size of board
    public int baseSquare = 4;  //Base size of field
    public int levelGrowth = 5; // amount of levels before field grows
    [HideInInspector] public int square; //Current size of field
    public int level = 1; // Current level

    //Tiles to be placed on the board
    public GameObject exit; //Exit tile NOT object
    public GameObject entrance; //Entrance tile
    public GameObject[] dirtTiles; //Array of dirt tiles NOT objects

    //Surface tiles
    public GameObject mine;
    public GameObject blacksmith;

    //Controller of the level fading
    private LevelFaderController levelFader;

    //UI Text displaying current level
    private GameObject currentLevel;

    //Position the entrance has to be placed
    private Vector2 entrancePosition;

    //Objects on the board
    private GameObject boardHolder; //Empty gameobject holding all objects
    private List<Vector3> gridPositions = new List<Vector3>();

    //Collection of all the levels by level number
    [HideInInspector] public Dictionary<int, GameObject> levels = new Dictionary<int, GameObject>();

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
                if (entrancePosition.x == x && entrancePosition.y == y)
                {
                    continue;
                }
                gridPositions.Add(new Vector3(x, y, 0.0f));
            }
        }
    }

    private void BoardSetup()
    {
        boardHolder = new GameObject("Level" + level);

        for (int x = 0; x < square; x++)
        {
            for (int y = 0; y < square; y++)
            {
                if (entrancePosition.x == x && entrancePosition.y == y)
                {
                    continue;
                }
                GameObject toInstantiate = dirtTiles[Random.Range(0, dirtTiles.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder.transform);
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
        Vector3 position = RandomPosition();
        GameObject exitObject = Instantiate(exit, position, Quaternion.identity);
        Debug.Log("exit placed @: " + exitObject.transform.position);
        exitObject.transform.SetParent(boardHolder.transform);

        //Update the entrance position for the next level
        entrancePosition = position;
    }

    private void PlaceEntrance()
    {
        GameObject entranceObject = Instantiate(entrance, entrancePosition, Quaternion.identity);
        Debug.Log("entrance placed @: " + entranceObject.transform.position);
        entranceObject.transform.SetParent(boardHolder.transform);
    }

    private void PlaceGems()
    {
        foreach (GemConfiguration config in gems)
        {
            if (config.levelApperance.maximum >= level && config.levelApperance.minimum <= level)
            {
                float spawnNumber = Random.Range(0, config.spawnRate);
                float spawnAmount = 0;

                for (int i = 0; i < gridPositions.Count; i++)
                {
                    if (spawnNumber == Random.Range(0, config.spawnRate))
                    {
                        spawnAmount++;
                    }
                }

                for (int i = 0; i < spawnAmount; i++)
                {
                    Vector3 randomPosition = RandomPosition();
                    GameObject gemObject = Instantiate(config.gem, randomPosition, Quaternion.identity);
                    Debug.Log("Gem: " + config.gem.name + " was placed @: " + gemObject.transform.position);
                    gemObject.transform.SetParent(boardHolder.transform);
                }
            }
        }
    }

    public void SetupLevel()
    {
        Debug.Log("Setting up world");

        //If the level was once already created and saved, load the level
        if (levels.ContainsKey(level))
        {
            levels[level].gameObject.SetActive(true);
            boardHolder = levels[level];
        }
        else if (level == 0)
        {
            CreateSurface();
            SaveLevel();
        }
        else
        {
            IncreaseDirtFieldSize();
            BoardSetup();
            InitialiseGridList();
            PlaceEntrance();
            PlaceExit();
            PlaceGems();
            SaveLevel();
        }
        UpdateLevelCanvas();
    }

    private void IncreaseDirtFieldSize()
    {
        //Increase the  size of the field every x levels
        square = baseSquare + (int)Mathf.Floor(level / levelGrowth);
    }

    private void UpdateLevelCanvas()
    {
        currentLevel.GetComponent<Text>().text = GetLevelToString();
    }

    //Localy saves the levels in a dictionary
    private void SaveLevel()
    {
        //if the level already exists in the dictionary, override the value
        if (levels.ContainsKey(level))
        {
            levels[level] = boardHolder;
        }
        else
        {
            levels.Add(level, boardHolder);
        }


        Debug.Log("amount of levels saved: " + levels.Count);
    }

    private void ClearLevel()
    {
        boardHolder.gameObject.SetActive(false);
    }

    public IEnumerator GoToLevel()
    {
        StartCoroutine(levelFader.DisplayLevel());

        //Wait for the fade in so we change the level while everything is blacked out
        yield return new WaitForSeconds(levelFader.fadeInDuration);

        //Clear and setup new level, set camera back to normal
        ClearLevel();

        ResetCamera();

        SetupLevel();
    }

    public void NextLevel()
    {
        level++;
        StartCoroutine(GoToLevel());
    }

    public void PreviousLevel()
    {
        level--;
        StartCoroutine(GoToLevel());
    }

    private void ResetCamera()
    {
        Debug.Log("Resetting camera");

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TouchCamera>().ResetCamera();
    }

    private void CreateSurface()
    {
        boardHolder = new GameObject("Surface");

        GameObject blacksmithObject = Instantiate(blacksmith, blacksmith.GetComponent<BlacksmithScript>().position, Quaternion.identity);
        blacksmithObject.transform.SetParent(boardHolder.transform);

        GameObject mineObject = Instantiate(mine, mine.GetComponent<MineScript>().position, Quaternion.identity);
        entrancePosition = mine.GetComponent<MineScript>().position;
        mineObject.transform.SetParent(boardHolder.transform);
    }

    //For displaying purposes on canvasses
    public String GetLevelToString()
    {
        if (level == 0)
        {
            return "Surface";
        }
        else
        {
            return "Level " + level;
        }
    }
}
