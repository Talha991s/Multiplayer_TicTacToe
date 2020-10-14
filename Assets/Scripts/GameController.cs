﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    private string playerSide;

    void Awake()
    {
        SetGameControllerReferenceButtons();
        playerSide = "X";
    }

    void SetGameControllerReferenceButtons()
    {
        for( int i= 0; i<buttonList.Length;i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerRefference(this);
        }
    }
    
    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        // all horizotal possibilities
        if(buttonList[0].text == playerSide && buttonList[1].text ==playerSide && buttonList[2].text == playerSide)
        {
            GameOver();
        }

        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver();
        }
        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }
        // all Vertical posibilities
        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }
        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver();
        }
        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }
        //Diagonal possibilities
        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }
        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }

        ChangeSides();

    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void GameOver()
    {
        for(int i = 0; i<buttonList.Length;i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
    }

  
}
