using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private Character character;

    private float maxDistance = 1.1f;

    private void Start()
    {
        character = GetComponent<Character>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(float horizontal, float vertical, bool jump, bool shoot,bool aim)
    {
        Vector3 moveDir = (transform.right * horizontal) + (transform.forward * vertical);

        moveDir.Normalize();
        moveDir *= aim == true ? character.aimMoveSpeed : character.moveSpeed;
        moveDir.y = rigidbody.velocity.y;

        rigidbody.velocity = moveDir;

        if (jump)
            TryJump();

        if (shoot)
            character.Shoot();
    }

    private void TryJump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, maxDistance))
            rigidbody.AddForce(Vector3.up * character.jumpForce, ForceMode.Impulse);
    }
}
