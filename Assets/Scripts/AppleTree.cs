using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDrection = 0.1f;
    public float secondsBetweenApplesDrops = 1f;

    void Start()
    {
        //Call to DropApple method for drop apple once in 1 sec
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed);
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);
        
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDrection)
            speed *= -1;
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenApplesDrops);
    }
}
