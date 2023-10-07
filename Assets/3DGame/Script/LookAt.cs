using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class LookAt : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 globalOffset;
    [SerializeField] Vector3 targetOffset;      // játékoshoz képesti kamera
    [SerializeField] float angularSpeed;        // simábban menjen a kamera

    void Update()
    {
        Vector3 targetpoint = GetTargetPoint();    // játékoshoz képesti kamera

        //transform.LookAt(targetpoint);      // kamera velünk forogjon


        Vector3 dir = targetpoint - transform.position;             // kamera velünk forogjon
        Quaternion targetRotation = Quaternion.LookRotation(dir);   // kamera velünk forogjon

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed * Time.deltaTime);    // simábban menjen a kamera


    }

    Vector3 GetTargetPoint()
    {
        Vector3 targetpoint = target.position;
        targetpoint += globalOffset;
        targetpoint += target.TransformVector(targetOffset);
        return targetpoint;
    }

    void OnDrawGizmosSelected()
    {
        Vector3 targetpoint = GetTargetPoint();

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetpoint, 0.6f);

    }
}
