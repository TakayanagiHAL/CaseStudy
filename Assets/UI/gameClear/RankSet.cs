using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankSet : MonoBehaviour
{
    Timer timer;
    [SerializeField] Sprite[] ranks;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        int r = 0;
        if (timer.time > 15.0f)
        {
            r++;
            if (timer.time > 20.0f)
            {
                r++;
                if (timer.time > 30.0f)
                {
                    r++;
                }
            }
        }

        image.sprite = ranks[r];
    }
}
