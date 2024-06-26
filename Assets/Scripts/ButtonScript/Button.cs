using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public Animator anim;
    public bool Run = false;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && Run == false)
        {
            Run = true;
            anim.SetBool("RunButton", true);
        }
    }
}
