using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesMove2 : MonoBehaviour
{
    public float MoveSpeed;
    public MoveDir moveDir;
    public float timerForDistroy;
    public bool runWhenPlayerNear = false;
    public float Near;

    private float dis;
    private GameObject Player;

    public enum MoveDir
    {
        Right,
        Left
    }

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {

        if (Player != null)
        {
            dis = Vector3.Distance(transform.position, Player.transform.position);
        }

        if (timerForDistroy > 0)
        {
            timerForDistroy -= Time.deltaTime;
        }
        if (timerForDistroy < 0)
        {
            Destroy(this.gameObject);
        }


        switch (moveDir)
        {
            case MoveDir.Right:
                if (runWhenPlayerNear == true)
                {
                    if (dis < Near)
                    {
                        transform.position += Vector3.forward * MoveSpeed * Time.deltaTime;
                    }
                }
                else
                {
                    transform.position += Vector3.forward * MoveSpeed * Time.deltaTime;
                }

                break;

            case MoveDir.Left:
                if (runWhenPlayerNear == true)
                {
                    if (dis < Near)
                    {
                        transform.position += Vector3.back * MoveSpeed * Time.deltaTime;
                    }
                }
                else
                {
                    transform.position += Vector3.back * MoveSpeed * Time.deltaTime;
                }
                break;
        }



    }

}
