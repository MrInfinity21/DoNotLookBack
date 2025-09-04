using UnityEngine;
using UnityEngine.AI;

public class MomControl : MonoBehaviour
{
    private NavMeshAgent _momAgent;

    private void Start()
    {
        _momAgent = GetComponent<NavMeshAgent>();
    }


}
