using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public float jumpSpeed;
    public float rotatePower;
    public float speed;

    public TextMeshPro scoreText;
    public AudioClip scoreSound;
    public AudioClip jumpSound;
    public AudioClip failSound;
    public GameObject endScreen;
    public GameObject skin1;
    public GameObject skin2;
    public GameObject skin3;
    public GameObject background1;
    public GameObject background2;
    public GameObject flashEffect;
    public GameObject tutorial;
    public GameObject tutorialFade;


    int score = 0;
    bool dead = false;
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
        rb.gravityScale = 0;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Jump();
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    void Jump()
    {
        if(Pipe.speed == 0 && jumpSpeed != 0)
        {
            Pipe.speed = speed;
            rb.gravityScale = 3;
            tutorial.SetActive(false);
            tutorialFade.SetActive(true);
            
        }

        source.clip = jumpSound;
        source.Play();

        rb.velocity = Vector2.up * jumpSpeed;
    }

    void Die()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;
        if (!dead)
        {
            source.clip = failSound;
            source.Play();
            dead = true;
        }
        PlayerPrefs.SetInt("Score", score);
        flashEffect.SetActive(true);

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
        scoreText.text = score.ToString();
    }
}
