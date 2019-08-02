using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonAi : MonoBehaviour
{
    public Transform player;

    private Animator m_Animator;

    private float timer = 0f;

    public enum State
    {
        Patrol,
        Chase,
        Attack,
        Idle,
    }

    private NavMeshAgent agent;

    public State state;
    [HideInInspector]
    public State lastState;

    private float dist;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = State.Idle;
        lastState = state;
        m_Animator = gameObject.GetComponent<Animator>();
        //Patrol();
    }


    private void Update()
    {
        switch (state)
        {
            case State.Patrol:
                m_Animator.SetBool("Run", true);
                break;
            case State.Chase:
                m_Animator.SetBool("Attack", false);
                m_Animator.SetBool("Run", true);
                agent.SetDestination(player.transform.position);
                break;
            case State.Attack:
                if (timer <= 0f)
                {
                    timer = 2.7f;
                    agent.SetDestination(transform.position);
                    m_Animator.SetBool("Run", false);
                    m_Animator.SetBool("Attack", true);
                    //transform.LookAt(player);
                }
                else
                    timer -= Time.deltaTime;
                break;
            case State.Idle:

                break;
        }
    }

    /*void Patrol()
    {
        if (state == State.Patrol)
            agent.SetDestination(targets[patrolTarget].transform.position);
    }*/

    private void LateUpdate()
    {
        dist = Vector3.Distance(transform.position, player.position);
        if (dist < 25f && dist > 1.2f)
        {
            if (timer <= 0f)
            {
                //transform.LookAt(player);
                ChangeState(State.Chase);
            }
        }
        if (dist < 1.2f)
        {
            ChangeState(State.Attack);
        }
        else
        {
            if (timer <= 0f)
                Debug.Log("0 time");
            //transform.LookAt(player);
        }
    }

    private void ChangeState(State _state)
    {
        lastState = state;
        state = _state;
    }
}
