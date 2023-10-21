using System.Collections.Generic;
using UnityEngine;

class Lists : MonoBehaviour
{
    void Start()
    {
        List<Vector3> myFirstList = new();

        myFirstList.Add(new Vector3(1, 2, 3));
        myFirstList.Add(transform.position);
        myFirstList.Add(Vector3.up);

        Vector3 element = myFirstList[1];
        myFirstList[2] = Vector3.down;

        myFirstList.Remove(Vector3.down);
        myFirstList.RemoveAt(2);
        myFirstList.Insert(0, Vector3.right);

        bool doesContain = myFirstList.Contains(Vector3.zero);

        List<int> myIntList = new List<int>() { 1, 2, 5, 78, 23, 5, 9, 4, 23 };
        myFirstList.Sort();

        myFirstList.Clear();

        //-------------------------------------

        for (int i = 0; i < myFirstList.Count; i++)
        {
            Vector3 item = myFirstList[i];
            Debug.Log(item);
        }

        foreach (Vector3 item in myFirstList)
        {
            Debug.Log(item);
        }

    }
}
