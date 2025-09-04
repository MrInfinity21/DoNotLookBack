using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform target;
    [SerializeField] private float angleThreshold = 5f; // smaller = more precise

    void Update()
    {
        Vector3 toTarget = (target.position - cameraTransform.position).normalized;
        float angle = Vector3.Angle(cameraTransform.forward, toTarget);

        if (angle < angleThreshold)
        {
            UserInterface.instance.IsLookingUpdate(true);
        }
        else
        {
            UserInterface.instance.IsLookingUpdate(false);
        }
    }
}
