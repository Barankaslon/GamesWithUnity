using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameData gameData;
    [HideInInspector] public int star_Score, score_Count, selected_Index;

    [HideInInspector] public bool[] heroes;
    [HideInInspector] public bool playSound = true;
    private string data_Path = "GameData.dat";

    void Awake()
    {
        MakeSingleton();
        InitializeGameData();
    }

    void Start()
    {
        print(Application.persistentDataPath + data_Path);

        if(gameData != null)
        {
            print("Data LOADED");
        }
    }

    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void InitializeGameData()
    {
        LoadGameData();
        if(gameData == null)
        {
            star_Score = 0;
            score_Count = 0;
            selected_Index = 0;

            heroes = new bool[9];
            heroes[selected_Index] = true;

            for(int i = 1; i < heroes.Length; i++)
            {
                heroes[i] = false;
            }

            gameData = new GameData();
            gameData.StarScore = star_Score;
            gameData.ScoreCount = score_Count;
            gameData.Heroes = heroes;
            gameData.SelectedIndex = selected_Index;

            SaveGameData();
        }
    }

    public void SaveGameData()
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Create(Application.persistentDataPath + data_Path);
            if(gameData != null)
            {
                gameData.Heroes = heroes;
                gameData.StarScore = star_Score;
                gameData.ScoreCount = score_Count;
                gameData.SelectedIndex = selected_Index;

                bf.Serialize(file, gameData);
            }
        }
        catch(Exception e)
        {

        }
        finally
        {
            if(file != null)
            {
                file.Close();
            }
        }
    }

    void LoadGameData()
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + data_Path, FileMode.Open);
            gameData = (GameData)bf.Deserialize(file);

            if(gameData != null)
            {
                star_Score = gameData.StarScore;
                score_Count = gameData.ScoreCount;
                heroes = gameData.Heroes;
                selected_Index = gameData.SelectedIndex;
            }
        }
        catch(Exception e)
        {

        }   
        finally
        {
            if(file != null)
            {
                file.Close();
            }
        }
    }
}
