using UnityEngine;
using System.Collections;

class AgentReceding : AgentStatesHandler
{
    float fleeDelay = 0;

    public override void Handle(Agent agent)
    {
        AI(agent);
    }

    void AI(Agent agent)
    {
        // see Player and fleet
        if ( agent.DistanceToPlayer <= agent.AgentViewrange)
        {
            agent.transform.LookAt(new Vector3(agent.playerPos.x + 180, agent.playerPos.y + 180, 0));
            agent.Speed = 0.95f;
            agent.transform.Translate(new Vector3(0, 0, agent.Speed));
             // when Hit from Player
            if( agent.DistanceToPlayer <= agent.AgentReach)
            {
                agent.Health -= 1 * Time.deltaTime;
            }
            fleeDelay = 10;
        }
        // flee delay
        else if (fleeDelay >= 0)
        {
            agent.transform.Translate(new Vector3(0, 0, agent.Speed));
            agent.Speed = 0.8f;

            fleeDelay -= 1 * Time.deltaTime;
        }
       
        else
        {
            agent.AgentViewrange = 10;

            if (Vector3.Distance(agent.nextWaypoint, agent.transform.position) <= 1)
            {
                WaypointSelection(agent);
            }
            else
            {
                agent.Speed = 0.4f;
                //if()//////////////////////////////////////////
                agent.transform.LookAt(agent.nextWaypoint);
                agent.transform.Translate(new Vector3(0, 0, agent.Speed));
            }
        }
    }
    void WaypointSelection(Agent agent)
    {
        int rdm = Random.Range(0, 8);

        if (rdm == 0)
        {
            agent.nextWaypoint = agent.WP1.transform.position;
        }
        else if (rdm == 1)
        {
            agent.nextWaypoint = agent.WP2.transform.position;
        }
        else if (rdm == 2)
        {
            agent.nextWaypoint = agent.WP3.transform.position;
        }
        else if (rdm == 3)
        {
            agent.nextWaypoint = agent.WP4.transform.position;
        }
        else if (rdm == 4)
        {
            agent.nextWaypoint = agent.WP5.transform.position;
        }
        else if (rdm == 5)
        {
            agent.nextWaypoint = agent.WP6.transform.position;
        }
        else if (rdm == 6)
        {
            agent.nextWaypoint = agent.WP7.transform.position;
        }
        else if (rdm == 7)
        {
            agent.nextWaypoint = agent.WP8.transform.position;
        }
        else if (rdm == 8)
        {
            agent.nextWaypoint = agent.WP9.transform.position;
        }
    }
}
