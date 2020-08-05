using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using roll_a_ball_helper;

public class createPickupsBalanceparenthesis : MonoBehaviour
{

    HelperClass HpClass = new HelperClass(); 
	public GameObject Cube ,floatingtext,man;
    private Vector3 position, Manposition;
	private bool canSpawnHere;
    private int count1,count; 

    private string gettext;
    private char[] myChars;
    private int open_bracket, Close_bracket;
    private bool equal;
    public string[] characters = new string[] { "(", "X", "E", "6", ")" };
    public string[] storeString;
    private int counter, endcount;
	void Start()
    {

        counter = 0;
        endcount = Random.Range(9, 12);
        storeString = new string[46];
        for (int i = 0; i <= 45; i++)
        {
            equal = false;
            while (equal == false)
            {
                for (int j = 0; j <= Random.Range(9, 15); j++)
                {
                    storeString[i] = storeString[i] + characters[Random.Range(0, characters.Length)];
                }
                if (counter != endcount)
                {
                    gettext = storeString[i];
                    myChars = gettext.ToCharArray();
                    for (int n = 0; n < myChars.Length; n++)
                    {
                        if (myChars[n] == '(')
                        {
                            open_bracket++;
                        }
                        else if (myChars[n] == ')')
                        {
                            Close_bracket++;
                        }
                        if (n == myChars.Length - 1)
                        {
                            if (open_bracket == Close_bracket)
                            {
                                equal = true;
                                gettext = "";
                                myChars = gettext.ToCharArray();
                                Close_bracket = 0;
                                open_bracket = 0;
                                counter++; 
                            }
                            else
                            {
                                storeString[i] = "";
                                gettext = "";
                                myChars = gettext.ToCharArray();
                                Close_bracket = 0;
                                open_bracket = 0; 
                            }
                        }
                    }
                }
                else
                {
                    equal = true;
                }
            }
        }


        createMan();
 
		for(int i=0;i<46;i++)
		{  
			while(!canSpawnHere){
                position = new Vector3(Random.Range(4.0F, 195.0F), 0.5f, Random.Range(4.0F, 195.0F));
                //Debug.Log(randomString);
                canSpawnHere = HpClass.checkSpawnPosition(position);
				count++;
				if(count==1000)
			{Debug.Log("break");
					break;
				}
			}
			if(canSpawnHere){
				GameObject go =Instantiate(Cube,position,Quaternion.identity)as GameObject;
				GameObject text =Instantiate(floatingtext,new Vector3(position.x,position.y+1.0f,position.z),Quaternion.identity)as GameObject;
				go.transform.SetParent(text.transform);
                text.GetComponent<TextMesh>().text = storeString[i];
				canSpawnHere=false;
			}


		}
	}


    void createMan()
    {
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