using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULA2_ArmScript : MonoBehaviour
{
    Animation anim;

    public int counter;

    public int maxScore;

    public int tick;

    public bool gameResult;

    public float fishOffsetX;
    public GameObject fish;
    public GameObject defeatImage;

    public int randButton;

    [HideInInspector]
    public bool gameOver;
    //public string[] buttons = new string[] { "A", "B", "X", "Y" };

    public ControllerKey[] keys = new ControllerKey[] {ControllerKey.A, ControllerKey.B, ControllerKey.X, ControllerKey.Y};

    public bool canPressButton;

    [SerializeField] AudioClip chop;

    private void Start()
    {
        randButton = Random.Range(0, 4);
        anim = GetComponent<Animation>();
        canPressButton = true;
        tick = 8;
        gameResult = false;
        gameOver = false;
    }
    private void Update()
    {
        if (counter < maxScore && InputManager.GetKeyDown(keys[randButton]) && canPressButton)
        {
            anim.Play();
        }


        for (int i = 0; i < keys.Length; i++)
        {
            if (i != randButton && InputManager.GetKeyDown(keys[i]) && canPressButton)
            {
                defeatImage.SetActive(true);
                canPressButton = false;
                gameOver = true;
                tick = GameController.currentTick+3;
                GameController.StopTimer();
            }
        }

        if (counter < maxScore && InputManager.GetKeyUp(keys[randButton]) && canPressButton)
        {
            OffsetFish(fishOffsetX);
            counter++;
            randButton = Random.Range(0, 4);
            AudioManager.PlaySound(chop);
        }

        if (counter >= maxScore && canPressButton)
        {
            randButton = 4;
            canPressButton = false;
            tick = GameController.currentTick + 3;
            gameResult = true;
            gameOver = true;
        }

        
    }

    public void OffsetFish(float offset)
    {
        fish.transform.position = new Vector2(fish.transform.position.x - offset, fish.transform.position.y);
    }
}
