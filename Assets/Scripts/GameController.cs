using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System;

[System.Serializable]
public class Player
{
  
    public Image panel;
    public Text text;
    public Button button;

}
[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}


public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    private string playerSide;
    public GameObject GameOverPanel;
    public Text gameOverText;
    private int moveCount;
    public GameObject restartButton;
    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;
    public GameObject startInfo;
    public GameObject Mmenu;


    void Awake()
    {
        SetGameControllerReferenceButtons();
        //playerSide = "X";
        GameOverPanel.SetActive(false);
        moveCount = 0;
        restartButton.SetActive(false);
        Mmenu.SetActive(false);
        //SetPlayerColor(playerX, playerO);
    }


    void SetGameControllerReferenceButtons()
    {
        for( int i= 0; i<buttonList.Length;i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerRefference(this);
        }
    }

    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "X")
        {
            SetPlayerColor(playerX, playerO);
        }
        else
        {
            SetPlayerColor(playerO, playerX);
        }

        StartGame();
    }

    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButton(false);
        startInfo.SetActive(false);
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;
        // all horizotal possibilities
        if(buttonList[0].text == playerSide && buttonList[1].text ==playerSide && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        // all Vertical posibilities
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        //Diagonal possibilities
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if(moveCount >= 9)
        {
            //GameOverPanel.SetActive(true);
            GameOver("draw");
        }
        else { ChangeSides(); }

    }

    //switching between player turns
    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";

        if(playerSide == "X")
        {
            SetPlayerColor(playerX, playerO);

        }
        else
        {
            SetPlayerColor(playerO, playerX);
        }
    }

    void SetPlayerColor(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }


    void GameOver(string winningPlayer)
    { 
        SetBoardInteractable(false);
        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a DRAW");
            SetPlayerColorInactive();
        }
        else
        {
            SetGameOverText(winningPlayer + "  WIN!");
        }

        restartButton.SetActive(true);
        Mmenu.SetActive(true);

    }

    void SetGameOverText(string value)
    {
        GameOverPanel.SetActive(true);
        gameOverText.text =  value;
    }
    public void mMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    public void RestartGame()
    {
        //playerSide = "X";
        moveCount = 0;
        GameOverPanel.SetActive(false);
        SetPlayerButton(true);
        restartButton.SetActive(false);
        Mmenu.SetActive(false);
        SetPlayerColorInactive();
        startInfo.SetActive(true);
       // SetPlayerColor(playerX, playerO);


        for (int i = 0; i < buttonList.Length; i++)
        {
            //buttonList[i].GetComponentInParent<Button>().interactable = true;
            buttonList[i].text = "";
        }

    }
    void SetBoardInteractable (bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }

    }

    void SetPlayerButton(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    void SetPlayerColorInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;
    }
}
