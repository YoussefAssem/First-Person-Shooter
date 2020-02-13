using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    public int scoreToGive;

    private Character character;
    private NavMeshAgent agent;
    private Transform target;

    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        character = GetComponent<Character>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = target.position;
        agent.transform.LookAt(target);

        if (agent.velocity == Vector3.zero && target != null)
            character.Shoot();
    }
}