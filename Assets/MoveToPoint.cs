using UnityEngine;
using UnityEngine.AI;

public class MoveToClickOnNavMesh : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickedPosition = GetClickedPositionOnNavMesh();
            print(clickedPosition);

            if(clickedPosition != Vector2.zero)  
            {
                agent.SetDestination(clickedPosition);
            }
        }
    }

    Vector3 GetClickedPositionOnNavMesh()
    {
        Vector3 clickedWorldPosition = new Vector3(Input.mousePosition.x, 1000f, Input.mousePosition.y);
        Ray ray = new Ray(clickedWorldPosition, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            NavMeshHit navMeshHit;
            if (NavMesh.SamplePosition(hit.point, out navMeshHit, 10.0f, NavMesh.AllAreas))
            {
                return navMeshHit.position;
            }
        }

        return Vector3.zero;  
    }
}
