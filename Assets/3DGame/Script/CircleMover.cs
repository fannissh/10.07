using UnityEngine;

[ExecuteAlways]
class CircleMover : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Transform movedObject;

    [Space]
    [SerializeField] Vector3 center;
    [SerializeField] float radius = 10;
    [SerializeField] int segmentCount = 50;

    [Space]
    [SerializeField] float angularSpeed = 90;
    [SerializeField] float minAngle = 0;
    [SerializeField] float maxAngle = 180;

    [SerializeField] float currentAngle;

    [Space]
    [SerializeField] bool lookOutside;

    void Update()
    {
        lineRenderer.positionCount = segmentCount;

        for (int i = 0; i < segmentCount; i++)
        {
            float angle = i * 360f / segmentCount;
            Vector3 point = GetPointToAngel(angle);
            lineRenderer.SetPosition(i, point);
        }

        float input = Input.GetAxis("Horizontal");
        currentAngle += input * angularSpeed * Time.deltaTime;

        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

        movedObject.position = GetPointToAngel(currentAngle);

        if(lookOutside)
        {
            Vector3 lookDirection = movedObject.position - center;
            movedObject.rotation = Quaternion.LookRotation(lookDirection);
        }
    }

    Vector3 GetPointToAngel(float angle)
    {
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = Mathf.Sin(angle * Mathf.Deg2Rad);

        Vector3 result = new(x, 0, y);
        result *= radius;
        result += center;

        return result;
    }
}
