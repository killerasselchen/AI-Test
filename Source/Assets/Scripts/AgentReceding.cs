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
                agent.SelectNewWaypoint();
            }
            else
            {
                agent.Speed = 0.4f;
                //if() Agents search to became help
                agent.transform.LookAt(agent.NextWaypoint);
                agent.transform.Translate(new Vector3(0, 0, agent.Speed));
            }
        }
    }
}
