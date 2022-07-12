using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class character : MonoBehaviour
{
    [SerializeField] float Width;
    [SerializeField] int Speed;
    float count = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        count += 0.01f;

        transform.position += new Vector3(0.0f, Mathf.Sin(count) * Width, 0.0f);
    }

 
}
