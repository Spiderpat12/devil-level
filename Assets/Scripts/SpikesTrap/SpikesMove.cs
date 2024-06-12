using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesMove : MonoBehaviour
{
    [Header("Values")]
    public MoveDir dirMove;
    public SpaceOfDirPos spaceOfDirPos;
    public float NearValue;
    public float MoveSpeed;
    public float delay;
    public float playerCheckDis;
    [Space]
    [Header("GetGameObject")]
    public GameObject DirPosition;
    public GameObject SpikesGameObject;

    private float dis;
    private GameObject Player;
    private bool PlayerTriggered = false;
    private bool PlayerCheck;
    private bool canCheck = true;

    public enum MoveDir
    {
        Up,
        Right,
        Left
    }

    public enum SpaceOfDirPos
    {
        One,
        Two,
        theree
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        dis = Vector3.Distance(transform.position, Player.transform.position);

        PlayerCheck = CheckPlayer();

        print(dis);

        if (dis < NearValue || PlayerCheck && canCheck == true)
        {
            PlayerTriggered = true;
        }

        MoveToPossition();
    }

    private void Start()
    {
        float[] spaceValues = { 2.5f, 5f, 7.5f };
        Vector3 dirPositions = DirPosition.transform.position;

        switch (dirMove)
        {
            case MoveDir.Up:
                dirPositions.y += spaceValues[(int)spaceOfDirPos];
                break;
            case MoveDir.Left:
                dirPositions.z -= spaceValues[(int)spaceOfDirPos];
                break;
            case MoveDir.Right:
                dirPositions.z += spaceValues[(int)spaceOfDirPos];
                break;
        }

        DirPosition.transform.position = dirPositions;
    }

    void MoveToPossition()
    {
        if (PlayerTriggered)
        {
            StartCoroutine(SpikesMoveToDir(delay));
        }
    }

    IEnumerator SpikesMoveToDir(float Delay)
    {
        canCheck = false;
        yield return new WaitForSeconds(Delay);
        SpikesGameObject.transform.position = Vector3.MoveTowards(SpikesGameObject.transform.position, DirPosition.transform.position, MoveSpeed);
    }

    bool CheckPlayer()
    {
        RaycastHit hit;
        bool isPlayer = Physics.Raycast(transform.position, Vector3.up, out hit, playerCheckDis) && hit.collider.CompareTag("Player");
        Color colorRay = isPlayer ? Color.green : Color.red;
        Debug.DrawRay(transform.position, Vector3.up * playerCheckDis, colorRay);
        return isPlayer;
    }

}
