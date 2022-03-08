using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistentDataManager : MonoBehaviour
{
    public static PersistentDataManager Instance;

    public string PlayerName;

    public string currentHighScoreName;
    public int currentHighScore;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        PersistentDataManager.Instance.LoadHighscore();
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/highscoredata";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentHighScoreName = data.PlayerName;
            currentHighScore = data.Score;
            Debug.Log(json);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int Score;
    }

    public void SaveHighScore()
    {
        SaveData highscoreData = new SaveData();
        highscoreData.PlayerName = PlayerName;
        highscoreData.Score = GameObject.FindObjectOfType<MainManager>().m_Points;

        string json = JsonUtility.ToJson(highscoreData);

        File.WriteAllText(Application.persistentDataPath + "/highscoredata", json);
    }
}
