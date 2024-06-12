using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScriptAnimation : MonoBehaviour
{

    private float AnimationSpeed;
    private float DownAndUpAnimationSpeed;
    private bool MovingToPoint = false;
    private Vector3 mainPos;


    public float maxSpeed;
    public float minSpeed;
    public GameObject position;
    public float UpAndDownMax;
    public float UpAndDownMin;


    private void Start()
    {
        AnimationSpeed = Random.Range(minSpeed, maxSpeed);
        DownAndUpAnimationSpeed = Random.Range(UpAndDownMin, UpAndDownMax);
        mainPos = transform.position;
    }


    private void Update()
    {
        transform.Rotate(0, -AnimationSpeed * Time.deltaTime, 0);
        print(DownAndUpAnimationSpeed);

        if (MovingToPoint == false)
        {
            transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, position.transform.position.y, DownAndUpAnimationSpeed), transform.position.z);
            if (Mathf.Approximately(transform.position.y, position.transform.position.y))
            {
                MovingToPoint = true;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, mainPos.y, DownAndUpAnimationSpeed), transform.position.z);
            if (Mathf.Approximately(transform.position.y, mainPos.y))
            {
                MovingToPoint = false;
            }
        }


    }



}
