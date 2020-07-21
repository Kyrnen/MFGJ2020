using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public PathManager path;
    private Vector3 target;

    [SerializeField]
    private float movementSpeed = 3;
    [SerializeField]
    private float acceleration = 0.005f;

    private void Start()
    {
        target = path.GetWaypoint(path.CurrentIndex()).transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        movementSpeed += acceleration;
        agent.SetDestination(target);
        PathTrace();
    }

    /// <summary>
    /// constantly moves character in forwards direction towards destination
    /// TO DO: Look into making it go faster over time.
    /// </summary>
    private void PathTrace()
    {
        Vector3 movement = transform.forward * movementSpeed * Time.deltaTime;
        agent.Move(movement);
    }

    public void UpdateWaypoint()
    {
        if (path.CurrentIndex() == path.MaxIndex())
        {
            Debug.Log("Win");
        }
        else
        {
            path.nextWaypoint();
            target = path.GetWaypoint(path.CurrentIndex()).transform.position;
        }

    }

}
