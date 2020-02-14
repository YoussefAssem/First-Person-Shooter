using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUserController : MonoBehaviour
{
    [Header("Camera")]
    public float lookSensitivity;
    public float maxLook;
    public float minLook;
    private float rotX;

    private new Camera camera;
    private PlayerController playerController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerController = GetComponent<PlayerController>();
        camera = Camera.main;
    }

    void Update()
    {
        if (GameManager.gameManager.gamePaused)
            return;

        CamLook();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool jump = Input.GetButtonDown("Jump");
        bool shoot = Input.GetButton("Fire1");

        playerController.Move(horizontal, vertical, jump,shoot);
    }

    private void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;

        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
        rotX = Mathf.Clamp(rotX, minLook, maxLook);

        camera.transform.localRotation = Quaternion.Euler(Vector3.right * -rotX);
        transform.eulerAngles += Vector3.up * y;
    }
}
