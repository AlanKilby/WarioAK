using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_ButtonPicker : MonoBehaviour
{
    public Sprite[] buttonSprites;

    public AK_ArmScript armScript;

    SpriteRenderer spriteRend;

    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRend.sprite = buttonSprites[armScript.randButton];
    }
}
