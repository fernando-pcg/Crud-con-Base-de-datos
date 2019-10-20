using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibrary1
{
    public class Datos
    {
        SqlConnection conect = new SqlConnection("Data Source=FERNANDORFR;Initial Catalog=CrudBD;Integrated Security=True");
        SqlCommand comando;

        public void Agregar(int num, string nombre, string categoria, string fecha)
        {
             conect.Open();
            string lineaComando = $"insert into Productos(Nombre,Categoria,Numero,FechaCreacion)values ('{nombre}','{categoria}',{num},'{fecha}');";
            comando = new SqlCommand(lineaComando, conect);
            CerrarConexion();
        }
        public void Actualizar(int num, string nombre, string categoria, string fecha)
        {
            conect.Open();
            string lineaComando = $"update Productos set Nombre='{nombre}',Categoria='{categoria}', FechaCreacion='{fecha}' where Numero={num}";
            comando = new SqlCommand(lineaComando, conect);
            CerrarConexion();
        }
        public void Borrar(int num)
        {
            conect.Open();
            string lineaComando = $"delete from Productos where Numero = {num}";
            comando = new SqlCommand(lineaComando, conect);
            CerrarConexion();
        }
        public DataTable LlenarGrid()
        {
            conect.Open();
            string lineaComando = $"select  Numero, Nombre, Categoria, FechaCreacion from Productos";
            comando = new SqlCommand(lineaComando, conect);
            comando.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable table = new DataTable();
            data.Fill(table);
            conect.Close();
            return table;
        }
        public void CerrarConexion()
        {
            comando.ExecuteNonQuery();
            conect.Close();
        }
        public void Cancelar()
        {
            conect.Close();
        }
    }
}