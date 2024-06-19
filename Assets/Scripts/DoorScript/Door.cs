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
    [SerializeField]
    private DoorAway doorAway;
    private bool ISteleporting = false;

    public float DelayAnimation = 0.5f;
    public float NearValue;
    public string SceneName;
    public bool PlayerIsDoor = false;
    public Vector3 PlayerScalse = new Vector3(0.5f,0.5f,0.5f);
    [SerializeField] private float PlyayerRotaiotn = 90f;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        doorAway = GetComponent<DoorAway>();

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
            Player.transform.rotation = Quaternion.Euler(Player.transform.rotation.x, PlyayerRotaiotn, Player.transform.rotation.z);
            Player.transform.localScale = PlayerScalse;
            StartCoroutine(PlayAfterDelay(DelayAnimation));
            if (doorAway != null)
            {
                doorAway.canWalk = false;
            }

        }

    }

    IEnumerator PlayAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);


        if (PlayerIsDoor == false)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            if (ISteleporting == false)
            {
                StartCoroutine(Teleport(delayTeleport));
            }
        }
    }

    void AnimationFinished()
    {
        StartCoroutine(Teleport(delayTeleport));
    }

    IEnumerator Teleport(float delay)
    {
        ISteleporting = true;
        LevelLoaderScriipt.levelLoaderScriipt.RunAnimation(0.5f);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneName);
    }

}
