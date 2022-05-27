using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //[SerializeField] Text text;
    [SerializeField] Image num100;
    [SerializeField] Image num10;
    [SerializeField] Image num1;
    [SerializeField] Image num_1;
    [SerializeField] Image num_01;

    [SerializeField] Sprite[] number;
 
    public float time;
    public bool timerOn = true;
    private int IntTime;
    private string StringInt;
    private int DecimalTime;
    private string StringDecimal;

    private void Awake()
    {
        // Subscribe to the gamestate manager
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        // Unsubscribe to the gamestate manager to prevent memory leaks
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (time < 1000.0f)
            {
                time += Time.deltaTime;
                IntTime = (int)time;
                DecimalTime = (int)((time - (int)time) * 100);
                StringInt = IntTime.ToString("000");
                StringDecimal = DecimalTime.ToString("00");
                Debug.Log(StringInt);
                Debug.Log(int.Parse(StringInt[0].ToString()));

                num100.sprite = number[int.Parse(StringInt[0].ToString())];
                num10.sprite = number[int.Parse(StringInt[1].ToString())];
                num1.sprite = number[int.Parse(StringInt[2].ToString())];

                num_1.sprite = number[int.Parse(StringDecimal[0].ToString())];
                num_01.sprite = number[int.Parse(StringDecimal[1].ToString())];
            }
        }
    }

    private void OnGameStateChanged(GAME_STATE newGameState)
    {
        timerOn = newGameState == GAME_STATE.GAMEPLAY;
    }
}
