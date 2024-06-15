using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRun : MonoBehaviour
{
    public Vector3 PlayerScale;
    public float speed = 0.5f;

    private GameObject Player;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void AnimationFinished()
    {
        print("ButtoRun");
        Player.transform.localScale = Vector3.MoveTowards(Player.transform.localScale, PlayerScale, speed);
    }


}
