using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeUI : MonoBehaviour
{
    [SerializeField] Image[] bable;
    [SerializeField] bubble_burst[] burstObjs;
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
        if (life <= 0) return;

        life--;
        bable[life].enabled = false;
        burstObjs[life].StartAnime();
    }
    public int GetLife()
    {
        return life;
    }
}
