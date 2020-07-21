using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//recognize waypoints to direct player's movement
public class PathManager : MonoBehaviour
{
    private GameObject[] waypoints;

    private int waypointIndex = 0;
    private int maxIndex;


    // Start is called before the first frame update
    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").OrderBy(x =>x.transform.GetSiblingIndex()).ToArray();
        maxIndex = waypoints.Length-1;

        //check that waypoints are coming in in order
        foreach (GameObject waypoint in waypoints)
        {
            Debug.Log(waypoint.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextWaypoint()
    {
        waypointIndex++;
    }

    public int CurrentIndex()
    {
        return waypointIndex;
    }

    public int MaxIndex()
    {
        return maxIndex;
    }

    public GameObject GetWaypoint(int x)
    {
        return waypoints.ElementAt(x);
    }
}
