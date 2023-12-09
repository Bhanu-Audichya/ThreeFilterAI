using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingState : AIBaseState
{

    public override void Execute(AIStateManager state)
    {
        if(state.target!=null)
        {
            state.animator.SetBool("shouldFollow", true);
            state.animator.SetBool("shouldAttack", false);
        }
    }

    public override void Updating(AIStateManager state)
    {
        if (state.target == null)
        {
            state.SwitchState(state.idleState);
        }
        else if(Vector3.Distance(state.target.gameObject.transform.position,state.transform.position)<1.2)
        {
            state.SwitchState(state.attackState);
        }
    }
}
