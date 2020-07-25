using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public PathManager path;
    private Vector3 target;
    private float movementSpeed = 5f;
    private float turnSmoothTime = 1.5f;
    private float turnSmoothVelocity;
    private Rigidbody rig;

    [SerializeField]
    private float acceleration = 0.05f;
    


    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        if (path)
        {
            target = path.GetWaypoint(path.CurrentIndex()).transform.position;
        }
        else
        {
            target = this.transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        // to stop player input during pause
        if (GameManager.instance.paused)
            return;

        movementSpeed += acceleration;
        agent.destination = target;
        PathTrace();
    }

    /// <summary>
    /// constantly moves character in forwards direction towards destination
    /// TO DO: Look into making it go faster over time.
    /// </summary>
    private void PathTrace()
    {
        Vector3 direction = GetDirection();
        ApplyRotation(direction);
       
        Vector3 movement = direction * movementSpeed * Time.deltaTime;
        agent.Move(movement);
    }

    private Vector3 GetDirection()
    {
        Vector3 heading = target - transform.position;
        float distance = heading.magnitude;
        return heading / distance;
    }

    private void ApplyRotation(Vector3 direction)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z);
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    public void UpdateWaypoint()
    {
        if (path.CurrentIndex() == path.MaxIndex())
        {
            //removes waypoint so it doesn't go flying endlessly into the abyss
            path.GetWaypoint(path.CurrentIndex()).SetActive(false);
            GameManager.instance.LevelEnd();
        }
        else
        {
            path.UpdateWaypoint();
            target = path.GetWaypoint(path.CurrentIndex()).transform.position;
        }

    }

   

}
