using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool dogOnCooldown;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (!dogOnCooldown && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("SpawnDog");
        }
    }

    IEnumerator SpawnDog()
    {
        dogOnCooldown = true;
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        yield return new WaitForSeconds(1);
        dogOnCooldown = false;
    }
}
