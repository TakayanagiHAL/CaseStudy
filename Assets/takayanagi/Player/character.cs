using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    [SerializeField] float startRadian;

    [SerializeField] float caryerDistance;

    float radian;

    float power;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = CalcPosition();

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = CalcPosition();
    }

    Vector2 CalcPosition()
    {
        Vector2 pos;

        pos.x = caryerDistance * Mathf.Cos(radian);
        pos.y = caryerDistance * Mathf.Sin(radian);

        return pos;
    }
}
