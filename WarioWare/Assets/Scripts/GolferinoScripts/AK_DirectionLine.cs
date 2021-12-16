using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_DirectionLine : MonoBehaviour
{
    LineRenderer lineR;

    public Transform origin;
    public Transform aim;

    private void Start()
    {
        lineR = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineR.SetPosition(0, origin.position);
        lineR.SetPosition(1, aim.position);
    }
}
