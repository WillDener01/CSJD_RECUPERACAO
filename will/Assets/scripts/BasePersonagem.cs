using UnityEngine;

public class BasePersonagem : MonoBehaviour
{
    //protected SQL banco;
    public static SQL banco;
    protected string nome;

    protected virtual void Start()
    {
        banco = new SQL();
    }

    protected void SalvarPosicao()
    {
        banco.Atualizar(nome,
            transform.position.x,
            transform.position.y,
            transform.position.z);
    }

    protected void InserirPosicao()
    {
        banco.Inserir(nome,
                       transform.position.x,
                       transform.position.y,
                       transform.position.z);
    }

    protected Vector3 PegaPosicao()
    {
        return banco.RecuperarPosicaoJogador(nome);
    }

    protected void Resetar()
    {
        banco.ResetarBanco();
    }





}
