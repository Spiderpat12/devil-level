using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTest : MonoBehaviour
{
    public enum MoveDir
    {
        One,
        Tow,
        Three,
        Four,
        Five

    }

    public MoveDir TybeMove;

    public GameObject[] Positions;

    private void Start()
    {
        switch (TybeMove)
        {
            case MoveDir.One:
                Positions[0].transform.position = new Vector3(Positions[0].transform.position.x, Positions[0].transform.position.y, 5);
                break;
        }
    }


}
