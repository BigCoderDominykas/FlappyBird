using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

public class Bird : MonoBehaviour
{
    public float jumpSpeed;
    public float rotatePower;
    public float speed;

    public TextMeshPro scoreText;
    public AudioClip scoreSound;
    public GameObject endScreen;
    public GameObject skin1;
    public GameObject skin2;
    public GameObject skin3;
    public GameObject background1;
    public GameObject background2;


    int score = 0;
    Rigidbody2D rb;
    AudioSource source;

    private void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            background1.SetActive(true);
        }
        else
        {
            background2.SetActive(true);
        }

        switch (Random.Range(0, 3))
        {
            case 0:
                skin1.SetActive(true);
                break;
            case 1:
                skin2.SetActive(true);
                break;
            case 2:
                skin3.SetActive(true);
                break;
        }

        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        Pipe.speed = speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    void Die()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;
        Invoke("ShowMenu", 1f);
    }

    void ShowMenu()
    {
        endScreen.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        source.clip = scoreSound;
        source.Play();
        scoreText.text = score.ToString();
    }
}
