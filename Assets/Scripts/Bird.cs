using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public float jumpSpeed;
    public float rotatePower;
    public TextMeshPro scoreText;
    public AudioClip scoreSound;

    Rigidbody2D rb;
    int score = 0;
    AudioSource source;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
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
        var currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        source.clip = scoreSound;
        source.Play();
        scoreText.text = score.ToString();
    }
}
