using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    float timer;
    float score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageTimer();
        score += Time.deltaTime;
        DisplayScore();
    }

    void ManageTimer()
    {
        timer += Time.deltaTime;
        if(timer >= 2)
        {
            AddObstacle();
            timer = 0;
        }
    }

    void AddObstacle()
    {
        Vector3 positionOfPlayer = GameObject.Find("Player").GetComponent<PlayerController>().initalPosition;
        float randomNumber = Random.Range(1, 5);

        for (int i = 0; i <= randomNumber; i++)
        {
            var distance = 20 + i;
            GameObject.Instantiate(obstacle, positionOfPlayer + Vector3.right * distance, Quaternion.identity);
        }
    }

    void DisplayScore()
    {
        GameObject.Find("ScoreUI").GetComponent<Text>().text = "" + (int)score;
    }
}
