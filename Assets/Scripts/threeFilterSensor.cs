using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class threeFilterSensor : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float angel;
    [SerializeField] LayerMask objectLayer;
    [SerializeField] LayerMask obstacleLayer;
    public Collider detectedObject;
    [SerializeField]NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance,objectLayer);
        detectedObject = null;
        for(int i = 0;i<colliders.Length; i++) 
        {
            Collider collider = colliders[i];
            Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center-transform.position);
            float angleToCollider =Vector3.Angle(transform.forward, directionToCollider);
            if(angleToCollider < angel)
            {
                if(!Physics.Linecast(transform.position,collider.bounds.center,obstacleLayer))
                {
                    detectedObject = collider;
                    if(detectedObject!= null)
                    {
                        agent.destination = detectedObject.transform.position;
                        agent.isStopped = false;
                    }
                    //agent.SetDestination(detectedObject.transform.position);
                    break;
                    
                }
            }
        }
        if(detectedObject==null)
        {
            agent.isStopped = true;
        }
    }
}
