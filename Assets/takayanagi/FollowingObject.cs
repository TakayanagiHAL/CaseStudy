using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingObject : MonoBehaviour
{
    [SerializeField] GameObject followPrefab;
    [SerializeField] bool followScale;
    [SerializeField] bool followRotate;
    [SerializeField] bool followPosition;
    GameObject followObj;
    // Start is called before the first frame update
    void Start()
    {
        followObj = Instantiate(followPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if(followRotate)
        {
            followObj.transform.rotation = transform.rotation;
        }

        if (followPosition)
        {
            followObj.transform.position = transform.position;
        }

        if (followScale)
        {
            followObj.transform.localScale = transform.localScale;
        }
    }
    
    public void Delete()
    {
        Destroy(followObj);
    }
}
