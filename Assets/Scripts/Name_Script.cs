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
    public void gettext ()
    {
        rand = Random.Range(0, input.Length);
        text = inputField.GetComponent<TMP_InputField>().text;
        textField.GetComponent<TMP_Text>().text = input[rand] + ", " + text + "!"; 

    }


}
