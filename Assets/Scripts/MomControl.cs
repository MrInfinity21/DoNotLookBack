using UnityEngine;
using UnityEngine.AI;

public class MomControl : MonoBehaviour
{
    private NavMeshAgent _momAgent;
    [SerializeField] private float _speed;
    private float _cooldown = 0;
    private float _timeToRetarget;

    [SerializeField] private Transform[] _shopPoints;
    [SerializeField] private float _minRetargetTIme;
    [SerializeField] private float _maxRetargetTIme;

    private void Start()
    {
        _momAgent = GetComponent<NavMeshAgent>();
        _momAgent.speed = _speed;
    }

    private void Update()
    {
        _cooldown += Time.deltaTime;

        if (_cooldown > _timeToRetarget)
        {
            SetDestination();

            float newTime = Random.Range(_maxRetargetTIme, _maxRetargetTIme);
            _timeToRetarget = newTime;
            _cooldown = 0f;
        }
    }

    public void SetDestination()
    {
        int destinationIndex = Random.Range(0, _shopPoints.Length - 1);
        _momAgent.SetDestination(_shopPoints[destinationIndex].position);
    }
}
