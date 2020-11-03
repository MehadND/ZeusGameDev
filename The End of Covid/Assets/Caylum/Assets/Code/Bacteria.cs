using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bacteria : MonoBehaviour
{
    public class GameObject Bacteria
    public Rigidbody2D bacteria;
    public float speed = 3.0f;
    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnBacteria", 2);
    }
    void SpawnBacteria()
    {
        Rigidbody2D bacteriaInstance;
        bacteriaInstance = Instantiate(bacteria, new Vector3(UnityEngine.Random.Range(-5, 5), 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        bacteriaInstance.name = "Bacteria(Clone)";
        bacteriaInstance.velocity = new Vector2(speed, 0);
    }
    // Update is called once per frame
    void Update()
    {

    }
}