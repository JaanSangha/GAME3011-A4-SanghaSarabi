using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class GameButton : MonoBehaviour
{
    private MinigameManager minigameManager;
    public int row, column;
    public int numOfTypes = 3;
    public int randomNumber;
    public int firstNum, secondNum, thirdNum, fourthNum;
    private Vector3 mouseStart, mouseEnd;
    private float movementAngle;
    public Transform startTrans;
    public bool isFirstNum,isSecondNum,isThirdNum,isFourthNum,isAnyNum = false;
    public EmptySlotManager emptySlotManager;
    //public GameButton topBtn, bottomBtn, leftBtn, rightBtn, topTopBtn, bottomBottomBtn, leftLeftBtn, rightRightBtn;
    public GameObject gameModeScript;
    public TMP_Text buttonText;

    private void Awake()
    {
        gameModeScript = GameObject.FindGameObjectWithTag("GameMode");
        startTrans = this.transform;
        minigameManager = FindObjectOfType<MinigameManager>();
        //buttonText = GetComponent<TMP_Text>();
        //emptySlotManager = FindObjectOfType<EmptySlotManager>();

        //if (gameModeScript.GetComponent<GameModeScript>().currentGameMode ==1)
        //{
        //    numOfTypes = 3;
        //}
        //else if (gameModeScript.GetComponent<GameModeScript>().currentGameMode == 2)
        //{
        //    numOfTypes = 5;
        //}
        //else if (gameModeScript.GetComponent<GameModeScript>().currentGameMode == 3)
        //{
        //    numOfTypes = 7;
        //}
        randomNumber = Random.Range(0, 99);
        firstNum = minigameManager.firstNum;
        secondNum = minigameManager.secondNum;
        thirdNum = minigameManager.thirdNum;
        fourthNum = minigameManager.fourthNum;

        SetButtonNumber();
    }
    public void Reset()
    {
        randomNumber = Random.Range(1, numOfTypes + 1);
        SetButtonNumber();

    }
    public void SetButtonNumber()
    {
        buttonText.text = randomNumber.ToString();

        if (randomNumber == firstNum)
        {
            isFirstNum = true;
            isAnyNum = true;
        }
        else if (randomNumber == secondNum)
        {
            isSecondNum = true;
            isAnyNum = true;
        }
        else if (randomNumber == thirdNum)
        {
            isThirdNum = true;
            isAnyNum = true;
        }
        else if (randomNumber == fourthNum)
        {
            isFourthNum = true;
            isAnyNum = true;
        }
        //switch(randomNumber)
        //{
        //    case 1:
        //        GetComponent<Image>().sprite = sprite1;
        //        break;
        //    case 2:
        //        GetComponent<Image>().sprite = sprite2;
        //        break;
        //    case 3:
        //        GetComponent<Image>().sprite = sprite3;
        //        break;
        //    case 4:
        //        GetComponent<Image>().sprite = sprite4;
        //        break;
        //    case 5:
        //        if(minigameManager.boneCount < 3)
        //        {
        //            GetComponent<Image>().sprite = boneSprite;
        //            minigameManager.boneCount++;
        //        }
        //        else
        //        {
        //            randomNumber = Random.Range(1, numOfTypes + 1);
        //            SetButtonSprite();
        //        }
        //        break;
        //    case 6:
        //        GetComponent<Image>().sprite = sprite5;
        //        break;
        //    case 7:
        //        if(minigameManager.obstacleCount < 3)
        //        {
        //            GetComponent<Image>().sprite = obstacleSprite;
        //            minigameManager.obstacleCount++;
        //        }
        //        else
        //        {
        //            randomNumber = Random.Range(1, numOfTypes + 1);
        //            SetButtonSprite();
        //        }
        //        break;
        //}
    }

}
