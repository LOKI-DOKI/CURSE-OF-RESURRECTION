using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class p2state : StateMachineBehaviour
{
    float timer;
    Transform Player;
    float chaseRange = 20;
    List<Transform> MayPoints = new List<Transform>();
    NavMeshAgent agent;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = 8f;

        GameObject go = GameObject.FindGameObjectWithTag("MayPoints");
        foreach (Transform t in go.transform)
            MayPoints.Add(t);


        agent.SetDestination(MayPoints[Random.Range(0, MayPoints.Count)].position);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(MayPoints[Random.Range(0, MayPoints.Count)].position);
        timer += Time.deltaTime;
        if (timer > 5)
        {
            animator.SetBool("isPatrolling", false);
        }
        float distance = Vector3.Distance(Player.position, animator.transform.position);
        if (distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }

    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
