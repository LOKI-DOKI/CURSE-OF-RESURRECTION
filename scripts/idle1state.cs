using UnityEngine;

public class idle1state : StateMachineBehaviour
{
    float timer;
    Transform Player;
    float chaseRange = 8;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       timer += Time.deltaTime;
        if (timer > 5)
        {
            animator.SetBool("isPatrolling",true);
        }
        float distance = Vector3.Distance(Player.position,animator.transform.position);
        if(distance < chaseRange)
        {
            animator.SetBool("isChasing",true) ; 
        }

    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // base.OnStateExit(animator, stateInfo, layerIndex);
    }

}
