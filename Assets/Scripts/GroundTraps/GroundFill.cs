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
    private bool PlayerTriggered = false;
    private float playerCheckDis = 40f;

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
        if (Player != null)
        {
            dis = Vector3.Distance(transform.position, Player.transform.position);
        }

        PlayerTriggered = CheckPlayer();


        if (dis < near || PlayerTriggered)
        {
            StartCoroutine(Delay(delay));
        }

    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool("Run", true);
    }

    public void AnimationFinished()
    {
        Destroy(this.gameObject);
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
