using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    public TextMeshProUGUI txtHighScore;
    
    public TMP_InputField fieldNameInput;

    private void Start()
    {
        txtHighScore.text = $"{PersistentDataManager.Instance.currentHighScoreName}: {PersistentDataManager.Instance.currentHighScore}";
    }

    public void StartGame()
    {
        if(fieldNameInput.text != null)
        {
            PersistentDataManager.Instance.SetPlayerName(fieldNameInput.text);
            SceneManager.LoadScene(1);
        }
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
