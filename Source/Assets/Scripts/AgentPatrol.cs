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

            if (Vector3.Distance(agent.NextWaypoint, agent.transform.position) <= 1)
            {
                agent.SelectNewWaypoint();
            }
            else
            {
                agent.Speed = 0.25f;
                agent.transform.LookAt(agent.NextWaypoint);
                agent.transform.Translate(new Vector3(0, 0, agent.Speed));
            }
        }
    }
}
