﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    //public NavMeshAgent agent;
    //public PathManager path;
    //private Vector3 target;
    public float movementSpeed;
    public float jumpForce;
    //private float turnSmoothTime = 0.1f;
    //private float turnSmoothVelocity;
    private Rigidbody rig;

    //[SerializeField]
    //private float acceleration = 0.005f;
    private AudioSource audioSource;


    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        Time.timeScale = 1.0f;
    }
    //private void Start()
    //{
    //    target = path.GetWaypoint(path.CurrentIndex()).transform.position;
    //}
    // Update is called once per frame
    void Update()
    {
        // to stop player input during pause
        if (GameManager.instance.paused)
            return;

        //movementSpeed += acceleration;
        //agent.destination = target;
        //PathTrace();

        Move();

        
    }

    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        UnityEngine.Vector3 dir = new Vector3(xInput, 0, zInput) * movementSpeed;
        dir.y = rig.velocity.y;

        rig.velocity = dir;

        Vector3 facingDir = new Vector3(xInput, 0, zInput);
        
        if (facingDir.magnitude > 0)
        {
            transform.forward = facingDir;
        }
    }

    /// <summary>
    /// constantly moves character in forwards direction towards destination
    /// TO DO: Look into making it go faster over time.
    /// </summary>
    //private void PathTrace()
    //{

    //    Vector3 direction = GetDirection();
    //    ApplyRotation(direction);

    //    Vector3 movement = direction * movementSpeed * Time.deltaTime;
    //    agent.Move(movement);
    //}

    //private Vector3 GetDirection()
    //{
    //    Vector3 heading = target - transform.position;
    //    float distance = heading.magnitude;
    //    return heading / distance;
    //}

    //private void ApplyRotation(Vector3 direction)
    //{
    //    float targetAngle = Mathf.Atan2(direction.x, direction.z);
    //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
    //    transform.rotation = Quaternion.Euler(0f, angle, 0f);
    //}

    //public void UpdateWaypoint()
    //{
    //    if (path.CurrentIndex() == path.MaxIndex())
    //    {
    //        //removes waypoint so it doesn't go flying endlessly into the abyss
    //        path.GetWaypoint(path.CurrentIndex()).SetActive(false);
    //        GameManager.instance.LevelEnd();
    //    }
    //    else
    //    {
    //        path.UpdateWaypoint();
    //        target = path.GetWaypoint(path.CurrentIndex()).transform.position;
    //    }

    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.instance.GameOver();
        }
        else if (other.CompareTag("Coin"))
        {
            GameManager.instance.AddScore(1);
            Destroy(other.gameObject);
            audioSource.Play();
        }
        else if (other.CompareTag("Waypoint"))
        {
            PathManager.instance.UpdateWaypoint();
        }
    }

}
