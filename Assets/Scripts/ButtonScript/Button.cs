using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public Animator anim;
    public bool Run = false;


    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Player") && Run == false)
        {
            Run = true;
            print("AhmedMohsen");
            anim.SetBool("RunButton", true);
        }
    }

}
