using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_GameManager : MonoBehaviour, ITickable
{
    public GameObject[] fishList;

    public AK_ArmScript armScript;

    public GameControllerSO gameController;

    public GameObject victoryImage;
    public GameObject defeatImage;

    private void Awake()
    {
        fishList[gameController.currentDifficulty-1].SetActive(true);
        armScript.fishOffsetX = fishList[gameController.currentDifficulty-1].GetComponent<AK_FishInfo>().fishOffset;
        armScript.maxScore = fishList[gameController.currentDifficulty-1].GetComponent<AK_FishInfo>().fishMaxScore;
        armScript.fish = fishList[gameController.currentDifficulty-1];
    }

    private void Start()
    {
        GameManager.Register();
        GameController.Init(this);
    }

    public void OnTick()
    {
        if(GameController.currentTick == 8 && armScript.counter == armScript.maxScore)
        {
            GameController.FinishGame(true);
            victoryImage.SetActive(true);
        }
        else if(GameController.currentTick == 8 && armScript.counter <= armScript.maxScore)
        {
            GameController.FinishGame(false);
            defeatImage.SetActive(true);
        }


        if (armScript.counter >= armScript.maxScore)
        {
            victoryImage.SetActive(true);
            armScript.canPressButton = false;
        }
        else if(GameController.currentTick == 5 && armScript.counter >= armScript.maxScore)
        {
            victoryImage.SetActive(true);
            armScript.canPressButton = false;
        }
        else if (GameController.currentTick == 5 && armScript.counter <= armScript.maxScore)
        {
            defeatImage.SetActive(true);
            armScript.canPressButton = false;
        }

    }
}
