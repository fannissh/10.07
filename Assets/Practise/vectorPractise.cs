using UnityEngine;

class vectorPractise : MonoBehaviour
{

    void Start()
    {
        Vector2 v2_a = new Vector2();       // (0, 0)
        Vector3 v3_a = new Vector3();       // (0, 0, 0)
        Vector2 v2_b = new Vector2(1, 2);    // (1, 2)
        Vector3 v3_b = new Vector3(3, 4);   // (3, 4, 0)
        Vector3 v3_c = new Vector3(3, 4, 5);

        Vector2 v2_c = new Vector2();
        Vector2 v2_d = new Vector2();
        var v2_e = new Vector2();

        Debug.Log(v3_a);
        Debug.Log(v2_c);
        Debug.Log(v2_d);
        Debug.Log(v2_e);

        Vector2 v2_f = v2_a + v2_b;     // (1, 2)
        Vector2 v2_g = v2_a - v2_b;     // (-1, -2)
        Vector2 v2_h = v2_b * 3;        // (3, 6)
        Vector2 v2_i = v2_b / 2;        // (0.5f, 1)

        float lenght = v2_i.magnitude;
        float lenght2 = v2_i.sqrMagnitude;

        Vector2 v2_j = v2_i.normalized;   
        
        v2_i.Normalize();






    }

    
}
