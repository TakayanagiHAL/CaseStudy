using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    float t = 0;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        t += 0.003f;
        image.color = new Color(1, 1, 1, (Mathf.Cos(t) * 75 + 180)/255.0f);
    }
}
