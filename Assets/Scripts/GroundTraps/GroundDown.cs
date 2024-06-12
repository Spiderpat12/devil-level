using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDown : MonoBehaviour
{
    private float dis;
    private GameObject Player;
    private Rigidbody rb;
    public float near;
    public float delay;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        dis = Vector3.Distance(transform.position, Player.transform.position);
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        print(dis);

        if (dis < near)
        {
            StartCoroutine(Drop(delay));
        }

    }

    IEnumerator Drop(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.useGravity = true;
        rb.isKinematic = false;

    }

}
