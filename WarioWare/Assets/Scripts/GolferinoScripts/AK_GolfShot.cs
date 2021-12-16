using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_GolfShot : MonoBehaviour
{
    Rigidbody rb;

    public float shotForce;

    public Transform aim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce((aim.position - transform.position).normalized * shotForce,ForceMode.Impulse);
        }
    }
}
