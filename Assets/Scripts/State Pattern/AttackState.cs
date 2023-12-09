using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AIBaseState
{

    public override void Execute(AIStateManager state)
    {
        state.animator.SetBool("shouldAttack", true);
    }

    public override void Updating(AIStateManager state)
    {

        if(state.target!= null && Vector3.Distance(state.target.gameObject.transform.position,state.transform.position)>1.5)
        {
            state.SwitchState(state.followingState);
        }
    }
}
