using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [Header ("GetCom")]
    public Animator anim;

    [Space]

    [Header("Proprties")]
    public float TrampolineJumpHeight;



    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            anim.SetBool("Run", true);

            Rigidbody playerRb = other.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                playerRb.velocity = new Vector3(playerRb.velocity.x, TrampolineJumpHeight, playerRb.velocity.z);
            }

        }
    }

    public void AnimationRunFinished()
    {
        anim.SetBool("Run", false);
    }


}
