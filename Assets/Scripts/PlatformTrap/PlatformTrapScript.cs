using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrapScript : MonoBehaviour
{
    [Header ("SphereProprties")]
    public float detectionRadius = 5f;
    public LayerMask detectionLayer;

    [Space]

    [Header("TrapProprties")]
    public float delay;
    public float ShakeInt;

    [Header("PrivateVar")]
    private bool PlayerEnter = false;
    private Vector3 orignalPos;
    private Rigidbody rb;
    private bool drop = false;

    private void Start()
    {
        orignalPos = transform.localPosition;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        shakeGameObject();

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                PlayerEnter = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    void shakeGameObject()
    {
        if (PlayerEnter && !drop)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * ShakeInt;
            transform.position = orignalPos + shakeOffset;
            StartCoroutine(Drop(delay));
        }
    }

    IEnumerator Drop(float Delay)
    {
        yield return new WaitForSeconds(Delay);
        orignalPos = transform.position;
        drop = true;
        rb.useGravity = true;
        rb.isKinematic = false;
    }

}