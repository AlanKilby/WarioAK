using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_FishOffset : MonoBehaviour
{
    public float condition;

    public float xOffset;

    public AK_ArmScript armScript;

    private void Start()
    {
    }

    private void Update()
    {
        if (armScript.counter == condition)
        {
            transform.position = new Vector2(transform.position.x - xOffset, transform.position.y);
        }
    }
}
