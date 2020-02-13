using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum pickupType { Ammo,Health}
public class Pickup : MonoBehaviour
{
    public pickupType pickuptype;
    public int value;

    [SerializeField] float offset;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotation;

    private bool isGoingUp;
    private Vector3 pos1;
    private Vector3 pos2;

    private void Start()
    {
        pos1 = transform.position;
        pos2 = pos1;
        pos2.y += offset;
    }

    private void Update()
    {
        if (transform.position == pos1)
            isGoingUp = true;
        else if (transform.position == pos2)
            isGoingUp = false;

        if (isGoingUp)
            transform.position = Vector3.MoveTowards(transform.position, pos2, moveSpeed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, pos1, moveSpeed * Time.deltaTime);

        transform.Rotate(transform.up, rotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Character character = other.GetComponent<Character>();

            switch (pickuptype)
            {
                case pickupType.Ammo:
                    character.TakeAmmo(value);
                    break;
                case pickupType.Health:
                    character.TakeHP(value);
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }
}
