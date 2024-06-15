using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToutchCoinScript : MonoBehaviour
{
    public bool NormalCoin = true;
    public bool CoinTrap = false;
    public GameObject trapGameObject;


    private Animator anim;
    MovementPlayerScript movementPlayerScript;

    public void Start()
    {
        anim = trapGameObject.GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Player" && NormalCoin == true)
        {
            movementPlayerScript = other.gameObject.GetComponent<MovementPlayerScript>();
            if (CoinTrap == false)
            {
                movementPlayerScript.RunParticles(movementPlayerScript.PlayerParticles[1], other.transform.position);
                Destroy(this.gameObject);
            }
            else
            {
                movementPlayerScript.RunParticles(movementPlayerScript.PlayerParticles[1], other.transform.position);
                anim.SetBool("Run", true);
                Destroy(this.gameObject);
            }

        }
    }


}
