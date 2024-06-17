using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private float Dis;
    private GameObject Player;
    private Animator anim;
    private float delayTeleport = 2f;
    private Vector3 originalScale;
    [SerializeField]
    private LevelNumber levelNumber;

    public float DelayAnimation = 0.5f;
    public float NearValue;
    public string SceneName;

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
            Player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Player.transform.rotation = Quaternion.Euler(Player.transform.rotation.x, 90, Player.transform.rotation.z);
            Player.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
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
        SceneManager.LoadScene(SceneName);
        levelNumber.value += 1;
        print("Teleport");
    }

}
