using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AIBaseState
{

    public override void Execute(AIStateManager state)
    {
        if(state.target == null)
        {
            state.animator.SetBool("shouldFollow", false);
        }
        

    }

    public override void Updating(AIStateManager state)
    {
        if(state.target!= null) 
        {
            state.SwitchState(state.followingState);
        }
    }
}
