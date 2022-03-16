using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool stepped = false; //캐릭터가 밟은 발판이 첫 걸음인지 아닌지 판별

    // OnEnable()
    // 컴포넌트가 활성화될 때마다 자동으로 한 번 실행되는 메소드
    // 컴포넌트를 비활성화하고 활성화할 때도 매번 실행된다.
    private void OnEnable()
    {
        stepped = false;

        // 장애물 수만큼 loop
        for(int i = 0; i < obstacles.Length; i++)
        {
            // 1/3 의 확률로 활성화
            if (Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
