using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class loadGage : MonoBehaviour
{
    [SerializeField] GameObject start;
    [SerializeField] GameObject goal;
    [SerializeField] GameObject player;
    [SerializeField] Slider slider;
    float maxLoad;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 dis = goal.transform.position - start.transform.position;

        maxLoad = dis.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dis = goal.transform.position - player.transform.position;

        float distance = dis.magnitude;

        slider.value = 1.0f - (distance / maxLoad);
    }
}
