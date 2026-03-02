using UnityEngine;
using UnityEngine.SceneManagement;
public class personagem : BasePersonagem
{
    [SerializeField] float velocidade = 7f;
    [SerializeField] float forcaPulo = 35f;

    private Vector3 pos;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    protected override void Start()
    {

        base.Start();
        nome = "mario";
        rb = GetComponent<Rigidbody2D>();
        pos = PegaPosicao();

        if (pos != Vector3.zero)
        {
            transform.position = pos;
        }
        else
        {
            InserirPosicao();
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0f, forcaPulo * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(velocidade * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(velocidade * Time.deltaTime, 0f, 0f);
        }
        SalvarPosicao();

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Resetar();
            SceneManager.LoadScene("Vitoria");

        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Resetar();
            SceneManager.LoadScene("GameOver");

        }
    }
}
