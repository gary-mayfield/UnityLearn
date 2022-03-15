using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 6, -11);

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
