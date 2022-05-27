using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField] string name;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayBGM(name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
