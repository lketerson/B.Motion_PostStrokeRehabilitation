using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.Collections.Generic;

public class Login : MonoBehaviour
{
    public GameObject cpf;

    private string _cpf;
    private String[] _lines;
    private string _cpfLido;
    // Start is called before the first frame update


    public void LoginClick()
    {
        bool verificaCpf = false;

        if (_cpf != "")
        {
            if (System.IO.File.Exists(@"C:\Users\lucas\leaplogins\" + _cpf + ".txt"))
            {
                verificaCpf = true;
            }
            else
            {
                Debug.Log("Cpf nao registrado");
                
            }
        }
        else
        {
            Debug.Log("Preencher cpf");
        }
        if (verificaCpf == true)
        {
            cpf.GetComponent<InputField>().text = "";
            Debug.Log("Sucesso");
            Application.LoadLevel("Capsule Hands (Desktop)");


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_cpf != "" && _cpf.Length==11)
            {
               LoginClick();
            }
        }
        _cpf = cpf.GetComponent<InputField>().text;
    }

    
}
