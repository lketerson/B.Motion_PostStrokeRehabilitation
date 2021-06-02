using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSccript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BoxNBlocksData()
    {
        Application.OpenURL("https://docs.google.com/spreadsheets/d/1Ei5RPm4u-_N9Mfd18XqfwJnW6Oavu2shii6Iibs2l04/edit?usp=sharing");
    }

    public void ReactionTimeData()
    {
        Application.OpenURL("https://docs.google.com/spreadsheets/d/10h_Om0UnV5yP7xU-D9kmsnjOnpfU9Tbms2AJDzhVw68/edit?usp=sharing");
    }

    public void TerapeutaSelcionado()
    {
        SceneManager.LoadScene(1);
    }

    public void PacienteSelecionado()
    {

    }

    public void VoltarRoleSelector()
    {
        SceneManager.LoadScene(0);
    }

    public void SairDaAplicação()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void PacienteMainMenu()
    {
        SceneManager.LoadScene(4);
    }

    public void GameBoxNBlocks()
    {
        SceneManager.LoadScene("GAME_BoxNBlocks");
    }

    public void GameLogicGates()
    {
        SceneManager.LoadScene("GAME_LogicGates");
    }

    public void GraficoBnB()
    {
        SceneManager.LoadScene(3);
    }
    public void GraficoRT()
    {
        SceneManager.LoadScene(7);
    }

}
