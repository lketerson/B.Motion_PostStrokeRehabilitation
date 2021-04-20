using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public GameObject cpf;
    public GameObject idade;
    public GameObject sexo;
    public GameObject mao;
    public GameObject nome;

    private string _cpf;
    private string _idade;
    private string _sexo;
    private string _mao;
    private string _nome;

    private string form;

    private bool _Sexo;
    private bool _Mao;
    
    

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (cpf.GetComponent<InputField>().isFocused)
            {
                nome.GetComponent<InputField>().Select();
            }
            if (nome.GetComponent<InputField>().isFocused)
            {
                mao.GetComponent<InputField>().Select();
            }
            if (mao.GetComponent<InputField>().isFocused)
            {
                idade.GetComponent<InputField>().Select();
            }
            if (idade.GetComponent<InputField>().isFocused)
            {
                sexo.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_cpf != "" &&  _nome!="" && _idade!="" && _sexo!="" && _mao!="" )
            {
                RegisterClick();
            } 
        }


        _cpf = cpf.GetComponent<InputField>().text;
        _idade = idade.GetComponent<InputField>().text;
        _sexo = sexo.GetComponent<InputField>().text;
        _mao = mao.GetComponent<InputField>().text;
        _nome = nome.GetComponent<InputField>().text;

    }

    public void RegisterClick()
    {
        bool verificacaoCpf = false;
        bool verificacaoIdade = false;
        bool verificacaoSexo = false;
        bool verificacaoMão = false;
        bool verificacaoNome = false;

        //verifica cpf--------------------------------------------------------
        if (_cpf.Length==11) 
        {
            if (!System.IO.File.Exists(@"C:\Users\lucas\leaplogins\" + _cpf+".txt"))    
            {
                verificacaoCpf = true;
            }
            else
            {
                Debug.Log("CPF já cadastradao");
            }  
        }
        else
        {
            Debug.Log("CPF Incompleto");
        }

        //verifica sexo------------------------------------------------------
        if((_sexo=="M") || (_sexo =="F"))
        {
            verificacaoSexo = true;
        }
        else
        {
            Debug.Log("Sexo invalido");
        }

        //verifica mao-------------------------------------------------------
        if ((_mao == "D") || (_mao == "E"))
        {
            verificacaoMão = true;
        }
        else
        {
            Debug.Log("Mao invalida");
        }

        //verifica idade-----------------------------------------------------
        if (_idade != "")
        {
            verificacaoIdade = true;
        }
        else
        {
            Debug.Log("Idade sem preencher");
        }

        //verifica nome------------------------------------------------------
        if (_nome!="")
        {
            verificacaoNome = true;
        }
        else
        {
            Debug.Log("Nome sem preencher");
        }


        //validaca se todas as açoes anteriores sao validas------------------
        if (verificacaoNome=true && verificacaoSexo==true && verificacaoIdade==true == verificacaoCpf== true && verificacaoMão==true) {
            form = (_cpf + Environment.NewLine + "NOME: " + _nome + Environment.NewLine + "IDADE: " + _idade + Environment.NewLine + "SEXO: " + _sexo + Environment.NewLine + "MAO: " + _mao + Environment.NewLine);
            System.IO.File.WriteAllText(@"C:\Users\lucas\leaplogins\" + _cpf + ".txt", form);


            //limpando os campos apos cadastrar------------------------------
            cpf.GetComponent<InputField>().text = "";
            idade.GetComponent<InputField>().text = "";
            sexo.GetComponent<InputField>().text = "";
            mao.GetComponent<InputField>().text = "";
            nome.GetComponent<InputField>().text = "";

            Debug.Log("Cadastrado!");
        }
    }
}
