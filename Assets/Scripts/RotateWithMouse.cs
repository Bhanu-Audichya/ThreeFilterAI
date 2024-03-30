using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    public GameObject rayCastFollow;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit hitInfo,float.MaxValue,layerMask))
        {
            rayCastFollow.transform.position = hitInfo.point;
        }
        Vector3 direction = (rayCastFollow.transform.position - player.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation,lookRotation,Time.deltaTime  * speed);

    }
}
