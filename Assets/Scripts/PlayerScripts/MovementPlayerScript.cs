using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerScript : MonoBehaviour
{
    [Header ("Transform")]
    public GameObject RayPos;
    private Vector3 movement;

    [Space]

    [Header ("ProprtiesValues")]
    public float speed;
    public float jumpForce;
    public float detectionRadius = 0.8f;
    public float rotationSpeed;

    [Space]

    [Header("ProprtiesControls")]
    public bool ReverseControl = false;
    public bool canJump = true;
    public bool canMove = true;
    public bool Door = false;

    [Space]

    [Header("Particles")]
    public ParticleSystem[] PlayerParticles;

    [Space]

    [Header("GetCom")]
    private Rigidbody rb;
    private Animator anim;

    [Header("PrivateVarProprties")]
    private float moveZ;
    private bool isGrounded;
    [HideInInspector] public bool CanRunAnimation = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveZ = Input.GetAxis("Horizontal");


        if (Input.GetButtonDown("Jump") && isGrounded == true && canJump == true)
        {
            Jump();
        }

    }

    void FixedUpdate()
    {

        print(isGrounded);

        Move(movement);
        if (Door == false)
        {
            Flip();
            Animator();
        }
        Control();
        groundCheck();
    }

    public void Control()
    {
        switch (ReverseControl)
        {
            case true:
                movement = new Vector3(0, 0, -moveZ);
                break;
            case false:
                movement = new Vector3(0, 0, moveZ);
                break;
        }
    }
    void Animator()
    {
        if (moveZ != 0 && isGrounded == true && CanRunAnimation == true)
        {
            anim.SetBool("IsWalk", true);
        }
        else if (moveZ == 0 && isGrounded == true || CanRunAnimation == false)
        {
            anim.SetBool("IsWalk", false);
        }

        if (isGrounded == false && CanRunAnimation == true)
        {
            anim.SetBool("IsJump", true);
        }
        else if (isGrounded == true && CanRunAnimation == true)
        {
            anim.SetBool("IsJump", false);
        }

    }

    public void RunParticles(ParticleSystem TheParticle, Vector3 ParticlesPosition)
    {
        Instantiate(TheParticle, ParticlesPosition, TheParticle.transform.rotation);
    }

    void Flip()
    {

        Quaternion targetRotation;

        if (movement.z < 0)
        {
            targetRotation = Quaternion.Euler(0, -180, 0);
        }
        else if (movement.z > 0)
        {
            targetRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            return;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        if (moveZ == 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

    }

    void Move(Vector3 direction)
    {
        Vector3 velocity = rb.velocity;
        rb.velocity = new Vector3(velocity.x, velocity.y, direction.z * speed);
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    public void groundCheck()
    {
        Collider[] hitColliders = Physics.OverlapSphere(RayPos.transform.position, detectionRadius);
        isGrounded = false;

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Ground"))
            {
                isGrounded = true;
                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(RayPos.transform.position, detectionRadius);
    }


}

