using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySlotManager : MonoBehaviour
{
    public int slotRow, slotColumn;
}
/*
         for (int row = 0; row < gridSize; row++)
        {
            for (int column = 0; column < gridSize; column++)
            {
                // check 2 to the left, self
                if (column - 2 >= 0)
                {
                    if (buttonArray[row, column - 2] != null && buttonArray[row, column - 1] != null)
                    {
                        if ((buttonArray[row, column - 2].randomNumber == buttonArray[row, column - 1].randomNumber) && (buttonArray[row, column - 1].randomNumber == buttonArray[row, column].randomNumber))
                        {
                            // a match of 3
                            if (buttonArray[row, column - 2].gameObject != null)
                                Destroy(buttonArray[row, column - 2].gameObject);
                            if (buttonArray[row, column - 1].gameObject != null)
                                Destroy(buttonArray[row, column - 1].gameObject);
                            if (buttonArray[row, column].gameObject != null)
                                Destroy(buttonArray[row, column].gameObject);
                            //buttonArray[row, column - 2].gameObject.SetActive(false);
                            //buttonArray[row, column - 1].gameObject.SetActive(false);
                            //buttonArray[row, column].gameObject.SetActive(false);
                        }
                    }

                }

                // check one left, self, one to right
                if (column - 1 >= 0 && column + 1 <= 5)
                {
                    if (buttonArray[row, column - 1] != null && buttonArray[row, column + 1] != null)
                    {
                        if ((buttonArray[row, column - 1].randomNumber == buttonArray[row, column + 1].randomNumber) && (buttonArray[row, column + 1].randomNumber == buttonArray[row, column].randomNumber))
                        {
                            // a match of 3
                            if (buttonArray[row, column - 1].gameObject != null)
                                Destroy(buttonArray[row, column - 1].gameObject);
                            if (buttonArray[row, column + 1].gameObject != null)
                                Destroy(buttonArray[row, column + 1].gameObject);
                            if (buttonArray[row, column].gameObject != null)
                                Destroy(buttonArray[row, column].gameObject);

                            //buttonArray[row, column - 1].gameObject.SetActive(false);
                            //buttonArray[row, column + 1].gameObject.SetActive(false);
                            //buttonArray[row, column].gameObject.SetActive(false);

                        }
                    }

                }
                // check 2 to the right, self
                if (column + 2 <= 5)
                {
                    if (buttonArray[row, column + 2] != null && buttonArray[row, column + 1] != null)
                    {
                        if ((buttonArray[row, column + 2].randomNumber == buttonArray[row, column + 1].randomNumber) && (buttonArray[row, column + 1].randomNumber == buttonArray[row, column].randomNumber))
                        {
                            // a match of 3
                            if (buttonArray[row, column + 2].GetComponent<GameButton>() != null)
                                Destroy(buttonArray[row, column + 2].gameObject);
                            if (buttonArray[row, column + 1].GetComponent<GameButton>() != null)
                                Destroy(buttonArray[row, column + 1].gameObject);
                            if (buttonArray[row, column].GetComponent<GameButton>() != null)
                                Destroy(buttonArray[row, column].gameObject);

                            //buttonArray[row, column + 2].gameObject.SetActive(false);
                            //buttonArray[row, column + 1].gameObject.SetActive(false);
                            //buttonArray[row, column].gameObject.SetActive(false);

                        }
                    }

                }

                // check 2 up, self
                if (row + 2 <= 5)
                {
                    if (buttonArray[row + 2, column] != null && buttonArray[row + 1, column] != null)
                    {
                        if ((buttonArray[row + 2, column].randomNumber == buttonArray[row + 1, column].randomNumber) && (buttonArray[row + 1, column].randomNumber == buttonArray[row, column].randomNumber))
                        {
                            // a match of 3

                            if (buttonArray[row + 2, column].GetComponent<GameButton>() != null)
                                Destroy(buttonArray[row + 2, column].gameObject);
                            if (buttonArray[row + 1, column].GetComponent<GameButton>() != null)
                                Destroy(buttonArray[row + 1, column].gameObject);
                            if (buttonArray[row, column].GetComponent<GameButton>() != null)
                                Destroy(buttonArray[row, column].gameObject);

                            //buttonArray[row + 2, column].gameObject.SetActive(false);
                            //buttonArray[row + 1, column].gameObject.SetActive(false);
                            //buttonArray[row, column].gameObject.SetActive(false);
                        }
                    }

                }
                // check one up, self, one down
                if (row + 1 <= 5 && row - 1 >= 0)
                {
                    if (buttonArray[row + 1, column] != null && buttonArray[row - 1, column] != null)
                    {
                        if ((buttonArray[row + 1, column].randomNumber == buttonArray[row - 1, column].randomNumber) && (buttonArray[row - 1, column].randomNumber == buttonArray[row, column].randomNumber))
                        {
                            // a match of 3
                            if (buttonArray[row + 1, column].GetComponent<GameButton>() != null)
                                Destroy(buttonArray[row + 1, column].gameObject);
                            if (buttonArray[row - 1, column].GetComponent<GameButton>() != null)
                                Destroy(buttonArray[row - 1, column].gameObject);
                            if (buttonArray[row, column].GetComponent<GameButton>() != null)
                                Destroy(buttonArray[row, column].gameObject);


                            //buttonArray[row + 1, column].gameObject.SetActive(false);
                            //buttonArray[row - 1, column].gameObject.SetActive(false);
                            //buttonArray[row, column].gameObject.SetActive(false);
                        }
                    }

                }

                // check 2 down, self
                if (row - 2 >= 0)
                {
                    if (buttonArray[row - 2, column] != null && buttonArray[row - 1, column] != null)
                    {
                        if ((buttonArray[row - 2, column].randomNumber == buttonArray[row - 1, column].randomNumber) && (buttonArray[row - 1, column].randomNumber == buttonArray[row, column].randomNumber))
                        {
                            // a match of 3
                            if (buttonArray[row - 2, column].GetComponent<GameButton>() != null)
                                Destroy(buttonArray[row - 2, column].gameObject);
                            if (buttonArray[row - 1, column].GetComponent<GameButton>() != null)
                                Destroy(buttonArray[row - 1, column].gameObject);
                            if (buttonArray[row, column].GetComponent<GameButton>() != null)
                                Destroy(buttonArray[row, column].gameObject);


                            //buttonArray[row - 2, column].gameObject.SetActive(false);
                            //buttonArray[row - 1, column].gameObject.SetActive(false);
                            //buttonArray[row, column].gameObject.SetActive(false);
                        }
                    }


                }
                // 4 and 5 matches

            }

        }
 */