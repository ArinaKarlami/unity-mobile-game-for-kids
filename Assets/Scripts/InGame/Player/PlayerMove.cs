using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform groundPoint;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rigidbody2D;

    private float speed = 7f;
    private float jumpForce = 8f;

    private float moveInput;
    private float flipValue;

    private Button mobileButtonJump;
    private Joystick mobileJoystick;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        FindJoystick();
        FindMobileButtonJump();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = MoveVelocity();

        flipValue = (moveInput != 0) ? (moveInput > 0 ? 180 : 0) : flipValue;
        transform.eulerAngles = Vector3.up * flipValue;
    }

#if UNITY_STANDALONE || UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
#endif

    //
    // Helpers
    //

    private void Jump()
    {
        if (Ground())
        {
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }
    }

    private void FindJoystick()
    {
        GameObject mobileJoystickObject = GameObject.FindGameObjectWithTag("ui_Joystick");
        mobileJoystick = mobileJoystickObject ? mobileJoystickObject.GetComponent<Joystick>() : null;
    }

    private void FindMobileButtonJump()
    {
        GameObject mobileButtonJumpObject = GameObject.FindGameObjectWithTag("ui_ButtonJump");
        if (mobileButtonJumpObject)
        {
            mobileButtonJump = mobileButtonJumpObject.GetComponent<Button>();
            mobileButtonJump.onClick.AddListener(() =>
            {
                Jump();
            });
        }
    }

    //
    // Getters
    //

    public float FlipValue()
    {
        return flipValue;
    }

    private Collider2D Ground()
    {
        return Physics2D.OverlapCircle(groundPoint.position, .01f, groundLayer);
    }

    private Vector2 MoveVelocity()
    {
        moveInput = Application.isMobilePlatform ?
            mobileJoystick.Horizontal :
            Input.GetAxis("Horizontal");

        return new Vector2(moveInput * speed, rigidbody2D.velocity.y);
    }

}
