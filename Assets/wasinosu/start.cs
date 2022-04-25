using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerObj;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(PlayerObj, transform.position, Quaternion.identity);
        //PlayerObj.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
