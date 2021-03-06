using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float range = 15.0f;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        var leftBound = leftBorder.transform.position.x + range;
        var rightBound = rightBorder.transform.position.x - range;

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if(transform.position.x > rightBound)
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);

        if(transform.position.x < leftBound)
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        
        if (Input.GetKeyDown(KeyCode.Space))
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
}
