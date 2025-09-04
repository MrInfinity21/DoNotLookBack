using UnityEngine;
using UnityEngine.AI;

public class MomControl : MonoBehaviour
{
    private NavMeshAgent _momAgent;
    [SerializeField] private float _speed;

    private void Start()
    {
        _momAgent = GetComponent<NavMeshAgent>();
        _momAgent.speed = _speed;
    }


}
