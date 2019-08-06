using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Camera MainCamera;
    private CameraShaker CameraShaker;
    private Rigidbody2D rb;

    private bool onGround = false;
    private bool canDoubleJump = true;

    private void Awake()
    {
        MainCamera = Camera.main;
        CameraShaker = MainCamera.GetComponent<CameraShaker>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleControls();
    }

    void HandleControls()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!onGround && canDoubleJump)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canDoubleJump = false;
            } else if (onGround)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            CameraShaker.Instance.ShakeOnce(15f, 3f, 0.0f, 0.1f);
            onGround = true;
            canDoubleJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
}
