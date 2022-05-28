using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bubble_burst : MonoBehaviour
{
    private Animator animeter;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        animeter = GetComponent<Animator>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnime()
    {
        image.enabled = true;
        animeter.SetBool("burst", true);
    }
    
    public void EndAnime()
    {
        animeter.SetBool("burst", false);
        image.enabled = false;
    }
}
