using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string bestPlayerName;
    public string currentPlayerName;
    public int bestPoints;

    private void Awake()
    {
        // starts of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayer();

    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestPoints;
    }

    public void SavePlayer()
    {
        SaveData data = new SaveData();
        data.bestPlayerName = bestPlayerName;
        data.bestPoints = bestPoints;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            bestPoints = data.bestPoints;
        }
    }
}
