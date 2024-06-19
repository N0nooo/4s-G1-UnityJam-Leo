using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;
    private Vector2 movement;
    private bool isGrounded;
    
    private GameInput inputAction;
    private InputAction jumpAction;
    
    [SerializeField] Vector3 groundCheckSize;
    [SerializeField] Vector3 groundCheckPos;

    [SerializeField] LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputAction = new GameInput();
        jumpAction = inputAction.Player.Jump;
    }
    private void OnEnable()
    {
        inputAction.Enable();
        jumpAction.performed += Jump;
        jumpAction.canceled += Jump;

    }

    private void OnDisable()
    {
        inputAction.Disable();
        jumpAction.performed -= Jump;
        jumpAction.canceled -= Jump;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(transform.position + groundCheckPos, groundCheckSize, 0, groundLayer);
        Movement();
    }

    private void Movement()
    {
        movement.x = Input.GetAxis("Horizontal");
        
        rb.MovePosition(rb.position + movement * (movementSpeed * Time.deltaTime));
    }
    
    void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(isGrounded);
        if (context.performed && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + groundCheckPos, groundCheckSize);
    }
}
