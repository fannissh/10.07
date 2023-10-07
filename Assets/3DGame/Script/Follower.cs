using UnityEngine;

class Follower : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform target;

    void Update()
    {
        Vector3 followerPosition = transform.position;
        Vector3 targetPosition = target.position;

        Vector3 direction = (targetPosition - followerPosition).normalized;
        // Vector3 velocity = speed * direction;
        // transform.position += velocity * Time.deltaTime;

        transform.position = Vector3.MoveTowards(followerPosition, targetPosition, speed * Time.deltaTime);// honnan, hova, milyen sebességgel

        if(direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
        
    }
}
