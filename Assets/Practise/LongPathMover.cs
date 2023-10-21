using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
public class LongPathMover : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform movedObject;

    List<Transform> path = new();
    Transform nextTarget;
    bool positiveDirection = true;

    void Start()
    {
        FindPoints();
        movedObject.position = path[0].position;
        nextTarget = path[1];

        Debug.Log(nextTarget);
    }

    void Update()
    {
        FindPoints();

        if (Application.isPlaying)
        {
            Move();
        }
    }

    void FindPoints()
    {
        path.Clear();
        for (int i = 0; i < transform.childCount; i++)
            path.Add(transform.GetChild(i));
    }

    void Move()
    {
        movedObject.position = Vector3.MoveTowards(movedObject.position, nextTarget.position, speed * Time.deltaTime);

        if (nextTarget.position == movedObject.position)
        {
            int currentIndex = path.IndexOf(nextTarget);

            if(positiveDirection)
            {
                if(nextTarget == path[^1]) 
                    positiveDirection= false;                
            }
            else
            {
                if(nextTarget == path[0])
                    positiveDirection= true;
            }

            int nextIndex = currentIndex + (positiveDirection ? 1 : -1);
            nextTarget = path[nextIndex];

            //if (positiveDirection)                    // ugyanaz mint fölötte
            //	nextTarget = path[currentIndex + 1];
            //else
            //	nextTarget = path[currentIndex - 1];
        }
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < path.Count - 1; i++)
        {
            Vector3 p1 = path[i].position;
            Vector3 p2 = path[i + 1].position;

            Gizmos.DrawLine(p1, p2);
        }
    }
}
