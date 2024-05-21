using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxHorizontal;
    public Transform spawnPoint;
    public float spawnRate;
    public TextMeshProUGUI scoreText;
    public GameObject tapText;

    bool gameStarted = false;
    int score = 0;
    
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
            gameStarted = true;
            tapText.SetActive(false);
            StartSpawning();
        }
    }


    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxHorizontal, maxHorizontal);
        Instantiate(block, spawnPos, Quaternion.identity);
        score++;
        scoreText.text = score.ToString();
    }
}
