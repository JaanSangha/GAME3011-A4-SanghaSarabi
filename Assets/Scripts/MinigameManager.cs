using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    [SerializeField]
    private GameButton gameButton;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Transform startTransform;
    [SerializeField]
    private int gridSize = 6;
    [SerializeField]
    private List<GameButton> buttonList;

    public int gameMode;
    public int firstNum;
    public int secondNum;
    public int thirdNum;
    public int fourthNum;
    public TMP_Text scoreText;
    public TMP_Text difficultyText;
    public TMP_Text codeText;
    public TMP_Text gameText;
    public TMP_Text timerText;
    public TMP_Text endText;
    public TMP_Text skillText;
    public GameObject endScreen;
    public GameObject minigameScreen;
    public GameObject curGameMode;
    public Image firstNumImage, secondNumImage, thirdNumImage, fourthNumImage,firstTryImage,secondTryImage,thirdTryImage,fourthTryImage;
    public Sprite correctSprite, wrongSprite;

    private int Score=0;
    private int Lives = 4;
    private int playerCurrentSkill;
    private int currentNumber;
    private float timeLeft =60;
    private bool firstNumSet, secondNumSet, thirdNumSet, fourthNumSet = false;
    private AudioSource audioSource;
    void Start()
    {
        firstNum = Random.Range(0, 99);
        secondNum = Random.Range(0, 99);
        thirdNum = Random.Range(0, 99);
        fourthNum = Random.Range(0, 99);
        currentNumber = firstNum;

        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
        buttonList = new List<GameButton>();
        curGameMode = GameObject.FindGameObjectWithTag("GameMode");
        Vector3 tempPos = startTransform.position;
        playerCurrentSkill = curGameMode.GetComponent<GameModeScript>().playerSkill;
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

        if (curGameMode.GetComponent<GameModeScript>().currentGameMode == 1)
        {
            timeLeft = 45;
            Lives = 4;
            difficultyText.text = ("Difficulty: Easy");
        }
        else if (curGameMode.GetComponent<GameModeScript>().currentGameMode == 2)
        {
            timeLeft = 60;
            Lives = 3;
            fourthTryImage.gameObject.SetActive(false);
            difficultyText.text = ("Difficulty: Medium");
        }
        else if (curGameMode.GetComponent<GameModeScript>().currentGameMode == 3)
        {
            timeLeft = 80;
            Lives = 2;
            thirdTryImage.gameObject.SetActive(false);
            fourthTryImage.gameObject.SetActive(false);
            difficultyText.text = ("Difficulty: Hard");
        }
        codeText.text = ("Code: " + firstNum + " " + secondNum + " " + thirdNum + " " + fourthNum);
        skillText.text = ("Player Level: " + playerCurrentSkill);
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
            curGameMode.GetComponent<GameModeScript>().currentGameMode = 1;
            endScreen.SetActive(true);
            minigameScreen.SetActive(false);
            endText.text = ("You Lose!");
        }
        timerText.text = ("Time Remaining: " + timeLeft.ToString("F0"));

        gameMode = curGameMode.GetComponent<GameModeScript>().currentGameMode;

        if (Lives < 1)
        {
            Time.timeScale = 0;
            curGameMode.GetComponent<GameModeScript>().currentGameMode = 1;
            endScreen.SetActive(true);
            minigameScreen.SetActive(false);
            endText.text = ("You Lose! End Score: " + Score);
        }

    }

    private void WinGame()
    {
        if (playerCurrentSkill < 21)
        {
            playerCurrentSkill=playerCurrentSkill + 5;
            curGameMode.GetComponent<GameModeScript>().playerSkill = playerCurrentSkill;
        }
        Time.timeScale = 0;
        curGameMode.GetComponent<GameModeScript>().currentGameMode = 1;
        endScreen.SetActive(true);
        minigameScreen.SetActive(false);
        endText.text = ("You Win! New Skill Level: " + playerCurrentSkill);
  
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

    public void ButtonPressed(int value)
    {
        if (value == currentNumber)
        {
            gameText.text = ("You Got It");

            if (currentNumber == firstNum)
            {
                firstNumImage.sprite = correctSprite;
                currentNumber = secondNum;
            }
            else if (currentNumber == secondNum)
            {
                secondNumImage.sprite = correctSprite;
                currentNumber = thirdNum;
            }
            else if (currentNumber == thirdNum)
            {
                thirdNumImage.sprite = correctSprite;
                currentNumber = fourthNum;
            }
            else if (currentNumber == fourthNum)
            {
                fourthNumImage.sprite = correctSprite;
                WinGame();
            }
        }
        else
        {
            int saveChance = Random.Range(0, 50);
            if (saveChance > playerCurrentSkill)
            {
                if (gameMode == 1)
                {
                    if (Lives == 4)
                    {
                        firstTryImage.sprite = wrongSprite;
                    }
                    else if (Lives == 3)
                    {
                        secondTryImage.sprite = wrongSprite;
                    }
                    else if (Lives == 2)
                    {
                        thirdTryImage.sprite = wrongSprite;
                    }
                    else if (Lives == 1)
                    {
                        fourthTryImage.sprite = wrongSprite;
                    }
                }
                else if (gameMode == 2)
                {
                    if (Lives == 3)
                    {
                        firstTryImage.sprite = wrongSprite;
                    }
                    else if (Lives == 2)
                    {
                        secondTryImage.sprite = wrongSprite;
                    }
                    else if (Lives == 1)
                    {
                        thirdTryImage.sprite = wrongSprite;
                    }
                }
                else if (gameMode == 3)
                {
                    if (Lives == 2)
                    {
                        firstTryImage.sprite = wrongSprite;
                    }
                    else if (Lives == 1)
                    {
                        secondTryImage.sprite = wrongSprite;
                    }
                }
                Lives--;
            }
            else
            {
                gameText.text = ("Saved by Skill Level!");
            }

        }

        firstNumSet = false;
        secondNumSet = false;
        thirdNumSet = false;
        fourthNumSet = false;
        

        for (int list = 0; list < buttonList.Count - 1; list++)
        {
            buttonList[list].Reset();
        }

        CheckForCode();

    }
}
