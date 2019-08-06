using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jun_Player : MonoBehaviour
{
    public int moveSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            //transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            rb.AddForce(Vector2.left * moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            rb.AddForce(Vector2.right * moveSpeed);
        }
    }
}
