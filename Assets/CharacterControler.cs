using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed;
    public Transform Orientation;

    float verticalInput;
    float horizontalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }


    private void Update()
    {
        MyInput();
    }


    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }


    private void MovePlayer()
    {
        moveDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);
    }
}
