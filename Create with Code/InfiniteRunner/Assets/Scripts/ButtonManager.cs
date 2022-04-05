using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {   
        SceneManager.LoadScene("chapter1");
    }

    public void Resume()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().Resume();
    }

    public void Pause()
    {
        Debug.Log("Paused");
        GameObject.Find("Player").GetComponent<PlayerController>().Pause();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
