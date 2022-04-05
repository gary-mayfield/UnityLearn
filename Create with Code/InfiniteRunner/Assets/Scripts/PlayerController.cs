using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Vector3 initalPosition;    
    bool isOnGround;
    GameObject PauseButton, ExitButton, ResumeButton, GamePausedText;
    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        initalPosition = transform.position;
        GamePausedText = GameObject.Find("GamePaused");
        ResumeButton = GameObject.Find("ResumeButton");
        ExitButton = GameObject.Find("ExitButton");
        PauseButton = GameObject.Find("PauseButton");
        DisplayPauseButtons(false);
    }

    void DisplayPauseButtons(bool state)
    {
        PauseButton.SetActive(!state);
        ExitButton.SetActive(state);
        ResumeButton.SetActive(state);
        ExitButton.SetActive(state);
        GamePausedText.SetActive(state);
    }

    public void Pause()
    {
        paused = true;
        DisplayPauseButtons(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        DisplayPauseButtons(false);
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
