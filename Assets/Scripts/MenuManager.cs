using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public InputField playerNameIF;
    public void NewGame()
    {
        GameManager.Instance.currentPlayerName = playerNameIF.text;
        SceneManager.LoadScene(1);   
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit
#endif
    }
}
