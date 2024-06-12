using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFill : MonoBehaviour
{
    public float near;
    public float delay;
    private float dis;
    private Animator anim;
    private GameObject Player;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        dis = Vector3.Distance(transform.position, Player.transform.position);
        print(dis);

        if (dis < near)
        {
            StartCoroutine(Delay(delay));
        }

    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool("Run", true);
    }

}
