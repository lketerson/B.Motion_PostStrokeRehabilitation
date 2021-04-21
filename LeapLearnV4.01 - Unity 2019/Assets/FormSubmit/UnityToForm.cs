using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using UnityEngine.UI;



public class UnityToForm : MonoBehaviour
{
    [SerializeField]
    private string baseUrl = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSd3sk8pCxKrB40ytLr-J9DQFcwERuWTijSrL4yi0yzN5k3RZQ/formResponse";
    public static string[] formsPaths = { "entry.1109842368", "entry.125980134", "entry.659438613", "entry.677929917","entry.1855757196", 
                                            "entry.1608729364", "entry.335316690", "entry.589880081", "entry.60263458", "entry.1813927506"};
    
    public GameObject cpfInputField;

    private int[] pointsToForms;
    private float mediaToForms;
    //public ValidaCPF validarCpf;

    private string cpf;
    private string data;
    public static UnityToForm enviarForm;

    private void Start()
    {
        enviarForm = this;
        //validarCpf = GetComponent<ValidaCPF>();
    }
    public void enviarInformação()
    {
        
        cpf = cpfInputField.GetComponent<InputField>().text;
        data = System.DateTime.Now.ToString("MM/dd/yyyy");
        if (Validacoes.ValidaCPF(cpf))
        {
            Debug.Log("True");
            StartCoroutine(Post(cpf, data));
        }
        else
        {
            Debug.Log("False");
        }
        
    }

    public IEnumerator Post(string cpf, string data)
    {
        pointsToForms = PlayerPrefsX.GetIntArray("arrayScore");
        mediaToForms = PlayerPrefs.GetFloat("media");
        WWWForm form = new WWWForm();
        form.AddField("entry.1940352720", cpf);                         //cpf

        for (int i = 0; i < formsPaths.Length; i++)
        {
            Debug.Log("Submiting");
            form.AddField(formsPaths[i], pointsToForms[i]);
        }


       /* form.AddField("entry.1109842368", Random.Range(0,10));          //=======================
        form.AddField("entry.125980134", Random.Range(0,10));
        form.AddField("entry.659438613", Random.Range(0, 10));
        form.AddField("entry.677929917", Random.Range(0, 10));
        form.AddField("entry.1855757196", Random.Range(0, 10));         //SECÇOES DE 1 A 10
        form.AddField("entry.1608729364", Random.Range(0, 10));
        form.AddField("entry.335316690", Random.Range(0, 10));
        form.AddField("entry.589880081", Random.Range(0, 10));
        form.AddField("entry.60263458", Random.Range(0, 10));
        form.AddField("entry.1813927506", Random.Range(0, 10));   */      //=======================
        form.AddField("entry.277554918", (int)mediaToForms);          //Media
        byte[] rawData = form.data;
        WWW www = new WWW(baseUrl, rawData);
        yield return www;
    }

}
