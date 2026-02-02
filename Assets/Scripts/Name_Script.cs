using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Name_Script : MonoBehaviour
{
    private string text;
    private string[] input = { "Sveiks", "Jauku dienu", "Prieks tevi redzet", "uzderdzešanos", "Jauki ka atnacat", "Tiksimies rit" };
    private int rand;
    public GameObject inputField;
    public GameObject textField;
    public GameObject reverseTextToggle;
    public void gettext ()
    {
        rand = Random.Range(0, input.Length);
        text = inputField.GetComponent<TMP_InputField>().text;
        textField.GetComponent<TMP_Text>().text = input[rand] + ", " + text + "!"; 


        reverseTextToggle.GetComponent<Toggle>().interactable = true;
        if (reverseTextToggle.GetComponent<Toggle>().isOn)
        {
            reverseText();
        }

    }
    public void reverseText()
    {
      
        char[] charArray = textField.GetComponent<TMP_Text>().text.ToCharArray();
        System.Array.Reverse(charArray);
        textField.GetComponent<TMP_Text>().text = new string(charArray);
    }


}

