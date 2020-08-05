using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.EventSystems;
public class menuController: MonoBehaviour
{
    public GameObject panel1, panel1_1, panel2_1, panel2_1_1, panel2_1_1_1, panel2_1_2, panel2_1_2_1, panel3_1, panel4_1;

    public void btnClick() {//SceneManager.LoadScene(1);
        string name = EventSystem.current.currentSelectedGameObject.name;
        if (name == "btnMlagents")
        {
            panel1.SetActive(false);
            panel1_1.SetActive(true);
        }
        else if (name == "btnpenguin")
        {
            SceneManager.LoadScene(1);
        }
        else if (name == "btnhummingBird")
        {
            SceneManager.LoadScene(2);
        }
        else if (name == "return1")
        {
            panel1.SetActive(true);
            panel1_1.SetActive(false);
        }
        else if (name == "computational_Model")
        {

            panel1.SetActive(false); 
            panel2_1.SetActive(true);
        }
        else if (name == "btnPalindrome")
        {
            panel2_1.SetActive(false);
            panel2_1_1.SetActive(true);
        }
        
        else if(name == "btnPlanguge"){

            panel2_1_1.SetActive(false);
            panel2_1_1_1.SetActive(true);
        }
            else if(name == "return2_1_1_1"){
             panel2_1_1.SetActive(true);
            panel2_1_1_1.SetActive(false);
            }
        else if(name == "btnPalidinworld"){

            panel2_1_1.SetActive(false);
            SceneManager.LoadScene(3);
        }
        else if(name == "return2_1_1"){

            panel2_1_1.SetActive(false);
            panel2_1.SetActive(true);
        }





        else if (name == "btnmatchingbrackets")
        {
            panel2_1.SetActive(false);
            panel2_1_2.SetActive(true);
        }

        else if (name == "btnbraketLanguage")
        {

            panel2_1_2.SetActive(false);
            panel2_1_2_1.SetActive(true);
        }
        else if (name == "return2_1_2_1")
        {
            panel2_1_2.SetActive(true);
            panel2_1_2_1.SetActive(false);
        }
        else if (name == "btnbracketworld")
        {
            panel2_1_2.SetActive(false);
            SceneManager.LoadScene(4);

        }
        else if (name == "return2_1_2")
        {
            panel2_1_2.SetActive(false);
            panel2_1.SetActive(true);

        }



        else if (name == "return2_1")
        {
            panel2_1.SetActive(false);
            panel1.SetActive(true);

        }
        else if (name == "listOfItems")
        {

            panel1.SetActive(false);
            panel3_1.SetActive(true);
        }
        else if (name == "return3_1")
        {

            panel1.SetActive(true);
            panel3_1.SetActive(false);
        }



        else if (name == "webLink")
        {

            panel1.SetActive(false);
            panel4_1.SetActive(true);
        }
        else if (name == "return4_1")
        {

            panel1.SetActive(true);
            panel4_1.SetActive(false);
        }

        else if (name == "quit")
        { 
            #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
                Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
            #endif
            #if (UNITY_EDITOR)
                UnityEditor.EditorApplication.isPlaying = false;
            #elif (UNITY_STANDALONE) 
                Application.Quit();
            #elif (UNITY_WEBGL)
                Application.OpenURL("about:blank");
            #endif

            
        }
        else if (name == "btnRestart")
        {
            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y);
        }
       
        else if (name == "btnMenu")
        {
            SceneManager.LoadScene(0);
        }
    }
}
