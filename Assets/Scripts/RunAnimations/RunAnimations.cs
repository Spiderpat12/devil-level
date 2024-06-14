using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimations : MonoBehaviour
{
    public GameObject GameObjectRunAnimation;
    public float checkPlayerDis;
    private bool PlayerEnter;
    private Animator anim;


    private void Start()
    {
        anim = GameObjectRunAnimation.GetComponent<Animator>();
    }



    public void Update()
    {
        PlayerEnter = playerEnter();

        if (PlayerEnter)
        {
            anim.SetBool("Run", true);
        }

    }




    bool playerEnter()
    {
        RaycastHit hit;
        bool EnterPlayer = Physics.Raycast(transform.position, Vector3.up, out hit, checkPlayerDis) && hit.collider.gameObject.CompareTag("Player");
        Color colorRay = EnterPlayer ? Color.green : Color.red;
        Debug.DrawRay(transform.position, Vector3.up * checkPlayerDis, colorRay);
        return EnterPlayer;
    }



}
