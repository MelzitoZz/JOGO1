using UnityEngine;

public class Banana : MonoBehaviour
{

    private SpriteRenderer SR;
    private CircleCollider2D CC;

    public GameObject coletado;
    public int valorb;
    
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        CC = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            SR.enabled = false;
            CC.enabled = false;
            coletado.SetActive(true);

            ControledeGame.instance.pontosv += valorb;
            ControledeGame.instance.AtualizarPontos();

            Destroy(gameObject, 0.3f);
        }
    }
}
