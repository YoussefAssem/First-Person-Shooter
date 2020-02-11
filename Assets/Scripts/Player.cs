using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Camera")]
    public float lookSensitivity;
    public float maxLook;
    public float minLook;
    private float rotX;

    private new Camera camera;
    private new Rigidbody rigidbody;
    private new Weapon weapon;

    public float maxDistance;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        camera = Camera.main;
        rigidbody = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        Move();

        if (Input.GetButtonDown("Jump"))
            TruJump();

        if (Input.GetButton("Fire1"))
        {
            if (weapon.CanShoot())
                weapon.Shoot();
        }

        CamLook();
    }

    private void TruJump()
    {
        if (Physics.Raycast(transform.position, Vector3.down,maxDistance))
            rigidbody.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
    }

    private void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;

        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
        rotX = Mathf.Clamp(rotX, minLook, maxLook);

        camera.transform.localRotation = Quaternion.Euler(Vector3.right * -rotX);
        transform.eulerAngles += Vector3.up*y;
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 moveDir = (transform.right * x) + (transform.forward * z) + (transform.up * rigidbody.velocity.y);

        rigidbody.velocity = moveDir;
    }
}
