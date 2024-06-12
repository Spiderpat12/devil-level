using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScritp : MonoBehaviour
{
    [Header ("ProprtiesVar")]
    public float Delay;
    public GameObject Spikes;
    public float detectionRadius = 5f;
    public LayerMask detectionLayer;

    private Animator anim;
    private bool PlayerEnter = false;
    private bool CanCheck = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {



        if (PlayerEnter && CanCheck == true)
        {
            StartCoroutine(RunMoveAnimation(Delay));
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                PlayerEnter = true;
            }
        }

    }

    IEnumerator RunMoveAnimation(float delay)
    {
        CanCheck = false;
        yield return new WaitForSeconds(delay);
        anim.SetBool("Run", true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
