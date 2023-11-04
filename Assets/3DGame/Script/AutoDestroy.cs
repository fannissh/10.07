using System.Collections;
using UnityEngine;

class AutoDestroy : MonoBehaviour
{
    [SerializeField] float lifeTime = 5;
    [SerializeField] float maxDistance = 10;
    [SerializeField] bool destroyOnCollision;

    Vector3 startPos;

    void Start()
    {
        StartCoroutine(MyCoroutine());
        startPos = transform.position;

    }
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);

    }

    void Update()
    {
        Vector3 cp = transform.position;
        bool isOutSideOfRange = Vector3.Distance(cp, startPos) > maxDistance;

        if(isOutSideOfRange)
        {
            Destroy(gameObject);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (destroyOnCollision)
            Destroy(gameObject);

    }
}