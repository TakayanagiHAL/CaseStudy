using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCut : MonoBehaviour
{
    [SerializeField] float deg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0,0,deg);
    }
}
