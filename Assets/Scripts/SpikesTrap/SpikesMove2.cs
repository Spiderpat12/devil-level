using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesMove2 : MonoBehaviour
{
    public float MoveSpeed;
    public MoveDir moveDir;
    public float timerForDistroy;

    public enum MoveDir
    {
        Right,
        Left
    }

    public void Update()
    {

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
                transform.position += Vector3.forward * MoveSpeed * Time.deltaTime;
                break;

            case MoveDir.Left:
                transform.position += Vector3.back * MoveSpeed * Time.deltaTime;
                break;
        }



    }

}
