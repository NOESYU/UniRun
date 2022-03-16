using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int count = 5;

    public float timeBetSpawnMin = 0.1f;
    public float timeBetSpawnMax = 1.0f;
    private float timeBetSpawn;

    public float yMin = -2.0f;
    public float yMax = 2.0f;

    public float xMin = 10f;
    public float xMax = 15f;

    private GameObject[] coins;
    private int currentIndex = 0;

    private Vector2 poolPos = new Vector2(0, -25);
    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        coins = new GameObject[count];
        for(int i = 0; i < count; i++)
        {
            coins[i] = Instantiate(coinPrefab, poolPos, Quaternion.identity);
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;

        if (GameManager.instance.isGameover) return;

        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float yPos = Random.Range(yMin, yMax);
            float xPos = Random.Range(xMin, yMin);

            coins[currentIndex].SetActive(false);
            coins[currentIndex].SetActive(true);

            coins[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;
            if (currentIndex >= count) currentIndex = 0;

        }
    }
}
