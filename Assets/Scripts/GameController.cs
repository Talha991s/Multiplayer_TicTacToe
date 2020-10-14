using System.Collections;
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
        if(buttonList[0].text == playerSide && buttonList[1].text ==playerSide && buttonList[2].text == playerSide)
        {

            GameOver();
        }
    }

    void GameOver()
    {
        for(int i = 0; i<buttonList.Length;i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
    }
}
