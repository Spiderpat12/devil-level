using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderScriipt : MonoBehaviour
{
    public static LevelLoaderScriipt levelLoaderScriipt;
    public float timerTrans;
    public GameObject trans;
    public Animator anim;



    private void Awake()
    {
        levelLoaderScriipt = this;
        this.trans.SetActive(!this.trans.activeSelf);
    }

    private void Update()
    {
        print(timerTrans);


        if (timerTrans > 0)
        {
            timerTrans -= Time.deltaTime;

            if (timerTrans <= 0)
            {
                print("sheesh");
                anim.SetBool("Run", true);
            }
        }
    }


    public void RunAnimation(float Timer)
    {
        timerTrans = Timer;
    }


}
