using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public List<GameObject> Skeletons;

    private int SkeletonIndex;

    public Transform player;

    private Animator m_Animator;

    private float timer = 0f;

    public enum State
    {
        Patrol,
        Chase,
        Attack,
        Idle,
        Summon,
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
                    timer = 2.35f;
                    agent.SetDestination(transform.position);
                    m_Animator.SetBool("Run", false);
                    m_Animator.SetBool("Attack", true);
                    //transform.LookAt(player);
                }
                else
                    timer -= Time.deltaTime;
                break;
            case State.Summon:
                m_Animator.SetBool("Run", false);
                m_Animator.SetBool("Attack", false);
                m_Animator.SetBool("Summon", true);
                break;
            case State.Idle:
                m_Animator.SetBool("Run", false);
                m_Animator.SetBool("Attack", false);
                m_Animator.SetBool("Summon", false);
                break;
        }
    }

    /*void Patrol()
    {
        if (state == State.Patrol)
            agent.SetDestination(targets[patrolTarget].transform.position);
    }*/

    public void Summon()
    {
        Skeletons[SkeletonIndex].SetActive(true);
        SkeletonIndex++;
        m_Animator.SetBool("Summon", false);
    }

    private void LateUpdate()
    {
        dist = Vector3.Distance(transform.position, player.position);
        if (dist >= 45f)
            ChangeState(State.Idle);
        if (dist < 45f && dist > 3f)
        {
            if(SkeletonIndex < Skeletons.Count)
            {
                ChangeState(State.Summon);
            }
            else if (timer <= 0f)
            {
                //transform.LookAt(player);
                ChangeState(State.Chase);
            }
        }
        if (dist < 3f)
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
