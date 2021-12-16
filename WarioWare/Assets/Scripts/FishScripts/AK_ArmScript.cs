using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_ArmScript : MonoBehaviour
{
    Animation anim;

    public int counter;

    public int maxScore;

    public float fishOffsetX;
    public GameObject fish;

    public int randButton;
    public string[] buttons = new string[] { "A", "B", "X", "Y" };

    private void Start()
    {
        randButton = Random.Range(0, 4);
        anim = GetComponent<Animation>();
    }
    private void Update()
    {
        if (counter < maxScore && Input.GetButtonDown(buttons[randButton]))
        {
            anim.Play();
        }

        for(int i = 0; i < buttons.Length; i++)
        {
            if(i != randButton && Input.GetButtonDown(buttons[i]))
            {
                Debug.Log("YOU LOST !");
            }
        }
        if (counter < maxScore && Input.GetButtonUp(buttons[randButton]))
        {
            OffsetFish(fishOffsetX);
            counter++;
            randButton = Random.Range(0, 4);
        }

        if(counter >= maxScore)
        {
            randButton = 4;
        }

    }

    public void OffsetFish(float offset)
    {
        fish.transform.position = new Vector2(fish.transform.position.x - offset, fish.transform.position.y);
    }
}
