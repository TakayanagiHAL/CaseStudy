using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPrefabManager : MonoBehaviour
{
    [SerializeField] GameObject[] EffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EffectNumON(int num)
    {
        if (num >= EffectPrefab.Length) return;

        EffectPrefab[num].GetComponent<EffectPrefab>().EffectON();
    }
}
