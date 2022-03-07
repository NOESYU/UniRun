using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;

    private void Awake()
    {
        // Awake() 는 초기 1회 실행, Start() 보다 항상 빠르게 호출됨

        // bg 가로 길이
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -width)
        {
            // bg가 왼쪽으로 width 만큼 이동되면 오른쪽으로 reposion
            Reposion();
        }
    }

    void Reposion()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
