using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SQL
{
    string urlDataBase = "URI=file:" + Application.dataPath + "/BancoDeDados/SuperWill.db";

    IDbConnection _connection;
    IDbCommand _command;
    public SQL()
    {
        Iniciar();
    }

    public void Iniciar()
    {
        _connection = new SqliteConnection(urlDataBase);
        _command = _connection.CreateCommand();



        _connection.Open();

        string sql = "CREATE TABLE IF NOT EXISTS jogador (name VARCHAR(20),  posX REAL,posY REAL,posZ REAL)";


        _command.CommandText = sql;

        _command.ExecuteNonQuery();
        Debug.Log("iniciado");
    }


    public void ResetarBanco()
    {
        string sql = "DELETE FROM jogador";

        _command.CommandText = sql;
        _command.ExecuteNonQuery();

        Debug.Log("Todos os registros apagados");
    }
    public void Inserir(string nome, float x, float y, float z)
    {
        string sql = "INSERT INTO jogador (name,posX,posY,posZ) VALUES ('"
+ nome.ToString() + "',"
+ x.ToString().Replace(",", ".") + ","
+ y.ToString().Replace(",", ".") + ","
+ z.ToString().Replace(",", ".") + ")";

        _command.CommandText = sql;

        _command.ExecuteNonQuery();
        Debug.Log("iniciado" + nome);

    }

    public void Atualizar(string nome, float x, float y, float z)
    {
        string sql = "UPDATE jogador SET "
            + "posX = " + x.ToString().Replace(",", ".") + ", "
            + "posY = " + y.ToString().Replace(",", ".") + ", "
            + "posZ = " + z.ToString().Replace(",", ".")
            + " WHERE name = '" + nome + "'";

        _command.CommandText = sql;
        _command.ExecuteNonQuery();

        Debug.Log("Atualizado " + nome);
    }

    public Vector3 RecuperarPosicaoJogador(string nome)
    {
        string sql = "SELECT * FROM jogador WHERE name = '" + nome + "'";

        _command.CommandText = sql;
        IDataReader reader = _command.ExecuteReader();


        if (reader.Read())
        {
            Vector3 pos = new Vector3(reader.GetFloat(1), reader.GetFloat(2), reader.GetFloat(3));
            reader.Close();
            return pos;
        }
        else
        {
            reader.Close();
            return Vector3.zero;
        }
    }

}
