using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    private int currentNumber;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public int currentButtonIndex;
    int x;
    int y;

    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        currentNumber = 1;
        gameOverPanel.SetActive(false);
        for (int i = 0; i < buttonList.Length; i++)
        {
            var gridSpace = buttonList[i].transform.parent.GetComponent<GridSpace>();
            gridSpace.index = i;
            gridSpace.GetComponent<Animator>().enabled = false;
        }
    }
    
    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public int GetCurentNumber()
    {
        return currentNumber;
    }

    void GetNextNumber()
    {
        currentNumber++;
    }

    public void EndTurn()
    {
        if (currentNumber >= buttonList.Length)
        {
            GameWin();
        }
        else
        {
            GetNextNumber();
            AvailableMoves();
        }
    }

    void SetBoardInteractable (bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            var gridSpace = buttonList[i].GetComponentInParent<Button>();            
            gridSpace.interactable = toggle;
            gridSpace.GetComponent<Animator>().enabled = true;
        }
    }

    void AvailableMoves()
    {
        CoordConverter();
        SetBoardInteractable(false);

        int movesCounter = 0;

        if ((x-2) >= 0 && (x-2) <= 9 && (y-1) >= 0 && (y-1) <= 9)
        {
            var button = buttonList[Convert.ToInt32(Convert.ToString($"{x - 2}" + $"{y - 1}"))];
            if (button.GetComponentInParent<GridSpace>().goodForClick)
            {
                button.GetComponentInParent<Button>().interactable = true;
                movesCounter += 1;
            }
        }
        if ((x - 2) >= 0 && (x - 2) <= 9 && (y + 1) >= 0 && (y + 1) <= 9)
        {
            var button = buttonList[Convert.ToInt32(Convert.ToString($"{x - 2}" + $"{y + 1}"))];
            if (button.GetComponentInParent<GridSpace>().goodForClick)
            {
                button.GetComponentInParent<Button>().interactable = true;
                movesCounter += 1;
            }
        }
        if ((x - 1) >= 0 && (x - 1) <= 9 && (y - 2) >= 0 && (y - 2) <= 9)
        {
            var button = buttonList[Convert.ToInt32(Convert.ToString($"{x - 1}" + $"{y - 2}"))];
            if (button.GetComponentInParent<GridSpace>().goodForClick == true)
            {
                button.GetComponentInParent<Button>().interactable = true;
                movesCounter += 1;
            }
        }
        if ((x - 1) >= 0 && (x - 1) <= 9 && (y + 2) >= 0 && (y + 2) <= 9)
        {
            var button = buttonList[Convert.ToInt32(Convert.ToString($"{x - 1}" + $"{y + 2}"))];
            if (button.GetComponentInParent<GridSpace>().goodForClick == true)
            {
                button.GetComponentInParent<Button>().interactable = true;
                movesCounter += 1;
            }
        }
        if ((x + 1) >= 0 && (x + 1) <= 9 && (y - 2) >= 0 && (y - 2) <= 9)
        {
            var button = buttonList[Convert.ToInt32(Convert.ToString($"{x + 1}" + $"{y - 2}"))];
            if (button.GetComponentInParent<GridSpace>().goodForClick == true)
            {
                button.GetComponentInParent<Button>().interactable = true;
                movesCounter += 1;
            }
        }
        if ((x + 1) >= 0 && (x + 1) <= 9 && (y + 2) >= 0 && (y + 2) <= 9)
        {
            var button = buttonList[Convert.ToInt32(Convert.ToString($"{x + 1}" + $"{y + 2}"))];
            if (button.GetComponentInParent<GridSpace>().goodForClick == true)
            {
                button.GetComponentInParent<Button>().interactable = true;
                movesCounter += 1;
            }
        }
        if ((x + 2) >= 0 && (x + 2) <= 9 && (y - 1) >= 0 && (y - 1) <= 9)
        {
            var button = buttonList[Convert.ToInt32(Convert.ToString($"{x + 2}" + $"{y - 1}"))];
            if (button.GetComponentInParent<GridSpace>().goodForClick == true)
            {
                button.GetComponentInParent<Button>().interactable = true;
                movesCounter += 1;
            }
        }
        if ((x + 2) >= 0 && (x + 2) <= 9 && (y + 1) >= 0 && (y + 1) <= 9)
        {
            var button = buttonList[Convert.ToInt32(Convert.ToString($"{x + 2}" + $"{y + 1}"))];
            if (button.GetComponentInParent<GridSpace>().goodForClick == true)
            {
                button.GetComponentInParent<Button>().interactable = true;
                movesCounter += 1;
            }
        }
        if (movesCounter == 0)
        {
            GameOver();
        }
    }

    void CoordConverter()
    {
        x = currentButtonIndex / 10;
        y = currentButtonIndex % 10;
    }

    void SetGameOverText (string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    void GameWin()
    {
        SetBoardInteractable(false);
        SetGameOverText("You WIN!");
    }

    void GameOver()
    {
        SetBoardInteractable(false);
        SetGameOverText("Game Over!");
    }

    public void RestartGame()
    {
        currentNumber = 1;
        gameOverPanel.SetActive(false);

        SetBoardInteractable(true);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
            var gridSpace = buttonList[i].GetComponentInParent<GridSpace>();
            gridSpace.goodForClick = true;
            gridSpace.GetComponent<Animator>().enabled = false;
            var colors = gridSpace.GetComponent<Button>().colors;
            colors.normalColor = Color.white;
            gridSpace.GetComponent<Button>().colors = colors;
        }
    }
}
