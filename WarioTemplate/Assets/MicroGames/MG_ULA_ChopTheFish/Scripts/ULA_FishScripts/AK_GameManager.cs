using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_GameManager : MonoBehaviour, ITickable
{
    public GameObject[] fishList;

    public AK_ArmScript armScript;

    public GameControllerSO gameController;

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
        if(armScript.counter == armScript.maxScore)
        {
            GameController.FinishGame(true);
        }
        else if(GameController.currentTick == 5)
        {
            GameController.FinishGame(false);
        }
    }
}
