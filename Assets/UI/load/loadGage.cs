using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class loadGage : MonoBehaviour
{
    [SerializeField] GameObject start;
    [SerializeField] GameObject goal;
    [SerializeField] GameObject player;
    [SerializeField] Slider slider;
    float maxLoad = 0.0f;

    [SerializeField] GameObject[] checkPoints;

    // Start is called before the first frame update
    void Start()
    {
        if (checkPoints.Length > 0)
        {
            //チェックポイントあり
            int pointLength = checkPoints.Length;
            Debug.Log(pointLength);
            Vector3 dis = goal.transform.position - checkPoints[pointLength - 1].transform.position;
            maxLoad = dis.magnitude;
            for(int i = 0; i < pointLength - 1;i++)
            {
                dis = checkPoints[i].transform.position - checkPoints[i + 1].transform.position;
                maxLoad += dis.magnitude;
            }
            dis = checkPoints[0].transform.position - start.transform.position;
            maxLoad += dis.magnitude;
        }
        else
        {
            //チェックポイントなし
            Vector3 dis = goal.transform.position - start.transform.position;
            maxLoad = dis.magnitude;
        }
        Debug.Log(maxLoad);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dis = goal.transform.position - player.transform.position;

        float distance = GetProgress(player.transform.position);//dis.magnitude;
        Debug.Log(1.0f - (distance / maxLoad));

        slider.value = distance / maxLoad;
    }

    float GetProgress(Vector3 PlayerPosition)
    {
        //各ポイントを配列に格納
        Vector3[] Points = new Vector3[checkPoints.Length + 2];
        Points[0] = start.transform.position;
        for(int i = 0; i < checkPoints.Length;i++)
        {
            Points[i + 1] = checkPoints[i].transform.position;
        }
        Points[checkPoints.Length + 1] = goal.transform.position;

        //プレイヤーから一番近い点を取得
        Vector3 nearPoint = new Vector3(0f,0f,0f);
        float distance;
        float minDistance = 1000;
        int near = 0;
        for(int i = 0; i < checkPoints.Length + 2;i++)
        {
            distance = Vector3.Distance(PlayerPosition, Points[i]);
            if(distance < minDistance)
            {
                minDistance = distance;
                nearPoint = Points[i];
                near = i;
            }
        }
        Debug.Log(nearPoint);

        if(nearPoint == Points[0])
        {
            Vector3 line = Points[1] - Points[0];
            float length = line.magnitude;
            line.Normalize();

            float dot = Vector3.Dot(PlayerPosition - Points[0], line);
            dot = Mathf.Clamp(dot, 0, length);
            Vector3 progress = Points[0] + dot * line;

            return Vector3.Distance(Points[0], progress);
        }
        else if(nearPoint == Points[checkPoints.Length + 1])
        {
            Vector3 line = Points[checkPoints.Length + 1] - Points[checkPoints.Length];
            float length = line.magnitude;
            line.Normalize();

            float dot = Vector3.Dot(PlayerPosition - Points[checkPoints.Length], line);
            dot = Mathf.Clamp(dot, 0, length);
            Vector3 progress = Points[checkPoints.Length] + dot * line;

            float remaining = length - Vector3.Distance(Points[checkPoints.Length], progress);

            return maxLoad - remaining;
        }
        else
        {
            //線A
            Vector3 lineA = Points[near + 1] - Points[near];
            float lengthA = lineA.magnitude;
            lineA.Normalize();
            float dotA = Vector3.Dot(PlayerPosition - Points[near], lineA);
            dotA = Mathf.Clamp(dotA, 0, lengthA);
            Vector3 progressA = Points[near] + dotA * lineA;
            float disA = Vector3.Distance(progressA, PlayerPosition);

            //線B
            Vector3 lineB = Points[near] - Points[near - 1];
            float lengthB = lineB.magnitude;
            lineB.Normalize();
            float dotB = Vector3.Dot(PlayerPosition - Points[near - 1], lineB);
            dotB = Mathf.Clamp(dotB, 0, lengthB);
            Vector3 progressB = Points[near - 1] + dotB * lineB;
            float disB = Vector3.Distance(progressB, PlayerPosition);

            if(disA < disB)
            {
                float load = 0.0f;
                for(int i = 0; i < near; i++)
                {
                    load += Vector3.Distance(Points[i], Points[i + 1]);
                }
                load += Vector3.Distance(Points[near], progressA);

                return load;
            }
            else
            {
                float load = 0.0f;
                for (int i = 0; i < near - 1; i++)
                {
                    load += Vector3.Distance(Points[i], Points[i + 1]);
                }
                load += Vector3.Distance(Points[near - 1], progressB);

                return load;
            }
        }
    }
}
