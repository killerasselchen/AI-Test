using UnityEngine;
using System.Collections;

public class PointsOfIntresst : MonoBehaviour 
{
    public Vector3 NextWaypoint;
    public Vector3 LastWaypoint;
    public Vector3 PenultimateWaypoint;
    public GameObject[] Waypoints;

    public GameObject[] Agents;

	// Use this for initialization
	void Start () 
    {
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        SelectNewWaypoint();
        LastWaypoint = NextWaypoint;
        PenultimateWaypoint = NextWaypoint;
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    public void SelectNewWaypoint()
    {
        PenultimateWaypoint = LastWaypoint;
        LastWaypoint = NextWaypoint;

        while(NextWaypoint != LastWaypoint && NextWaypoint != PenultimateWaypoint)
        {
            NextWaypoint = Waypoints[Random.Range(0, Waypoints.Length)].transform.position;
        }
    }

    public void SearchAgents()
    {
        Agents = GameObject.FindGameObjectsWithTag("Agent");
    }
}
