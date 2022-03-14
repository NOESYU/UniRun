using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int count = 3;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.25f;
    private float timeBetSpawn;

    // y 값 배치는 랜덤으로 생성
    public float yMin = -3.5f;
    public float yMax = 1.5f;

    // x 값 배치는 고정된 값으로 사용
    private float xPos = 20f;

    private GameObject[] platforms;
    private int currentIndex = 0;

    private Vector2 poolPos = new Vector2(0, -25);
    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[count];
        for(int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPos, Quaternion.identity);
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;

        if (GameManager.instance.isGameover) return;

        if(Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float yPos = Random.Range(yMin, yMax);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;
            if (currentIndex >= count) currentIndex = 0;

        }

    }
}
