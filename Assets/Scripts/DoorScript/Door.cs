using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private float Dis;
    private GameObject Player;
    private Animator anim;
    public float DelayAnimation = 1;
    public float NearValue;
    public string SceneName;
    public float delayTeleport;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Player != null)
        {
            Dis = Vector3.Distance(transform.position, Player.transform.position);
        }

        if (Dis < NearValue)
        {
            MovementPlayerScript playerMovement = Player.GetComponent<MovementPlayerScript>();
            playerMovement.CanRunAnimation = false;
            Player.transform.position = new Vector3(transform.position.x, Player.transform.position.y, transform.position.z);
            Player.transform.rotation = Quaternion.Euler(Player.transform.rotation.x, 90, Player.transform.rotation.z);
            StartCoroutine(PlayAfterDelay(DelayAnimation));
        }

    }

    IEnumerator PlayAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        anim.SetBool("Run", true);
    }

    void AnimationFinished()
    {
        StartCoroutine(Teleport(delayTeleport));
    }

    IEnumerator Teleport(float delay)
    {
        LevelLoaderScriipt.levelLoaderScriipt.RunAnimation(0.5f);
        yield return new WaitForSeconds(delay);
        print("Teleport");
    }

}
