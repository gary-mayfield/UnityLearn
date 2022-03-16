using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer1 : MonoBehaviour
{
    public GameObject player;
    private Vector3 thirdPersonOffset = new Vector3(0, 6, -11);
    private Vector3 firstPersonOffset = new Vector3(0, 3, 4);

    private bool toggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called once per frame after Update has finished
    void LateUpdate()
    {
        if(Input.GetButtonDown("Jump"))
            toggle = !toggle;

        var offset = toggle ? thirdPersonOffset : firstPersonOffset;

        transform.position = player.transform.position + offset;
    }
}
