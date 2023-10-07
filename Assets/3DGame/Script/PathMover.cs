using UnityEngine;

class PathMover : MonoBehaviour
{
    [SerializeField] Transform T1, T2;
    [SerializeField] float speed = 5;

    [SerializeField] Color c1, c2;

    [SerializeField, Range(0,1)] float startPositionRate = 0.5f;

    Vector3 targetPoint;

    void OnValidate()
    {
        // transform.position = (T1.position + T2.position) / 2;                       // egybõl rááll a kezdõpontra (t1)
        transform.position = Vector3.Lerp(T1.position, T2.position, startPositionRate);  // mozgathatjuk a csúszkán                                                      
    }

    void Start()
    {     
        
        targetPoint = T2.position; // onnan indul ahonnan beállítottam
    }


    void Update()
    {        
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime); // rakja rá a pontra

        if (transform.position == targetPoint) // végtelenségig oda-vissza mozog
        {
            if(targetPoint == T1.position)
                targetPoint = T2.position;
            else
                targetPoint = T1.position; //
        }
    }
    void OnDrawGizmos()
        {
            if (T1 == null || T2 == null)
                return;

            Vector3 p1 = T1.position;
            Vector3 p2 = T2.position;

        
            Gizmos.color = c1;                  // mutatja melyik szín felé haladok
            Gizmos.DrawWireSphere(p1, 0.2f);

            Gizmos.color = c2;
            Gizmos.DrawWireSphere(p2, 0.2f);

        // Gizmos.color = targetPoint == p1 ? c1 : c2;
            Gizmos.color = Color.Lerp(c1, c2, startPositionRate);       // Lerp: keverés
            Gizmos.DrawLine(p1, p2);
        }
    
}
