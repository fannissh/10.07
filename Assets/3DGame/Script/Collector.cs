using UnityEngine;

public class Collector : MonoBehaviour
{
    int collectedValue = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Collectable collectable))
        {
            collectedValue += collectable.GetValue();
            collectable.Teleport();



        }
            


    }


}
