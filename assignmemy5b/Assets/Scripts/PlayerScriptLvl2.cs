using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using roll_a_ball_helper;

public class PlayerScriptLvl2 : MonoBehaviour {
    HelperClass HPclass = new HelperClass();
	
	public Transform player;
	public float speed;
	public GameObject RightExplosionPartical,WrongExplosionPartical;
	public Text cubeCountText;
	public Text score;
	public GameObject completeLevelUI;
	public AudioSource audioSource ,audioNo;

	private Vector3 position;
	private Rigidbody rb;
	private int count ,balanceStringsCount;
	private bool canSpawnHere; 
	private bool isBalanceString;
	private int cubeCount ;
   
	void Start ()
    {
        
		rb = GetComponent<Rigidbody>(); 
		count = 0;
		cubeCount=46;
		balanceStringsCount=0; 

	}
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed);
	}
	void Update () {
		GameObject[] thingyToFind = GameObject.FindGameObjectsWithTag ("PickUp");
		cubeCount = thingyToFind.Length; 
		cubeCountText.text="Cubes Left: "+cubeCount; 
	}
    bool BalanceStringsLeft(GameObject[] cubes)
    {
     
        for (int i = 0; i < cubes.Length; i++)
        {
            string str = cubes[i].transform.parent.gameObject.GetComponent<TextMesh>().text;
           
            if (HPclass.checkBalanceParenthesis(str.Trim()))
            {
                return true;
               
            }
        } 
           return false; 
 
    }
	 
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("PickUp"))
		{

			string str=other.transform.parent.gameObject.GetComponent<TextMesh>().text;

            if (HPclass.checkBalanceParenthesis(str.Trim()))
			{
                other.transform.parent.gameObject.SetActive(false);
				audioSource.Play();
				isBalanceString=true;
				balanceStringsCount=balanceStringsCount+1;

			}else{
				isBalanceString=false;
				audioNo.Play();
			}
			Explode(other.gameObject.transform.position , isBalanceString); 
			objectCount();
				 
		}  
	}
    void Explode(Vector3 Explosionposition, bool isBalanceString)
    {
        if (isBalanceString)
        {
			GameObject firework = Instantiate(RightExplosionPartical, Explosionposition, Quaternion.identity);
			firework.GetComponent<ParticleSystem>().Play();
		}else{
			GameObject firework = Instantiate(WrongExplosionPartical, Explosionposition, Quaternion.identity);
			firework.GetComponent<ParticleSystem>().Play();
		}
	}
	void objectCount ()
	{
        GameObject[] thingyToFind = GameObject.FindGameObjectsWithTag("PickUp"); 
        if (!BalanceStringsLeft(thingyToFind))
		{
			score.text=balanceStringsCount+"";
			completeLevelUI.SetActive(true); 
		}
	}
	 
 }
