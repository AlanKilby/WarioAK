using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULA2_GameManager : MonoBehaviour, ITickable
{
    public GameObject[] fishList;

    public ULA2_ArmScript armScript;

    public GameControllerSO gameController;

    public GameObject victoryImage;
    public GameObject defeatImage;

    private void Awake()
    {
        fishList[gameController.currentDifficulty-1].SetActive(true);
        armScript.fishOffsetX = fishList[gameController.currentDifficulty-1].GetComponent<ULA2_FishInfo>().fishOffset;
        armScript.maxScore = fishList[gameController.currentDifficulty-1].GetComponent<ULA2_FishInfo>().fishMaxScore;
        armScript.fish = fishList[gameController.currentDifficulty-1];
    }

    private void Start()
    {
        GameManager.Register();
        GameController.Init(this);
    }

    public void OnTick()
    {
        if(GameController.currentTick == 8 && armScript.counter >= armScript.maxScore)
        {
            GameController.FinishGame(true);
        }
        else if(GameController.currentTick == 8 && armScript.counter <= armScript.maxScore)
        {
            GameController.FinishGame(false);
        }

        if (armScript.counter >= armScript.maxScore)
        {
            victoryImage.SetActive(true);
            armScript.gameOver = true;
        }
        else if(GameController.currentTick == 5 && armScript.counter >= armScript.maxScore)
        {
            victoryImage.SetActive(true);
            armScript.gameOver = true;
        }
        else if (GameController.currentTick == 5 && armScript.counter <= armScript.maxScore)
        {
            defeatImage.SetActive(true);
            armScript.gameOver = true;
        }

        if(GameController.currentTick == 5)
        {
            armScript.canPressButton = false;
        }

        if(armScript.gameOver == true)
        {
            GameController.StopTimer();

        }

        if (GameController.currentTick == armScript.tick)
        {
            GameController.FinishGame(armScript.gameResult);
        }

    }
}
