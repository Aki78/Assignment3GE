using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    {
        print("Agent's starting position: " + transform.position);
    }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            print("updating");
            SetAgentDestinationToClickedPoint();
        }
    }

    void SetAgentDestinationToClickedPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            if (NavMesh.SamplePosition(hit.point, out var navHit, 1.0f, NavMesh.AllAreas))
            {
                agent.SetDestination(navHit.position);
            }
        }
    }
    void ActivateAgent()
    {
        GetComponent<NavMeshAgent>().enabled = true;
    }

}
