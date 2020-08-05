using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using roll_a_ball_helper;

public class createCubelvl2 : MonoBehaviour
{

    HelperClass HpClass = new HelperClass();
    public GameObject Cube, floatingtext,man;
    private Vector3 position,Manposition;
    private bool canSpawnHere;
    private int count1,count, strSize;
    private string randomString;
    private string[] randomStrings;
    void Start()
    {
        randomStrings = new string[46];
        for (int y = 0; y < 3; y++)
        {
            randomStrings[y] = HpClass.createPalindromeString(Random.Range(9, 15));
        }
        for (int y = 3; y < 46; y++)
        {
            int j = Random.Range(0, 2);
            if (j == 0)
            {
                randomStrings[y] = HpClass.createString(Random.Range(9, 15));
            }
            else
            {
                randomStrings[y] = HpClass.createPalindromeString(Random.Range(9, 15));
            }

        }
        createMan();
        for (int i = 0; i < 46; i++)
        {
            while (!canSpawnHere)
            {
                position = new Vector3(Random.Range(4.0F, 195.0F), 0.5f, Random.Range(4.0F, 195.0F));
                canSpawnHere = HpClass.checkSpawnPosition(position);
                count++;
                if (count == 1000)
                {
                    Debug.Log("break");
                    break;
                }
            }
            if (canSpawnHere)
            {
                GameObject go = Instantiate(Cube, position, Quaternion.identity) as GameObject;
                GameObject text = Instantiate(floatingtext, new Vector3(position.x, position.y + 1.0f, position.z), Quaternion.identity) as GameObject;
                go.transform.SetParent(text.transform);
                text.GetComponent<TextMesh>().text = randomStrings[i];
                canSpawnHere = false;
            }


        }
    }
    void createMan() {
        for (int i = 0; i < 50; i++)
        {
            while (!canSpawnHere)
            {
                Manposition = new Vector3(Random.Range(4.0F, 195.0F), 1.309756f, Random.Range(4.0F, 195.0F));
                canSpawnHere = HpClass.checkSpawnPosition(Manposition);
                count1++;
                if (count1 == 1000)
                {
                    Debug.Log("break");
                    break;
                }
            }
            if (canSpawnHere)
            {
                GameObject go = Instantiate(man, Manposition, Quaternion.identity) as GameObject;
               
                canSpawnHere = false;
            }


        }
    }

}