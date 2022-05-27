using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Sprite[] numSprites;

    private float timer = 3.0f;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        GameStateManager.Instance.SetState(GAME_STATE.GAMESTART);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            image.sprite = numSprites[(int)timer];
        }
        else
        {
            GameStateManager.Instance.SetState(GAME_STATE.GAMEPLAY);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
