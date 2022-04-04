using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Vector3 initalPosition;    
    bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        initalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround) Jump();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Ground") isOnGround = true;
        else isOnGround = false;

        if (collision.collider.tag == "Obstacle") SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400.0f));
        isOnGround = false;
    }
}
