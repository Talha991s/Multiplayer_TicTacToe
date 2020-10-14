using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;

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
    public PlayerColor inactivePlayerColor;
    public PlayerColor activePlayerColor;

    void Awake()
    {
        SetGameControllerReferenceButtons();
        playerSide = "X";
        GameOverPanel.SetActive(false);
        moveCount = 0;
        restartButton.SetActive(false);
        SetPlayerColor(playerX, playerO);
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
        }
        else
        {
            SetGameOverText(winningPlayer + "  WIN!");
        }
        restartButton.SetActive(true);

    }

    void SetGameOverText(string value)
    {
        GameOverPanel.SetActive(true);
        gameOverText.text =  value;
    }

    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        GameOverPanel.SetActive(false);

        restartButton.SetActive(false);
        SetPlayerColor(playerX, playerO);
        SetBoardInteractable(true);

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

}
