using UnityEngine;
using System.Collections;

public class agentControllerP3 : MonoBehaviour
{

    NavMeshAgent agent;
    public GameObject des;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = des.transform.position; 
    }

    void Update()
    {

    }


}
