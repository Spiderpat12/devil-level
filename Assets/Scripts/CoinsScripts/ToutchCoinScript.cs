using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToutchCoinScript : MonoBehaviour
{
    public bool NormalCoin = true;
    public bool CoinTrap = false;
    public GameObject trapGameObject;


    private Animator anim;

    public void Start()
    {
        anim = trapGameObject.GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Player" && NormalCoin == true)
        {
            if (CoinTrap == false)
            {
                Destroy(this.gameObject);
            }
            else
            {
                anim.SetBool("Run", true);
                Destroy(this.gameObject);
            }

        }
    }


}
