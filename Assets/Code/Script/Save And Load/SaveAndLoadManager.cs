using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoadManager : MonoBehaviour
{
    public Game game;

    public static SaveAndLoadManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }
    
    public void Save()
    {
        try
        {
            Debug.Log("Saving game on... " + Application.persistentDataPath 
                                           + "/" + game.fileName);
            string filePath = Path.Combine(Application.persistentDataPath, 
                game.fileName);
            
            File.Delete(filePath);
            
            string jsonString = JsonUtility.ToJson(game, true);
            File.WriteAllText(filePath, jsonString);

            Debug.Log("Game successfully saved!");
        }
        catch (Exception e)
        {
            Debug.Log("Failed to save game: " + e.Message);
            throw;
        }
        
    }

    public void Load()
    {
        Debug.Log("Loading Game...");
        
        string filePath = Application.persistentDataPath + "/" + game.fileName;
        string dataAsJson = File.ReadAllText(filePath);
        game = JsonUtility.FromJson<Game>(dataAsJson);
        
        Debug.Log("Done Loading Game...");
    }
}
