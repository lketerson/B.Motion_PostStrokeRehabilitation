using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnityToForm : MonoBehaviour
{
    //[SerializeField]
    //private string baseUrlBnb = Box and blocks link"https://docs.google.com/forms/u/0/d/e/1FAIpQLSd3sk8pCxKrB40ytLr-J9DQFcwERuWTijSrL4yi0yzN5k3RZQ/formResponse";
    [SerializeField]
    private string baseUrl; //=     Raction time link "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfySsWGmU-e102vWKHof5MDRu-mf_pvtsd2iQxV0CqM8MbyZw/formResponse";


    //____________Box And Blocks Form______________________________
    public string melhorPontuacaoBnb = "entry.652627999";
    public string cpfBnb = "entry.1940352720";
    public string pontuacaobnb = "entry.1109842368";

    //___________Reaction time Form________________________________
    public string melhorPontuacaoRt = "entry.753007139";
    public string cpfRt = "entry.1939702615";
    public string pontuacaoRt = "entry.376356826";


    public GameObject cpfInputField;


 
    //public ValidaCPF validarCpf;

    private string cpf;
    public static UnityToForm enviarForm;

    public string Cpf { get => cpf; set => cpf = value; }

    private void Start()
    {

        enviarForm = this;
        //validarCpf = GetComponent<ValidaCPF>();
    }
    public bool EnviarInformação() //ValidaCPF
    {
        bool validation;
        Cpf = cpfInputField.GetComponent<InputField>().text;
        if (Validacoes.ValidaCPF(Cpf))
        {
            //StartCoroutine(Post(Cpf, data));
            validation = true;
        }
        else
        {
            validation = false;
        }

        return validation;
        
    }

    public IEnumerator PostBnb(string cpf)
    {
        LineGraphManager.lineGraph.LoadList();
        
        if (SceneManager.GetActiveScene().name == "GAME_BoxNBlocks")
        {
            WWWForm form = new WWWForm();
            /*_________PREENCHENDO OS CAMPOS_________*/
            form.AddField(cpfBnb, cpf); //CPF
            form.AddField(pontuacaobnb, PlayerPrefs.GetFloat("Media_" + "" + PlayerPrefs.GetInt("mediaQTD")).ToString()); //PONTUACAO
            form.AddField(melhorPontuacaoBnb, LineGraphManager.lineGraph.HighestValue.ToString());  //Melhor pontuacao

            byte[] rawData = form.data;
            WWW www = new WWW(baseUrl, rawData);
            yield return www;

            Debug.Log("ENVIANDO INFORMAÇÃO BNB");
        }
    }

    public IEnumerator PostRt(string cpf)
    {
        LineGraphManager.lineGraph.LoadList();
        if (SceneManager.GetActiveScene().name == "GAME_LogicGates")
        {
            WWWForm form = new WWWForm();
            /*_________PREENCHENDO OS CAMPOS_________*/
            form.AddField(cpfRt, cpf);
            form.AddField(pontuacaoRt, PlayerPrefs.GetFloat("Media_RT" + "" + PlayerPrefs.GetInt("MediaQTD_RT")).ToString());
            form.AddField(melhorPontuacaoRt, LineGraphManager.lineGraph.LowestValue.ToString());

            byte[] rawData = form.data;
            WWW www = new WWW(baseUrl, rawData);
            yield return www;

            Debug.Log("ENVIANDO INFORMAÇÃO RT");
        }
    }

}
