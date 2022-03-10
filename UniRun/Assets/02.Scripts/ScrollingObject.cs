using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            // 초당 speed만큼 왼쪽으로 평행이동 구현
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
