using UnityEngine;
using System.Collections;

class AgentPatrol : AgentStatesHandler
{
    public override void Handle(Agent agent)
    {
        AI(agent);
    }

    void AI(Agent agent)
    {
        if (agent.DistanceToPlayer <= agent.AgentViewrange)
        {
            agent.AgentViewrange = 10;

            if (agent.DistanceToPlayer <= agent.AgentReach)
            {
                agent.transform.LookAt(agent.playerPos);
                agent.AgentAttack = true;
            }
            else
            {
                agent.transform.LookAt(agent.playerPos);
                agent.Speed = 0.6f;
                agent.transform.Translate(new Vector3(0, 0, agent.Speed));
                agent.AgentSeeYou = true;
                agent.AgentAttack = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            agent.State = new AgentGuard();
        }
        else
        {
            agent.AgentSeeYou = false;
            agent.AgentAttack = false;
            agent.AgentViewrange = 8;

            if (Vector3.Distance(agent.nextWaypoint, agent.transform.position) <= 1)
            {
                WaypointSelection(agent);
            }
            else
            {
                agent.Speed = 0.25f;
                agent.transform.LookAt(agent.nextWaypoint);
                agent.transform.Translate(new Vector3(0, 0, agent.Speed));
            }
        }
    }

    void WaypointSelection(Agent agent)
    {
        int rdm = Random.Range(0, 8);
       
        if(rdm == 0)
        {
            agent.nextWaypoint = agent.WP1.transform.position;
        }
        else if(rdm == 1)
        {
            agent.nextWaypoint = agent.WP2.transform.position;
        }
        else if(rdm == 2)
        {
            agent.nextWaypoint = agent.WP3.transform.position;
        }
        else if(rdm == 3)
        {
            agent.nextWaypoint = agent.WP4.transform.position;
        }
        else if(rdm == 4)
        {
            agent.nextWaypoint = agent.WP5.transform.position;
        }
        else if(rdm == 5)
        {
            agent.nextWaypoint = agent.WP6.transform.position;
        }
        else if(rdm == 6)
        {
            agent.nextWaypoint = agent.WP7.transform.position;
        }
        else if(rdm == 7)
        {
            agent.nextWaypoint = agent.WP8.transform.position;
        }
        else if(rdm == 8)
        {
            agent.nextWaypoint = agent.WP9.transform.position;
        }
    }
}
