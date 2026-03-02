using UnityEngine;

public class Plataforma : BasePersonagem

{
    private Vector3 pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float direcao = 1f;
    protected override void Start()
    {
        base.Start();
        nome = "plataforma";
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
        transform.position += new Vector3(direcao * 2f * Time.deltaTime, 0f, 0f);
        SalvarPosicao();

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barreira"))
        {
            direcao = direcao * -1;

        }


    }
}
