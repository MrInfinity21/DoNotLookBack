using UnityEngine;
using UnityEngine.AI;

public class NpcControl : MonoBehaviour
{
    private NavMeshAgent _npcAgent;
    private float _retargetTime;
    [SerializeField] private float _retargetCooldown;

    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    private void Start()
    {
        _npcAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _retargetTime += Time.deltaTime;

        if (_retargetTime > _retargetCooldown)
        {
            SetNewDestination();
            _retargetTime = 0f;

            float newSpeed = Random.Range(_minSpeed, _maxSpeed);
            _npcAgent.speed = newSpeed;
        }
    }

    private void SetNewDestination()
    {
        _npcAgent.SetDestination(NewLocation());
    }

    Vector3 NewLocation()
    {
        Vector3 minBounds = new Vector3(-10f, 0f, -10f);
        Vector3 maxBounds = new Vector3(10f, 5f, 10f);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);
        float randomZ = Random.Range(minBounds.z, maxBounds.z);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        return randomPosition + transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        SetNewDestination();
    }
}
