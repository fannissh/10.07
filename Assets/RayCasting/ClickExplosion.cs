using System;
using UnityEngine;

class ClickExplosion : MonoBehaviour
{
    [SerializeField] Transform cursor3D;
    [SerializeField] LayerMask mask;
    [SerializeField] ParticleSystem explosionEffect;
    [SerializeField] MeshRenderer cursorRenderer;
    [SerializeField] AudioSource soundEffect;


    [SerializeField] float range = 10;
    [SerializeField] float maxImpulse = 10;

    void Update()
    {
        Camera cam = Camera.main;
        Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit hit, float.MaxValue, mask))
        {
            cursor3D.position = hit.point;

            if (Input.GetMouseButtonDown(0))
            {
                DoExplosion(hit.point);

                if(explosionEffect != null)
                explosionEffect.Play();

                if(soundEffect != null)
                soundEffect.Play();
            }

            cursorRenderer.enabled = true;
        }
        else
        {
            cursorRenderer.enabled = false;
        }
    }

    void DoExplosion(Vector3 explosionPoint)
    {
        Rigidbody[] rigidBodies = FindObjectsOfType<Rigidbody>();

        for (int i = 0; i < rigidBodies.Length; i++)
        {
            Rigidbody rb = rigidBodies[i];
            Vector3 rigidBodyPoint = rb.position;

            Vector3 direction = rigidBodyPoint - explosionPoint;
            float distance = direction.magnitude;

            if (distance < range)
            {
                direction.Normalize();

                float r = 1 - (distance / range);
                float impulseValue = maxImpulse * r;
                Vector3 impulse = direction * impulseValue;

                // rb.AddForce(force, ForceMode.Impulse);
                rb.velocity += impulse / rb.mass;
            }
        }
    }
}