using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnManager : MonoBehaviour
{
    float cloudTimer;
    public GameObject cloud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreateClouds();
    }

    void CreateClouds()
    {
        cloudTimer += Time.deltaTime;
        Vector3 topRightCorner = GameObject.Find("CloudSpawnManager").transform.position;
        int altitude = Random.Range(0,2);
        if (cloudTimer >= 8)
        {
            GameObject.Instantiate(cloud, topRightCorner + -Vector3.up * altitude, Quaternion.identity);
            cloudTimer = 0;
        }
    }
}
