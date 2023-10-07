using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class LookAt : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 globalOffset;
    [SerializeField] Vector3 targetOffset;      // j�t�koshoz k�pesti kamera
    [SerializeField] float angularSpeed;        // sim�bban menjen a kamera

    void Update()
    {
        Vector3 targetpoint = GetTargetPoint();    // j�t�koshoz k�pesti kamera

        //transform.LookAt(targetpoint);      // kamera vel�nk forogjon


        Vector3 dir = targetpoint - transform.position;             // kamera vel�nk forogjon
        Quaternion targetRotation = Quaternion.LookRotation(dir);   // kamera vel�nk forogjon

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed * Time.deltaTime);    // sim�bban menjen a kamera


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
