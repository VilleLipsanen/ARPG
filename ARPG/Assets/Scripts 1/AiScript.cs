using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiScript : MonoBehaviour
{
    [HideInInspector]
    public enum State
    {
        Patrol,
        Chase,
        Attack,
        Idle,
    }
    public Transform player;

    public State state;
    [HideInInspector]
    public State lastState;

    private NavMeshAgent agent;

    public GameObject[] targets;

    [HideInInspector]
    public int patrolTarget;

    private float dist;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = State.Patrol;
        lastState = state;
        Patrol();
    }


    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Patrol:
                if (lastState != State.Patrol)
                    Patrol();
                break;
            case State.Chase:
                agent.SetDestination(player.transform.position);
                break;
            case State.Attack:
                Debug.Log("Attack");
                break;
            case State.Idle:

                break;
        }
    }

    private void LateUpdate()
    {
        dist = Vector3.Distance(transform.position, player.position);
        if (dist < 10f && dist > 2f)
        {
            ChangeState(State.Chase);
        }
        if(dist < 2f)
        {
            ChangeState(State.Attack);
        }
    }

    void Patrol()
    {
        if(state == State.Patrol)
            agent.SetDestination(targets[patrolTarget].transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (state == State.Patrol)
        {
            if (other.tag == "patrol")
            {
                patrolTarget++;
                Debug.Log(patrolTarget);
                if (patrolTarget == targets.Length)
                {
                    patrolTarget = 0;
                }
                Invoke("Patrol", 5f);
            }
        }
    }
    private void ChangeState(State _state)
    {
        lastState = state;
        state = _state;
    }
}
