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
}
