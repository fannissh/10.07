using UnityEngine;

class AutoRotate : MonoBehaviour
{
    [SerializeField] float angularSpeed;
    [SerializeField] Space space = Space.World;

    

    void Update()
    {
        transform.Rotate(0, angularSpeed * Time.deltaTime, 0, space);
    }

    

}
