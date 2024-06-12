using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesSpawner : MonoBehaviour
{
    public GameObject Spikes;
    public float SpawnTimerMaxValue;
    public float SpawnTimerMinValue;
    public MoveDir moveDir;
    public float MoveSpeed;

    private float spawnTimer;
    private SpikesMove2 spikesMove2;
    public enum MoveDir
    {
        Right,
        Left
    }

    private void Start()
    {
        spawnTimer = Random.Range(SpawnTimerMinValue, SpawnTimerMaxValue);
        spikesMove2 = Spikes.GetComponent<SpikesMove2>();
    }

    private void Update()
    {
        print(spawnTimer);
        spikesMove2.MoveSpeed = MoveSpeed;

        switch (moveDir)
        {
            case MoveDir.Right:
                spikesMove2.moveDir = SpikesMove2.MoveDir.Right;
                break;
            case MoveDir.Left:
                spikesMove2.moveDir = SpikesMove2.MoveDir.Left;
                break;
        }



        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        if (spawnTimer <= 0)
        {
            spawnTimer = Random.Range(SpawnTimerMinValue, SpawnTimerMaxValue);
            Instantiate(Spikes, transform.position, Spikes.transform.rotation);
        }
    }
}
