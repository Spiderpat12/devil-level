using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeJump : MonoBehaviour
{

    public bool SpikesNormal = true;
    public float JumpForce;


    private Rigidbody rb;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Jump") && SpikesNormal == false)
        {
            rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }

    }


}
