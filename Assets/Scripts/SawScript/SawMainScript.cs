using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMainScript : MonoBehaviour
{
    [Header ("SawProprties")]
    public MoveDir TybeMove;
    public float speed;
    [Space]
    [Header("GetObjects")]
    public GameObject[] Positions;
    public GameObject MoveingGameObject;
    [Header("PrivateVar")]
    private bool MovingTowrdsPoint;
    public enum MoveDir
    {
        TybeOne,
        TybeTwo,
        TybeThree,
        TybeFour,
        TybeFive,
        TybeFree

    }
    private void Start()
    {

        switch (TybeMove)
        {
            case MoveDir.TybeOne:
                Positions[0].transform.position = new Vector3(Positions[0].transform.position.x, Positions[0].transform.position.y, Positions[0].transform.position.z + 5f/2f);
                Positions[1].transform.position = new Vector3(Positions[1].transform.position.x, Positions[1].transform.position.y, Positions[1].transform.position.z + -5f / 2f);
                break;
            case MoveDir.TybeTwo:
                Positions[0].transform.position = new Vector3(Positions[0].transform.position.x, Positions[0].transform.position.y, Positions[0].transform.position.z + 10f / 2f);
                Positions[1].transform.position = new Vector3(Positions[1].transform.position.x, Positions[1].transform.position.y, Positions[1].transform.position.z + -10f / 2f);
                break;
            case MoveDir.TybeThree:
                Positions[0].transform.position = new Vector3(Positions[0].transform.position.x, Positions[0].transform.position.y, Positions[0].transform.position.z + 15f / 2f);
                Positions[1].transform.position = new Vector3(Positions[1].transform.position.x, Positions[1].transform.position.y, Positions[1].transform.position.z + -15f / 2f);
                break;
            case MoveDir.TybeFour:
                Positions[0].transform.position = new Vector3(Positions[0].transform.position.x, Positions[0].transform.position.y, Positions[0].transform.position.z + 20f / 2f);
                Positions[1].transform.position = new Vector3(Positions[1].transform.position.x, Positions[1].transform.position.y, Positions[1].transform.position.z + -20f) / 2f;
                break;
            case MoveDir.TybeFive:
                Positions[0].transform.position = new Vector3(Positions[0].transform.position.x, Positions[0].transform.position.y, Positions[0].transform.position.z + 25f / 2f);
                Positions[1].transform.position = new Vector3(Positions[1].transform.position.x, Positions[1].transform.position.y, Positions[1].transform.position.z + -25f / 2f);
                break;
        }

    }

    private void Update()
    {
        if (TybeMove != MoveDir.TybeFree)
        {
            if (MovingTowrdsPoint)
            {
                MoveingGameObject.transform.position = new Vector3(MoveingGameObject.transform.position.x, MoveingGameObject.transform.position.y, Mathf.MoveTowards(MoveingGameObject.transform.position.z, Positions[0].transform.position.z, speed * Time.deltaTime));
                if (Mathf.Approximately(MoveingGameObject.transform.position.z, Positions[0].transform.position.z))
                {
                    MovingTowrdsPoint = false;
                }
            }
            else
            {
                MoveingGameObject.transform.position = new Vector3(MoveingGameObject.transform.position.x, MoveingGameObject.transform.position.y, Mathf.MoveTowards(MoveingGameObject.transform.position.z, Positions[1].transform.position.z, speed * Time.deltaTime));
                if (Mathf.Approximately(MoveingGameObject.transform.position.z, Positions[1].transform.position.z))
                {
                    MovingTowrdsPoint = true;
                }
            }
        }
        else if (TybeMove == MoveDir.TybeFree)
        {
            if (MovingTowrdsPoint)
            {
                MoveingGameObject.transform.position = Vector3.MoveTowards(MoveingGameObject.transform.position, Positions[0].transform.position, speed * Time.deltaTime);
                if (Mathf.Approximately(MoveingGameObject.transform.position.z, Positions[0].transform.position.z))
                {
                    MovingTowrdsPoint = false;
                }
            }
            else
            {
                MoveingGameObject.transform.position = Vector3.MoveTowards(MoveingGameObject.transform.position, Positions[1].transform.position, speed * Time.deltaTime);
                if (Mathf.Approximately(MoveingGameObject.transform.position.z, Positions[1].transform.position.z))
                {
                    MovingTowrdsPoint = true;
                }
            }
        }


    }



}
