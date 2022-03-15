using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called once per frame after Update has finished
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
