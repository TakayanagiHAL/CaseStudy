using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class StringToImage : MonoBehaviour
{
    public enum SUUJI
    {
        zero,
        one,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine
    }

    public Sprite[] sprites;
    public Image[] images;
    public Timer timer;
    public float timerValue;

    private string timerAsString;
    private string[] splitString;

    private void Start()
    {
    }

    private void Update()
    {
        timerValue = timer.time;
        splitString = new string[6];
        // Get the float timer as string
        timerAsString = timerValue.ToString("000.00");

        // Separate string into each individual char
        for (int i = 0; i < timerAsString.Length; i++)
        {
            splitString[i] = timerAsString[i].ToString();
        }

        for (int i = 0; i < images.Length; i++)
        {
            if (i == 3)
                continue;
            // Parse the numbers in the string
            int number;
            number = int.Parse(splitString[i]);

            switch ((SUUJI)number)
            {
                case SUUJI.zero:
                    images[i].sprite = sprites[0];
                    break;
                case SUUJI.one:
                    images[i].sprite = sprites[1];
                    break;
                case SUUJI.two:
                    images[i].sprite = sprites[2];
                    break;
                case SUUJI.three:
                    images[i].sprite = sprites[3];
                    break;
                case SUUJI.four:
                    images[i].sprite = sprites[4];
                    break;
                case SUUJI.five:
                    images[i].sprite = sprites[5];
                    break;
                case SUUJI.six:
                    images[i].sprite = sprites[6];
                    break;
                case SUUJI.seven:
                    images[i].sprite = sprites[7];
                    break;
                case SUUJI.eight:
                    images[i].sprite = sprites[8];
                    break;
                case SUUJI.nine:
                    images[i].sprite = sprites[9];
                    break;
            }
        }        
    }
}
