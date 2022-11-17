using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 80f;
    public float jumpPower = 5f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Rotate();
        Jump();
    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = Vector3.forward*v + Vector3.right*h;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
    }
    void Rotate()
    {
        float r = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}
