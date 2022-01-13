using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class StartManager : MonoBehaviour
{
    public static StartManager Instance;

   
    public string playerName;
    public string HplayerName;
    public int HighScore;




    private void Awake()
    {
        if( Instance != null)
        {

            Destroy(gameObject);
            return;

        }

        
        Instance = this; // current instance of the class(startmanager)
        

        DontDestroyOnLoad(gameObject);
        LoadHighScoreAndHname();


    }
    [System.Serializable]
    public class SaveData
    {
        public string HplayerName;
        public int HighScore;
    }

    public void SaveHighScoreAndHname()
    {
        SaveData data = new SaveData();
        data.HighScore = StartManager.Instance.HighScore;
        data.HplayerName = StartManager.Instance.HplayerName;

        string json = JsonUtility.ToJson(data); //convert into json format

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); //create a file to store the string variable(json)

    }

    public void LoadHighScoreAndHname()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            StartManager.Instance.HighScore = data.HighScore;
            StartManager.Instance.HplayerName = data.HplayerName;
        }

    }




}
