using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameModeScript : MonoBehaviour
{
    public int currentGameMode;
    public int playerSkill;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        playerSkill = 5;
    }

    public void OnEasyPressed()
    {
        currentGameMode = 1;
        SceneManager.LoadScene("HackingGame");
    }
    public void OnMediumPressed()
    {
        currentGameMode = 2;
        SceneManager.LoadScene("HackingGame");
    }
    public void OnHardPressed()
    {
        currentGameMode = 3;
        SceneManager.LoadScene("HackingGame");
    }
}
