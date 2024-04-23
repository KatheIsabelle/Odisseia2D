using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;

public class Status : MonoBehaviour
{
    public static Status Instance;

    // pontos (A, B, C, D) aos seus valores (0 ou 1)
    private Dictionary<string, int> valoresPorPonto = new Dictionary<string, int>(); 

    // Componentes de texto para cada ponto
    public TMP_Text textoPontoA;
    public TMP_Text textoPontoB;
    public TMP_Text textoPontoC;
    public TMP_Text textoPontoD;

    void Start()
    {
        // Associe cada componente de texto aos pontos correspondentes
        textoPontoA = GameObject.FindWithTag("PontoA").GetComponent<TMP_Text>();
        textoPontoB = GameObject.FindWithTag("PontoB").GetComponent<TMP_Text>();
        textoPontoC = GameObject.FindWithTag("PontoC").GetComponent<TMP_Text>();
        textoPontoD = GameObject.FindWithTag("PontoD").GetComponent<TMP_Text>();

        // Inicialize os valores para cada ponto:zero
        valoresPorPonto.Add("A", 0); 
        valoresPorPonto.Add("B", 0);
        valoresPorPonto.Add("C", 0);
        valoresPorPonto.Add("D", 0);

        AtualizarTextos(); 
    }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AlterarValorDoPonto(string ponto, int novoValor)
    {
        if (valoresPorPonto.ContainsKey(ponto))
        {
            valoresPorPonto[ponto] = novoValor; 
            AtualizarTextos(); // Atualize os textos após a alteração
        }
    }

    public void AtualizarTextos()
    {
        if (valoresPorPonto.TryGetValue("A", out int valorA))
        {
            textoPontoA.text = valorA.ToString();
            Debug.Log("Ponto A ativado!");
        }

        
        if (valoresPorPonto.TryGetValue("B", out int valorB))
        {
            textoPontoB.text = valorB.ToString();
            Debug.Log("Ponto B ativado!");
        }

        if (valoresPorPonto.TryGetValue("C", out int valorC))
        {
            textoPontoC.text = valorC.ToString();
            Debug.Log("Ponto C ativado!");
        }

        if (valoresPorPonto.TryGetValue("D", out int valorD))
        {
            textoPontoD.text = valorD.ToString();
            Debug.Log("Ponto D ativado!");
        }
    }
}
