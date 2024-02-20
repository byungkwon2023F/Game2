/*
  * - Name: Jack4_MainScript.cs
  * - Content:
  * Jack and the Beanstalk Episode 4 - Main script (dialogue) management script
  *
  * - Update Log -
  * 2021-07-14: Production completed
  * 2021-07-23: Comment change
  *
  * - How to use
  * 1. Enter sentences into ms_ScriptText.
  * 2. The separator is @, so add the separator.
  * 3. Check whether it has been divided properly through the log.
  * 4. The next script can be output through v_NextScript().
  * 5. Script contents can be set to blank through v_NoneScript().
  *
  * - Variable
  * mg_MainScript Main script object showing the script
  * ms_ScriptText A string that contains the script.
  * msa_SplitText[] It is divided and stored here based on the delimiter.
  * n_i variable for for statement
  * mn_Sequence script read order variable
  *
  * - Function
  * v_NoneScript() Sets the script to blank.
  * v_NextScript() Enter the next script.
  *
  */

using System. Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script that manages the main script, the content is left blank, and the following content can be output.
/// </summary>
public class Jack4_MainScript : MonoBehaviour
{
     GameObject mg_MainScript; //Declaration of script object to connect

     //Please enter a sentence in ms_ScriptText.
     private string ms_ScriptText = "When Jack returned home, he gave beans to his mother.@Mother cried out in surprise.@Mother was angry and threw the beans into the yard.";
     private string[] msa_SplitText;
     private int mn_Sequence;

     // Start is called before the first frame update
     void Start()
     {
         this.mg_MainScript = GameObject.Find("MainScript"); //Script object connection

         //Split the string based on the delimiter and check whether it is divided properly.
         msa_SplitText = ms_ScriptText.Split('@'); //If you want to edit the delimiter, edit this part
         for (int n_i = 0; n_i < msa_SplitText.Length; n_i++)
         {
             Debug.Log("Main Script[" + n_i + "] : " + msa_SplitText[n_i]);
         }
         mn_Sequence = -1;
     }

     #region function declaration
     /// <summary>
     /// Function that leaves the script contents blank
     /// </summary>
     public void v_NoneScript()
     {
         this.mg_MainScript.GetComponent<Text>().text = "";
     }

     /// <summary>
     /// Function that outputs the following script contents
     /// </summary>
     public void v_NextScript()
     {
         mn_Sequence += 1;
         if (mn_Sequence < msa_SplitText.Length)
         {
             this.mg_MainScript.GetComponent<Text>().text = msa_SplitText[mn_Sequence];
         }
         else if (mn_Sequence >= msa_SplitText.Length)
         {
             Debug.Log("Main script current sequence: " + mn_Sequence);
             Debug.Log("Main script maximum value: " + msa_SplitText.Length);
             Debug.Log("Main script size exceeded");
         }
     }
     #endregion function declaration part
}
