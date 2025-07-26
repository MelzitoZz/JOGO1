using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float TempodaPlataforma;

    private TargetJoint2D TG;
    private BoxCollider2D BC;

    void Start()
    {
        TG = GetComponent<TargetJoint2D>();
        BC = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Cair", TempodaPlataforma);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }

    void Cair()
    {
        TG.enabled = false;
        BC.isTrigger = true;
    }
}
