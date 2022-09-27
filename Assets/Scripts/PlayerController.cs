using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    //Movement
    public PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
    private float walkSpeed = 5.0f;
    public Camera playerCamera;
    Vector3 cameraRotation;

    //Jump
    Rigidbody rb;
    private float distanceToGround;
    private bool isGrounded = true;
    public float jumpForce = 5f;

    //Animation
    Animator playerAnimator;
    private bool isWalking = false;

    //Gun
    public GameObject bulletPrefab;
    public Transform projectilePos;

    private void OnEnable()
    {
        inputAction.Player.Enable();
    }

    private void OnDisable()
    {
        inputAction.Player.Disable();
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }

        inputAction = new PlayerAction();

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => Jump();

        inputAction.Player.Shoot.performed += cntxt => Shoot();


        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Jump()
    {
        checkGrounded();
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void Shoot()
    {
        Rigidbody bulletRb = Instantiate(bulletPrefab, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 5f, ForceMode.Impulse);
    }

    private void checkGrounded()
    {
        Debug.Log(GetComponent<Rigidbody>().velocity.y);
        isGrounded = GetComponent<Rigidbody>().velocity.y == 0; //Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.5f) && 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);
        transform.Translate(Vector3.right * move.x * Time.deltaTime * walkSpeed, Space.Self);
    }
}
