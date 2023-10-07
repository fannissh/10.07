using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazi2 : MonoBehaviour
{
    [SerializeField] int number = 100;

    void Start()
    {
        
        for (int i = 1; i <= number; i++)
        {
            bool fizz = i % 3 == 0;
            bool buzz = i % 5 == 0;
            bool fizzBuzz = fizz && buzz;


            if (fizzBuzz)
            {
                Debug.Log("FizzBuzz");
            }
            else if (fizz)
            {
                Debug.Log("Fizz");
            }
            else if (buzz)
            {
                Debug.Log("Buzz");
            }
            else
            {
                Debug.Log(i);
            }


               
        }
    }

    
}
