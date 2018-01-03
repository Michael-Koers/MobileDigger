using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public LevelManager boardScript;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<LevelManager>();
    }

    void onLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //Load();
        InitGame();
    }

    void OnEnable()
    {
        /*Tell our ‘OnLevelFinishedLoading’ function to
        start listening for a scene change event as soon as
        this script is enabled.*/
        SceneManager.sceneLoaded += onLevelFinishedLoading;
    }

    void OnDisable()
    {
        /*Tell our ‘OnLevelFinishedLoading’ function to stop
        listening for a scene change event as soon as this
        script is disabled.
        Remember to always have an unsubscription for every
        delegate you subscribe to!*/
        SceneManager.sceneLoaded -= onLevelFinishedLoading;
    }

    void InitGame()
    {
        boardScript.SetupLevel();
    }

    //public void Save()
    //{
    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");

    //    PlayerData data = new PlayerData()
    //    {
    //        levels = boardScript.levels,
    //        gold = Player.player.score
    //    };

    //    bf.Serialize(file, data);
    //    file.Close();
    //}

    //public void Load()
    //{
    //    if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();
    //        FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
    //        PlayerData data = (PlayerData)bf.Deserialize(file);
    //        file.Close();

    //        Player.player.score = data.gold;

    //        boardScript.levels = data.levels;

    //    }
    //}

    //[Serializable]
    //public class PlayerData
    //{
    //    public Dictionary<int, GameObject> levels;
    //    public float gold;
    //}
}
