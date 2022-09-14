using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = 42;
        int y = 105;
        int g = example.gcd(x, y);
        Debug.Log("The gcd of " + x + " and " + y + " is " + g);

        // Manipulate the Foo global variable

        // Output its current value
        Console.WriteLine("Foo = " + example.Foo);

        // Change its value
        example.Foo = 3.1415926;

        // See if the change took effect
        Debug.Log("Foo = " + example.Foo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
