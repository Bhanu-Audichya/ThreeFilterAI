using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AIBaseState
{

    public override void Entered(AIStateManager state)
    {
        if(state.target != null) 
        {
            state.SwitchState(state.followingState);
        }
        else
        {

            state.animator.Play("Idle_State");
        }
    }
}
