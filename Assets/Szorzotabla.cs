using UnityEngine;

class Szorzotabla : MonoBehaviour
{

    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                Debug.Log($"{i} * {j} = {i * j}");
            }
        }
            
    

    }

   
}
