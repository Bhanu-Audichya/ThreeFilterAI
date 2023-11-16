using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    Vector3 initialPos;
    // Start is called before the first frame update

    private void Start()
    {
        initialPos = this.transform.position;
    }

    private void LateUpdate()
    {
        this.transform.position = initialPos + player.transform.position;
    }
}
