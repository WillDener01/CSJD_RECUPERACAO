using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : BasePersonagem
{
    public enum ESTADO
    {
        FELIZ,
        BRAVO
    }
    [SerializeField] ESTADO estado;
    [SerializeField] string nomeInimigo;
    [SerializeField] float velocidade = 7f;
    [SerializeField] GameObject personagem;
    float direcao = 1f;
    Vector3 pos;
    SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        nome = nomeInimigo;

        pos = PegaPosicao();

        if (pos != Vector3.zero)
        {
            transform.position = pos;
        }
        else
        {
            InserirPosicao();
        }
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        checaDistancia();
        trocaEstado();
        transform.position += new Vector3(direcao * velocidade * Time.deltaTime, 0f, 0f);
        SalvarPosicao();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Resetar();
            SceneManager.LoadScene("GameOver");
        }

        direcao = direcao * -1;
    }

    void checaDistancia()
    {
        float distancia = Vector3.Distance(gameObject.transform.position, personagem.transform.position);

        if (distancia < 2)
        {
            estado = ESTADO.BRAVO;
        }
        else
        {
            estado = ESTADO.FELIZ;
        }

    }

    void trocaEstado()
    {
        if (estado == ESTADO.FELIZ)
        {
            sr.color = Color.blue;
        }
        else
        {
            sr.color = Color.red;

        }

    }
}
