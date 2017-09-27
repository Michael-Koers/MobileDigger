using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public LevelManager boardScript;
    public int level = 0;

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
        level++;

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

    public void GameOver()
    {
        //levelText.text = "After " + level + " days, you starved ..";
        //levelImage.SetActive(true);
        //enabled = false;
    }


    void InitGame()
    {
        boardScript.SetupScene();
    }

}
