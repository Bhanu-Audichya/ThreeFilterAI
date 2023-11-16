using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateManager : MonoBehaviour
{
    public AIBaseState currentState;
    public AttackState attackState = new AttackState();
    public FollowingState followingState = new FollowingState();
    public IdleState idleState = new IdleState();
    public threeFilterSensor sensor;
    public Animator animator;
    public Collider target;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        currentState = idleState;
        currentState.Entered(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (sensor.detectedObject != null)
        {
            target = sensor.detectedObject;
        }
        else
            target = null;
    }

    public void SwitchState(AIBaseState newState)
    {
        currentState = newState;
        currentState.Entered(this);
    }
}
