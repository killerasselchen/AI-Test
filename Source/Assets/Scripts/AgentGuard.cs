using UnityEngine;
using System.Collections;

class AgentGuard : AgentStatesHandler 
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

            agent.AgentSeeYou = true;
            agent.AgentIsAtStartPos = false;

            if (agent.DistanceToPlayer <= agent.AgentReach)
            {
                agent.transform.LookAt(agent.playerPos);
                agent.AgentAttack = true;
            }
            else
            {
                agent.Speed = 0.6f;
                agent.transform.LookAt(agent.playerPos);
                agent.transform.Translate(0, 0, agent.Speed);
                agent.AgentAttack = false;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Q))
                {
                    agent.State = new AgentPatrol();
                }
        else
        {
            agent.AgentSeeYou = false;
            agent.AgentAttack = false;
            agent.AgentViewrange = 10;

            if (Vector3.Distance(agent.agentStartPos, agent.transform.position) >= 1)
            {
                agent.Speed = 0.5f;
                agent.transform.LookAt(agent.agentStartPos);
                agent.transform.Translate(0, 0, agent.Speed);
            }
            else
            {
                agent.AgentIsAtStartPos = true;
            }
        }
    }
}
