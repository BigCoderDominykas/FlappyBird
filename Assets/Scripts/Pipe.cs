using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public static float speed;

    float startX;
    float endX;

    void Start()
    {
        startX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x - 1;
        endX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0)).x + 1;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Teleport back
        if (transform.position.x < startX)
        {
            var height = Random.Range(-1f, 4f);
            transform.position = new Vector3(endX, height);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
