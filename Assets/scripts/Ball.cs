﻿using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 16f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    // Start is called before the first frame update

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRidgidBody2D;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRidgidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LaunchOnMouseClick();
            LockBallToPaddle();
        }
    }
    private void LaunchOnMouseClick()
        {
            if(Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                myRidgidBody2D.velocity = new Vector2(xPush, yPush);
            }
        }
    private void LockBallToPaddle()
        {
            Vector2 PaddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddleToBallVector + PaddlePos;
        }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak =
            new Vector2(UnityEngine.Random.Range(0f, randomFactor),
           UnityEngine.Random.Range(0f, randomFactor));
        if (hasStarted && collision.gameObject.tag != "Unbreakable") 
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRidgidBody2D.velocity += velocityTweak;
        }
    }
}
