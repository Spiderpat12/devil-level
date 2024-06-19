using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAway : MonoBehaviour
{
    public bool canWalk = true;
    public float speed;
    private float movez;
    private Vector3 movement;
    private Rigidbody rb;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        movez = Input.GetAxis("Horizontal");

        movement = new Vector3(0, 0, movez);

        if (canWalk)
        {
            Move(movement);
        }
    }

    void Move(Vector3 direction)
    {
        Vector3 velocity = rb.velocity;
        rb.velocity = new Vector3(velocity.x, velocity.y, direction.z * speed);
    }

}
