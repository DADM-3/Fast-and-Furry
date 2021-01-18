using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    //Components references
    private Rigidbody rb;

    //Gyroscope management
    private Gyroscope gyroscope;

    //Movement
    [SerializeField]
    private float frontalMoveSpeed;
    [SerializeField]
    private float lateralMoveSpeed;
    private Vector3 velocity;

    //Jump
    [SerializeField]
    private float jumpForce;
    private Vector3 startSwipe, endSwipe;
    public bool jumping;
    public LayerMask floorLayer;

    //Camera follow
    [SerializeField]
    private Transform shouldersFollow;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        EnableGyroscope();
    }

    void Update()
    {
        if (GameManager.sharedInstance.paused) return;
        if (GameManager.sharedInstance.countdownActive) return;
        shouldersFollow.transform.position = new Vector3(transform.position.x, shouldersFollow.transform.position.y, transform.position.z);
        velocity = new Vector3(gyroscope.attitude.normalized.x * lateralMoveSpeed, rb.velocity.y, frontalMoveSpeed);
        //velocity = new Vector3(rb.velocity.x, rb.velocity.y, frontalMoveSpeed);
        JumpSwipeCheck();
    }

    private void FixedUpdate()
    {
        if (GameManager.sharedInstance.paused) return;
        if (GameManager.sharedInstance.countdownActive) return;
        rb.velocity = velocity;
        JumpIfAllowed();
    }
    #endregion

    #region My functions
    private void EnableGyroscope()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
        }
        else
        {
            //throw new System.Exception("Gyroscope not detected!");
        }
    }

    private void JumpSwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startSwipe = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endSwipe = Input.GetTouch(0).position;
            if (endSwipe.y > startSwipe.y && IsTouchingFloor())
                jumping = true;
        }
    }

    private void JumpIfAllowed()
    {
        if (jumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumping = false;
        }
    }

    private bool IsTouchingFloor()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.7f, floorLayer);
    }
    #endregion
}
