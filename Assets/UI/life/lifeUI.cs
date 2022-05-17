using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeUI : MonoBehaviour
{
    [SerializeField] Image[] bable;
    int life;
    // Start is called before the first frame update
    void Start()
    {
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LifeUp()
    {
        if (life == 3) return;

        life++;
        bable[life - 1].enabled = true;
    }
    public void LifeDown()
    {
        life--;
        bable[life].enabled = false;
    }
}
