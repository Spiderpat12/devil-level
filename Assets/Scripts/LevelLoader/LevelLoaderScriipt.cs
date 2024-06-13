using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderScriipt : MonoBehaviour
{
    public static LevelLoaderScriipt levelLoaderScriipt;
    public float timerTrans;


    private Animator anim;

    private void Awake()
    {
        levelLoaderScriipt = this;
    }

    public void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (timerTrans > 0)
        {
            timerTrans -= Time.deltaTime;

            if (timerTrans <= 0)
            {
                anim.SetTrigger("End");
            }
        }
    }


    public void RunAnimation(float Timer)
    {
        timerTrans = Timer;
    }


}
