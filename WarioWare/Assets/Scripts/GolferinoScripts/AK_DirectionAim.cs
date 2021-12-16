using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_DirectionAim : MonoBehaviour
{
    public float rotateSpeed;

    public float offset;

    private void Start()
    {
    }
    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, Mathf.PingPong(Time.time * rotateSpeed, offset) - offset / 2, 0);
    }
}
