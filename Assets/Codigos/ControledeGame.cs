using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControledeGame : MonoBehaviour
{

    public int pontosv;
    public Text pontost;
    public GameObject fim;
    public GameObject pontos;


    public static ControledeGame instance;

    void Start()
    {
        instance = this;
    }

    public void AtualizarPontos()
    {
        pontost.text = pontosv.ToString();
    }

    public void MostarGameOver()
    {
        pontos.SetActive(false);
        fim.SetActive(true);
    }

    public void Recomecar(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
}
