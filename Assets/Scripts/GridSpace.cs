using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    public GameController gameController;
    public int index;
    public bool goodForClick = true;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        button.onClick.AddListener(SetSpace);
    }

    public void SetSpace()
    {
        goodForClick = false;
        buttonText.text = Convert.ToString(gameController.GetCurentNumber());
        button.interactable = false;
        gameController.currentButtonIndex = index;
        gameController.EndTurn();
    }

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }
}
