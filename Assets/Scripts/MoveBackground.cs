using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    float speed;
    private Transform backTransform;
    private float backSize;
    private float backPos;

    // Start is called before the first frame update
    void Start()
    {
        backTransform = GetComponent<Transform>();
        backSize = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    //private void Update()
    //{
    //    Move();
    //}

    // Update is called once per frame
    public void Move()
    {
        backPos += speed*Time.fixedDeltaTime;
        backPos = Mathf.Repeat(backPos, backSize);
        backTransform.position = new Vector3(backPos, 0, 0);
    }

    public void Stop()
    {
        speed = 0;
    }
}
