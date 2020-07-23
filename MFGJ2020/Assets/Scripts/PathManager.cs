using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//recognize waypoints to direct player's movement
public class PathManager : MonoBehaviour
{
    private GameObject[] waypoints;

    private static int waypointIndex = 0;
    private int maxIndex;

    public static PathManager instance;


    // Start is called before the first frame update
    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").OrderBy(x =>x.transform.GetSiblingIndex()).ToArray();
        maxIndex = waypoints.Length-1;
        instance = this;
        

        ////check that waypoints are coming in in order
        //foreach (GameObject waypoint in waypoints)
        //{
        //    Debug.Log(waypoint.name);
        //}
    }

    public void UpdateWaypoint()
    {
        waypoints.ElementAt(waypointIndex).SetActive(false);
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
