using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingState : AIBaseState
{

    public override void Entered(AIStateManager state)
    {
        state.animator.Play("zombie_walk");
    }

}
