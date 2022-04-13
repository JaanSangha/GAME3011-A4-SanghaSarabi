using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    [SerializeField]
    private GameButton gameButton;
    private int tempSpriteNumber;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Transform startTransform;
    private int gridSize = 6;
    [SerializeField]
    private List<GameButton> buttonList;

    public int gameMode;
    public int firstNum;
    public int secondNum;
    public int thirdNum;
    public int fourthNum;
    public TMP_Text scoreText;
    public TMP_Text codeText;
    public TMP_Text timerText;
    public TMP_Text endText;
    public Slider scoreSlider;
    public GameObject endScreen;
    public GameObject minigameScreen;
    public GameObject curGameMode;

    private int Score=0;
    private int maxScore = 500;
    private float timeLeft =60;
    private bool firstNumSet, secondNumSet, thirdNumSet, fourthNumSet = false;
    private AudioSource audioSource;
    void Start()
    {
        firstNum = Random.Range(0, 99);
        secondNum = Random.Range(0, 99);
        thirdNum = Random.Range(0, 99);
        fourthNum = Random.Range(0, 99);

        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
        buttonList = new List<GameButton>();
        curGameMode = GameObject.FindGameObjectWithTag("GameMode");
        Vector3 tempPos = startTransform.position;

        for (int row = 0; row < gridSize; row++)
        {
            for (int column = 0; column < gridSize; column++)
            {
                buttonList.Add(Instantiate(gameButton, tempPos, transform.rotation));
                buttonList[buttonList.Count - 1].gameObject.transform.SetParent(minigameScreen.transform);
                buttonList[buttonList.Count - 1].row = row;
                buttonList[buttonList.Count - 1].column = column;
                tempPos.x += 105;

            }
            tempPos.x = startTransform.position.x;
            tempPos.y += 106;

        }

        //if (curGameMode.GetComponent<GameModeScript>().currentGameMode == 1)
        //{
        //    timeLeft = 45;
        //    maxScore = 1000;
        //}
        //else if (curGameMode.GetComponent<GameModeScript>().currentGameMode == 2)
        //{
        //    timeLeft = 60;
        //    maxScore = 1000;
        //}
        //else if (curGameMode.GetComponent<GameModeScript>().currentGameMode == 3)
        //{
        //    timeLeft = 80;
        //    maxScore = 750;
        //}
        scoreSlider.maxValue = maxScore;
        codeText.text = ("Code: " + firstNum + " " + secondNum + " " + thirdNum + " " + fourthNum);
        CheckForCode();
    }

    private void CheckForCode()
    {
        for (int list = 0; list < buttonList.Count -1; list++)
        {
            if (buttonList[list].isFirstNum)
            {
                firstNumSet = true;
            }
            else if (buttonList[list].isSecondNum)
            {
                secondNumSet = true;
            }
            else if (buttonList[list].isThirdNum)
            {
                thirdNumSet = true;
            }
            else if (buttonList[list].isFourthNum)
            {
                fourthNumSet = true;
            }
        }


        if (firstNumSet == false)
        {
            SetFirstNumber();
        }
        if (secondNumSet == false)
        {
            SetSecondNumber();
        }
        if (thirdNumSet == false)
        {
           SetThirdNumber();
        }
        if (fourthNumSet == false)
        {
           SetFourthNumber();
        }
    }

    private void SetFirstNumber()
    {
        int randButton = Random.Range(0, buttonList.Count - 1);

        if (buttonList[randButton].isAnyNum == false)
        {
            buttonList[randButton].randomNumber = firstNum;
            buttonList[randButton].SetButtonNumber();
        }
        else
        {
            SetFirstNumber();
        }
    }
    private void SetSecondNumber()
    {
        int randButton = Random.Range(0, buttonList.Count - 1);

        if (buttonList[randButton].isAnyNum == false)
        {
            buttonList[randButton].randomNumber = secondNum;
            buttonList[randButton].SetButtonNumber();
        }
        else
        {
            SetSecondNumber();
        }
    }

    private void SetThirdNumber()
    {
        int randButton = Random.Range(0, buttonList.Count - 1);

        if (buttonList[randButton].isAnyNum == false)
        {
            buttonList[randButton].randomNumber = thirdNum;
            buttonList[randButton].SetButtonNumber();
        }
        else
        {
            SetThirdNumber();
        }
    }
    private void SetFourthNumber()
    {
        int randButton = Random.Range(0, buttonList.Count - 1);

        if (buttonList[randButton].isAnyNum == false)
        {
            buttonList[randButton].randomNumber = fourthNum;
            buttonList[randButton].SetButtonNumber();
        }
        else
        {
            SetFourthNumber();
        }
    }
    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            Time.timeScale = 0;
            //curGameMode.GetComponent<GameModeScript>().currentGameMode = 1;
            endScreen.SetActive(true);
            minigameScreen.SetActive(false);
            endText.text = ("You Lose! End Score: " + Score);
        }
        scoreText.text = ("Score: " + Score);
        timerText.text = ("Time Remaining: " + timeLeft.ToString("F0"));
        scoreSlider.value = Score;

        //gameMode = curGameMode.GetComponent<GameModeScript>().currentGameMode;

        if(Score >= maxScore)
        {
            Time.timeScale = 0;
           // curGameMode.GetComponent<GameModeScript>().currentGameMode = 1;
            endScreen.SetActive(true);
            minigameScreen.SetActive(false);
            endText.text = ("You Win! End Score: " + Score);
        }
    }
 
    public void OnEasyPressed()
    {
        curGameMode.GetComponent<GameModeScript>().OnEasyPressed();
    }
    public void OnMediumPressed()
    {
        curGameMode.GetComponent<GameModeScript>().OnMediumPressed();
    }
    public void OnHardPressed()
    {
        curGameMode.GetComponent<GameModeScript>().OnHardPressed();
    }

}
