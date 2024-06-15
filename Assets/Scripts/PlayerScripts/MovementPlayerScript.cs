using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerScript : MonoBehaviour
{
    [Header ("Transform")]
    private Vector3 movement;

    [Space]

    [Header ("ProprtiesValues")]
    public float speed;
    public float jumpForce;
    public float groundCheckDistance;
    public float rotationSpeed;

    [Space]

    [Header("ProprtiesControls")]
    public bool ReverseControl = false;
    public bool canJump = true;
    public bool canMove = true;

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

        isGrounded = CheckGrounded();

        if (Input.GetButtonDown("Jump") && isGrounded && canJump == true)
        {
            Jump();
        }

    }

    void FixedUpdate()
    {
        Move(movement);
        Flip();
        Animator();
        Control();
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
        if (moveZ != 0 && isGrounded && CanRunAnimation == true)
        {
            anim.SetBool("IsWalk", true);
        }
        else if (moveZ == 0 && isGrounded || CanRunAnimation == false)
        {
            anim.SetBool("IsWalk", false);
        }

        if (!isGrounded && CanRunAnimation == true)
        {
            anim.SetBool("IsJump", true);
        }
        else if (isGrounded && CanRunAnimation == true)
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

    bool CheckGrounded()
    {
        RaycastHit hit;
        bool grounded = Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance) && !hit.collider.CompareTag("DamageObject");
        Color colorRay = grounded ? Color.green : Color.red;
        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, colorRay);
        return grounded;
    }
}
