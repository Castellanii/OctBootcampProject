using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello : MonoBehaviour
{
    public int numberVariable; //Variable declaration
    public bool isDoingSomething = false;   //Variable initialization
    public float speed = 10.0f;
    public string name = "Ot";

    public Transform cubeTransform;
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        isDoingSomething=true; //Variable assignment
        Debug.Log("Hello from Start");
        Debug.Log("The new variables are " + this);

        cubeTransform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("The number variable is: " + numberVariable);
        
        cubeTransform.Translate(Vector3.forward);

    }
}
