using UnityEngine;

public class Maca : MonoBehaviour
{

    private SpriteRenderer SR;
    private CircleCollider2D CC;

    public GameObject coletado;
    public int valorm;
    
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

            ControledeGame.instance.pontosv += valorm;
            ControledeGame.instance.AtualizarPontos();

            Destroy(gameObject, 0.3f);
        }
    }
}
