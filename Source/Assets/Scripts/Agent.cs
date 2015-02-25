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

    public AgentStatesHandler State = new AgentGuard();

    public GameObject WP1;
    public GameObject WP2;
    public GameObject WP3;
    public GameObject WP4;
    public GameObject WP5;
    public GameObject WP6;
    public GameObject WP7;
    public GameObject WP8;
    public GameObject WP9;
    //public enum WPs { wp1, wp2, wp3, wp4, wp5, wp6, wp7, wp8, wp9 };

    public Vector3 nextWaypoint;

    void Start()
    {
        agentStartPos = transform.position;
        nextWaypoint = WP1.transform.position;
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
}
