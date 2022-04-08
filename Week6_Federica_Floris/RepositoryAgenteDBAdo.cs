using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Federica_Floris
{
    internal class RepositoryAgenteDBAdo : IRepository
    {
        string connectionString =@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = ProvaAgenti; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool Aggiungi(Agente agente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("insert into Agente values(@Nome, @Cognome,@CF,@AreaGeografica,@AnnoInizioAttivita)",connection);
                
                command.Parameters.AddWithValue("@Nome",agente.Nome);
                command.Parameters.AddWithValue("@Cognome",agente.Cognome);
                command.Parameters.AddWithValue("@CF",agente.CF);
                command.Parameters.AddWithValue("@AreaGeografica",agente.AreaGeografica);
                command.Parameters.AddWithValue("@AnnoInizioAttivita",agente.AnnoInizioAttivita);

                int numRighe = command.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;



            }
        }

        public void CercaAgenteByAnniServizio(int anniSerivizio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int annoInizioAttivita = DateTime.Now.Year - anniSerivizio;
                SqlCommand command = new SqlCommand("select * from Agente where AnnoInizioAttivita <= @annoInizioAttivita",connection);
                command.Parameters.AddWithValue("@annoInizioAttivita", annoInizioAttivita);

                SqlDataReader reader = command.ExecuteReader();

                Agente agente = null;

                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string cf = (string)reader["CF"];
                    string areaGeografica = (string)reader["AreaGeografica"];
                    int annoInizioAttivita1 = (int)reader["AnnoInizioAttivita"];

                    agente = new Agente(nome, cognome, cf, areaGeografica, annoInizioAttivita1);
                    Console.WriteLine(agente.ToString());


                }
                connection.Close();
               



            }
        }

        public List<Agente> CercaAgenteByArea(string area)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Agente where AreaGeografica = @areaGeografica", connection);
                command.Parameters.AddWithValue("@areaGeografica", area);

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agenti= new List<Agente>();


                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome =(string) reader["Cognome"];
                    string cf =(string) reader["CF"];
                    string areaGeografica = (string)reader["AreaGeografica"];
                    int annoInizioAttivita = (int)reader["AnnoInizioAttivita"];

                    Agente agente = new Agente(nome, cognome, cf, areaGeografica, annoInizioAttivita);
                    agenti.Add(agente);

                    
                }
                connection.Close();
                return agenti;


            }
        }

        public Agente CercaAgenteByCF(string cf)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Agente where CF = @cf", connection);
                command.Parameters.AddWithValue("@cf", cf);

                SqlDataReader reader = command.ExecuteReader();

                Agente agente = null;

                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string cf1 = (string)reader["CF"];
                    string areaGeografica = (string)reader["AreaGeografica"];
                    int annoInizioAttivita = (int)reader["AnnoInizioAttivita"];

                    agente = new Agente(nome, cognome, cf1, areaGeografica, annoInizioAttivita);


                }
                connection.Close();
                return agente;

            }


        }
        public List<Agente> VediTutti() 
        { 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Agente",connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agenti= new List<Agente>();


                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string cf = (string)reader["CF"];
                    string areaGeografica = (string)reader["AreaGeografica"];
                    int annoInizioAttivita = (int)reader["AnnoInizioAttivita"];

                    Agente agente2 = new Agente(nome, cognome, cf, areaGeografica, annoInizioAttivita);
                    agenti.Add(agente2);
                }
                connection.Close();

                return agenti;

            }




        }
    }
}
