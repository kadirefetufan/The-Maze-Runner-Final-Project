﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    AudioSource source;

    Vector3 velocity;
    bool isGrounded;
    bool isMoving;

    public Transform ground;
    public float distance = 0.3f;

    public float speed;
    public float jumpHeight;
    public float gravity;

    public float originalHeight;
    public float crouchHeight;

    public LayerMask mask;

    public AudioClip[] stepSounds;

    public float timeBetweenSteps;
    float timer;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();

    }

    private void Update()
    {
        #region Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * -horizontal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);

        #endregion

        #region footsteps

        if (horizontal != 0 || vertical != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if(isMoving)
        {
            timer -= Time.deltaTime;

            if(timer <= 0 )
            {
                timer = timeBetweenSteps;

                source.clip = stepSounds[Random.Range(0, stepSounds.Length)];
                source.pitch = Random.Range(0.85f, 1.15f);


                source.Play();
            }
        }

        else
        {
            timer = timeBetweenSteps;
        }
        


        #endregion


        #region Jump

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            timeBetweenSteps = 1f;
        }

        #endregion

        #region Gravity

        isGrounded = Physics.CheckSphere(ground.position, distance, mask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        #endregion

        #region  Crouch

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            controller.height = crouchHeight;
            speed = 2.0f;
            jumpHeight = 0f;
        }

        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.height = originalHeight;
            speed = 5.0f;
            jumpHeight = 1f;
        }
        #endregion

        #region Run

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 8.0f;
            timeBetweenSteps = 0.3f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5.0f;
            timeBetweenSteps = 0.5f;

        }

        #endregion

    }



}
