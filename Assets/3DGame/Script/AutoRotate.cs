using UnityEngine;

class AutoRotate : MonoBehaviour
{
    [SerializeField] float angularSpeed;

    

    void Update()
    {
        transform.Rotate(0, angularSpeed * Time.deltaTime, 0);
    }

    

}
