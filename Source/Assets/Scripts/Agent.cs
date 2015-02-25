using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class Agent : MonoBehaviour 
{
    public float Speed;
    public float Health = 100;

    public Vector3 playerPos;
    public Vector3 agentStartPos;
    public float DistanceToPlayer;
    public GameObject ViewrangeSphere;
    public float AgentViewrange;
    public GameObject ReachSpehre;
    public float AgentReach;

    public bool AgentSeeYou = false;
    public bool AgentAttack = false;
    public bool AgentIsAtStartPos = true;

    public Vector3 NextWaypoint;
    public Vector3 LastWaypoint;
    public Vector3 PenultimateWaypoint;
    public GameObject[] Waypoints;
    public GameObject[] Agents;

    public AgentStatesHandler State = new AgentGuard();

    public Vector3 nextWaypoint;

    void Start()
    {
        agentStartPos = transform.position;
        SearchWaypoints();
        SelectNewWaypoint();
        LastWaypoint = Waypoints[0].transform.position;
        PenultimateWaypoint = Waypoints[0].transform.position;
    }

	void Update()
    {
        DistanceCheck();
        SphereAdjust();
        State.Handle(this);
    }

    void DistanceCheck()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        DistanceToPlayer = Vector3.Distance(playerPos, transform.position);
    }

    void SphereAdjust()
    {
        ViewrangeSphere.transform.localScale = new Vector3(AgentViewrange * 2, AgentViewrange * 2, AgentViewrange * 2);
        ReachSpehre.transform.localScale = new Vector3(AgentReach, AgentReach, AgentReach);
    }
    
    protected void SearchWaypoints()
    {
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    public void SelectNewWaypoint()
    {
        PenultimateWaypoint = LastWaypoint;
        LastWaypoint = NextWaypoint;

        while (NextWaypoint == LastWaypoint || NextWaypoint == PenultimateWaypoint)
        {
            NextWaypoint = Waypoints[Random.Range(0, Waypoints.Length)].transform.position;
        }
    }

    public void SearchAgents()
    {
        Agents = GameObject.FindGameObjectsWithTag("Agent");
    }
}
