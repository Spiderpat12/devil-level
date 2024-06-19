using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRun : MonoBehaviour
{
    public Tybe ButtonTybes;
    public Vector3 PlayerScale;
    public float speed = 0.5f;
    public GameObject ObjectRunAnimation;
    public GameObject[] showThisObject;

    private GameObject Player;
    private bool AnimationFinish = false;
    private Animator anim;
    private bool canChange = true;
    private bool showObjectToggled = false;
    public enum Tybe
    {
        Normal,
        RunAnimation,
        ShowObjects
    }

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (ObjectRunAnimation != null)
        {
            anim = ObjectRunAnimation.GetComponent<Animator>();
        }
        if (showThisObject != null && ButtonTybes == Tybe.ShowObjects)
        {
            foreach (GameObject obj in showThisObject)
            {
                obj.SetActive(!obj.activeSelf);
            }
        }
    }

    public void Update()
    {
        SetScale();
    }

    public void AnimationFinished()
    {
        print("ButtoRun");
        AnimationFinish = true;
    }

    public void SetScale()
    {
        if (AnimationFinish)
        {
            switch (ButtonTybes)
            {
                case Tybe.Normal:
                    if (Player != null && canChange == true)
                    {
                        Player.transform.localScale = Vector3.MoveTowards(Player.transform.localScale, PlayerScale, speed * Time.deltaTime);
                        StartCoroutine(stopChange(3));
                    }
                    break;

                case Tybe.RunAnimation:
                    anim.SetBool("Run", true);
                    break;

                case Tybe.ShowObjects:
                    if (showThisObject != null && !showObjectToggled)
                    {
                        foreach (GameObject obj in showThisObject)
                        {
                            obj.SetActive(!obj.activeSelf);
                        }
                        showObjectToggled = true;
                    }
                    break;
            }





        }
    }

    IEnumerator stopChange(float delay)
    {
        yield return new WaitForSeconds(delay);
        canChange = false;
    }


}
