using System;
using System.Data.SqlClient;

namespace ONG_BD
{
    internal class Program
    {
        static void voltar()
        {
            Console.WriteLine("Pressione qualquer tecla para voltar....");
            Console.ReadKey();
        }
        static int menu()
        {
            int opc;
            Console.Clear();
            Console.WriteLine("\t\t1- Para cadastrar um novo animal");
            Console.WriteLine("\t\t2- Para cadastrar um novo adotante");
            Console.WriteLine("\t\t3- Para realizar uma nova adoção");
            Console.WriteLine("\n\t\t°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.WriteLine("\t\t4- Para ver os animais cadastrados");
            Console.WriteLine("\t\t5- Para ver os adotantes cadastrados");
            Console.WriteLine("\t\t6- Para ver as adoções realizadas");
            Console.WriteLine("\n\t\t°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.WriteLine("\t\t7- Para editar o cadastro de um animal");
            Console.WriteLine("\t\t8- Para editar o cadastro de um adotante");
            Console.WriteLine("\t\t0- Para sair ");

            return opc = int.Parse(Console.ReadLine());

        }

      
        static void Main(string[] args)
        {

            Pessoa p = new Pessoa();
            Animal a = new Animal();
            Adotar adocao = new Adotar();
            #region Conexao com o Banco
            Banco chamandocaminho = new Banco();

            SqlConnection conexaoSql = new SqlConnection(chamandocaminho.Caminho()); // parametro necessario para SqlConnection é uma string
                                                                                     // que identifica o caminho de conexão com o banco
            conexaoSql.Open(); //Abrindo conexão sql
            #endregion

            #region criando variavel para executar comando
            SqlCommand comando = new SqlCommand(); //criando uma variavel para fazer comandos do sql
            #endregion

            Console.WriteLine("\t\t°°°°°°°°°°°°°°ONG PATINHAS FELIZES°°°°°°°°°°°°°°°°°°");
            Console.WriteLine("\t\tPressione qualquer tecla para acessar o menu principal");
            Console.ReadKey();
            
            

            do
            {
                int op = menu();

                switch (op)
                {
                    case 1:
                        #region cadastro de animal
                        //CADASTRAR UM NOVO ANIMAL
                        Console.Clear();
                        Console.WriteLine("CADASTRO DE NOVO ANIMAL ");
                        Console.WriteLine("\nN° do chip identificador: ");
                        int c = int.Parse(Console.ReadLine());

                        Console.WriteLine("A qual familia ele pertence? (Cachorro, gato, etc..: ");
                        string f = Console.ReadLine();

                        Console.WriteLine("Raça: ");
                        string r = Console.ReadLine();
                       

                        Console.WriteLine("Sexo (feminino/masculino):  ");
                        string s = Console.ReadLine().ToLower(); 
                        while (s != "feminino" && s != "masculino")
                        {
                            Console.WriteLine("Insira um valor valido: (feminino/masculino): ");
                            s = Console.ReadLine().ToLower(); ;
                        }

                        Console.WriteLine("Nome: ");
                        string n = Console.ReadLine();

                        a.CadastrarAnimal(c, f, r, s, n);

                        string cmdinsert = $"INSERT INTO Animal (CHIP, Familia, Raca, Sexo, Nome) VALUES ('{a.CHIP}','{a.Familia}','{a.Raca}','{a.Sexo}','{a.Nome}')";
                        comando = new SqlCommand(cmdinsert, conexaoSql);
                        comando.ExecuteNonQuery();
                        Console.WriteLine("Animalzinho cadastrado com sucesso!");
                        voltar();
                        #endregion
                        break;

                    case 2:
                        #region cadastro adotante
                        Console.Clear();
                        Console.WriteLine("CADASTRO DE NOVO ADOTANTE ");

                        Console.WriteLine("\nCPF: ");
                        string cpf = Console.ReadLine();

                        Console.WriteLine("Nome: ");
                        string nome = Console.ReadLine();

                        Console.WriteLine("Telefone:");
                        string t = Console.ReadLine();

                        Console.WriteLine("Sexo(feminino/masculino): ");
                        string sexo = Console.ReadLine();
                        while (sexo != "feminino" && sexo != "masculino")
                        {
                            Console.WriteLine("Insira um valor valido: (feminino/masculino): ");
                            sexo = Console.ReadLine().ToUpper(); ;
                        }
                        Console.WriteLine("\nENDEREÇO:");

                        Console.WriteLine("Rua: ");
                        string rua = Console.ReadLine();

                        Console.WriteLine("Bairro: ");
                        string bairro = Console.ReadLine();

                        Console.WriteLine("Numero: ");
                        int num = int.Parse(Console.ReadLine());

                        Console.WriteLine("Cidade: ");
                        string cidade = Console.ReadLine();

                        Console.WriteLine("Insira a sigla do estado ");
                        string est = Console.ReadLine();
                        while (est.Length > 2)
                        {
                            Console.WriteLine("Insira a sigla com dois caracteres!\n(Ex: SP)");
                            est = Console.ReadLine();
                        }


                        p.CadastrarPessoa(cpf, nome, t, sexo, rua, bairro, num, cidade, est);

                        cmdinsert = $"INSERT INTO Pessoa (CPF, nome, telefone, sexo, rua, bairro, numero, cidade, estado) VALUES ('{p.CPF}','{p.Nome}','{p.Telefone}','{p.Sexo}','{p.Rua}','{p.Bairro}','{p.Numero}','{p.Cidade}','{p.Estado}')";
                        comando = new SqlCommand(cmdinsert, conexaoSql);
                        comando.ExecuteNonQuery();
                        Console.WriteLine("Adotante cadastrado com sucesso!");
                        voltar();
                        #endregion
                        break;


                    case 3:
                        #region cadastrar adoção
                        Console.Clear();
                        Console.WriteLine("CADASTRAR UMA ADOÇÃO ");

                        Console.WriteLine("\nInsira o CPF do adotante: ");
                        cpf = Console.ReadLine();

                        Console.WriteLine("Insira o n° do chip do animal que vai ser adotado ");
                        string chip = Console.ReadLine();

                        adocao.CadastrarAdocao(cpf, chip);
                        cmdinsert = $"INSERT INTO Adotar (CPF,CHIP) VALUES ('{adocao.CPF}','{adocao.CHIP}')";
                        comando = new SqlCommand(cmdinsert, conexaoSql);
                        comando.ExecuteNonQuery();
                        Console.WriteLine("Adoção realizada com sucesso!");
                        voltar();
                        break;
                    #endregion

                    case 4:
                        #region animais cadastrados
                        Console.Clear();
                        Console.WriteLine("ANIMAIS CADASTRADOS");

                        string cmdselect = $"SELECT CHIP, Familia, Raca, Sexo, Nome FROM Animal";
                        comando = new SqlCommand(cmdselect, conexaoSql);
                        comando.ExecuteNonQuery();
                        //lendo o select
                        using (SqlDataReader leitor = comando.ExecuteReader())
                        {

                            while (leitor.Read()) //enquanto leitor for verdadeiro
                            {

                                Console.WriteLine("\nN° CHIP: {0}", leitor.GetInt32(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                Console.WriteLine("Familia: {0}", leitor.GetString(1));
                                Console.WriteLine("Raça: {0}", leitor.GetString(2));
                                Console.WriteLine("Sexo: {0}", leitor.GetString(3));
                                Console.WriteLine("Nome: {0}", leitor.GetString(4));
                            }
                        }
                        voltar();
                        #endregion
                        break;

                    case 5:
                        #region adotantes cadastrados
                        Console.Clear();
                        Console.WriteLine("ADOTANTES CADASTRADOS");

                        cmdselect = $"SELECT cpf, nome, telefone, sexo, rua, bairro, numero, cidade, estado FROM Pessoa";
                        comando = new SqlCommand(cmdselect, conexaoSql);
                        comando.ExecuteNonQuery();
                        //lendo o select
                        using (SqlDataReader leitor = comando.ExecuteReader())
                        {

                            while (leitor.Read()) //enquanto leitor for verdadeiro
                            {

                                Console.WriteLine("\nCPF: {0}", leitor.GetString(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                Console.WriteLine("Nome {0}", leitor.GetString(1));
                                Console.WriteLine("Telefone {0}", leitor.GetString(2));
                                Console.WriteLine("Sexo {0}", leitor.GetString(3));
                                Console.WriteLine("\nEndereço:\nRua: {0}", leitor.GetString(4));
                                Console.WriteLine("Bairro: {0}", leitor.GetString(5));
                                Console.WriteLine("Numero: {0}", leitor.GetInt32(6));
                                Console.WriteLine("Cidade: {0}", leitor.GetString(7));
                                Console.WriteLine("Estado: {0}", leitor.GetString(8));
                            }
                        }
                        voltar();
                        #endregion
                        break;

                    case 6:
                        #region adocoes realizadas
                        Console.Clear();
                        Console.WriteLine("ADOÇÕES REALIZADAS");

                        cmdselect = $"SELECT adotar.CPF, pessoa.Nome, animal.Nome, adotar.CHIP FROM adotar, pessoa, animal where(adotar.Chip = animal.Chip)  and (adotar.cpf = pessoa.cpf) ";
                        comando = new SqlCommand(cmdselect, conexaoSql);
                        comando.ExecuteNonQuery();
                        //lendo o select
                        using (SqlDataReader leitor = comando.ExecuteReader())
                        {

                            while (leitor.Read()) //enquanto leitor for verdadeiro
                            {

                                Console.WriteLine("\nCPF do adotante: {0}", leitor.GetString(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero           
                                Console.WriteLine("Nome do adotante: {0}", leitor.GetString(1));
                                Console.WriteLine("Nome do animal adotado: {0}", leitor.GetString(2));
                                Console.WriteLine("N° Chip do animal adotado: {0}", leitor.GetInt32(3));

                            }
                        }
                        #endregion
                        voltar();
                        break;

                    case 7:
                        #region edicao animal
                        Console.WriteLine("Qual o n° do chip do animal que deseja editar?");
                        int nchip = int.Parse(Console.ReadLine());
                        cmdselect = $"SELECT CHIP, Familia, Raca, Sexo, Nome FROM Animal where chip='{nchip}'";
                        comando = new SqlCommand(cmdselect, conexaoSql);
                        comando.ExecuteNonQuery();
                        //lendo o select
                        using (SqlDataReader leitor = comando.ExecuteReader())
                        {

                            while (leitor.Read()) //enquanto leitor for verdadeiro
                            {

                                Console.WriteLine("\nN° CHIP: {0}", leitor.GetInt32(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                Console.WriteLine("Familia: {0}", leitor.GetString(1));
                                Console.WriteLine("Raça: {0}", leitor.GetString(2));
                                Console.WriteLine("Sexo: {0}", leitor.GetString(3));
                                Console.WriteLine("Nome: {0}", leitor.GetString(4));
                            }
                        }

                        Console.WriteLine("Qual dado deseja editar?");
                        Console.WriteLine("1 - Familia");
                        Console.WriteLine("2 - Raça");
                        Console.WriteLine("3 - Sexo");
                        Console.WriteLine("4 - Nome");
                        string dado = Console.ReadLine();
                        while (dado != "1" && dado !="2" && dado != "3" && dado != "4")
                        {
                            Console.WriteLine("Insira uma opção valida!");
                            dado = Console.ReadLine();
                        }

                        #region edicao familia
                        if (dado == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("Insira a nova familia ");
                            string novafam = Console.ReadLine();
                            string cmdupdate = $"UPDATE animal SET Familia = '{novafam}' WHERE CHIP = '{nchip}'";
                            comando = new SqlCommand(cmdupdate, conexaoSql);
                            comando.ExecuteNonQuery();
                            cmdselect = $"SELECT CHIP, Familia, Raca, Sexo, Nome FROM Animal where chip='{nchip}'";
                            comando = new SqlCommand(cmdselect, conexaoSql);
                            comando.ExecuteNonQuery();
                            //lendo o select
                            using (SqlDataReader leitor = comando.ExecuteReader())
                            {

                                while (leitor.Read()) //enquanto leitor for verdadeiro
                                {

                                    Console.WriteLine("\nN° CHIP: {0}", leitor.GetInt32(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                    Console.WriteLine("Familia: {0}", leitor.GetString(1));
                                    Console.WriteLine("Raça: {0}", leitor.GetString(2));
                                    Console.WriteLine("Sexo: {0}", leitor.GetString(3));
                                    Console.WriteLine("Nome: {0}", leitor.GetString(4));
                                }
                            }
                        }
                        #endregion

                        #region edicao raca
                        if (dado == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("Insira a nova raça ");
                            string novaraca = Console.ReadLine();
                            string cmdupdate = $"UPDATE animal SET Raca= '{novaraca}' WHERE CHIP = '{nchip}'";
                            comando = new SqlCommand(cmdupdate, conexaoSql);
                            comando.ExecuteNonQuery();
                            cmdselect = $"SELECT CHIP, Familia, Raca, Sexo, Nome FROM Animal where chip='{nchip}'";
                            comando = new SqlCommand(cmdselect, conexaoSql);
                            comando.ExecuteNonQuery();
                            //lendo o select
                            using (SqlDataReader leitor = comando.ExecuteReader())
                            {

                                while (leitor.Read()) //enquanto leitor for verdadeiro
                                {

                                    Console.WriteLine("\nN° CHIP: {0}", leitor.GetInt32(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                    Console.WriteLine("Familia: {0}", leitor.GetString(1));
                                    Console.WriteLine("Raça: {0}", leitor.GetString(2));
                                    Console.WriteLine("Sexo: {0}", leitor.GetString(3));
                                    Console.WriteLine("Nome: {0}", leitor.GetString(4));
                                }
                            }
                        }
                        #endregion

                        #region edicao sexo
                        if (dado == "3")
                        {
                            Console.Clear();
                            Console.WriteLine("Insira o novo sexo(feminino/masculino) ");
                            string novosexo = Console.ReadLine().ToLower();
                            while (novosexo != "feminino" && novosexo != "masculino")
                            {
                                Console.WriteLine("Insira um valor valido: (feminino/masculino): ");
                                novosexo = Console.ReadLine().ToLower(); 
                            }
                            string cmdupdate = $"UPDATE Animal SET Sexo= '{novosexo}' WHERE CHIP = '{nchip}'";
                            comando = new SqlCommand(cmdupdate, conexaoSql);
                            comando.ExecuteNonQuery();
                            cmdselect = $"SELECT CHIP, Familia, Raca, Sexo, Nome FROM Animal where chip='{nchip}'";
                            comando = new SqlCommand(cmdselect, conexaoSql);
                            comando.ExecuteNonQuery();
                            //lendo o select
                            using (SqlDataReader leitor = comando.ExecuteReader())
                            {

                                while (leitor.Read()) //enquanto leitor for verdadeiro
                                {

                                    Console.WriteLine("\nN° CHIP: {0}", leitor.GetInt32(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                    Console.WriteLine("Familia: {0}", leitor.GetString(1));
                                    Console.WriteLine("Raça: {0}", leitor.GetString(2));
                                    Console.WriteLine("Sexo: {0}", leitor.GetString(3));
                                    Console.WriteLine("Nome: {0}", leitor.GetString(4));
                                }
                            }
                        }
                        #endregion

                        #region edicao nome
                        if (dado == "4")
                        {
                            Console.Clear();
                            Console.WriteLine("Insira o novo nome ");
                            string novonome = Console.ReadLine();
                            string cmdupdate = $"UPDATE animal SET Raca= '{novonome}' WHERE CHIP = '{nchip}'";
                            comando = new SqlCommand(cmdupdate, conexaoSql);
                            comando.ExecuteNonQuery();
                            cmdselect = $"SELECT CHIP, Familia, Raca, Sexo, Nome FROM Animal where chip='{nchip}'";
                            comando = new SqlCommand(cmdselect, conexaoSql);
                            comando.ExecuteNonQuery();
                            //lendo o select
                            using (SqlDataReader leitor = comando.ExecuteReader())
                            {

                                while (leitor.Read()) //enquanto leitor for verdadeiro
                                {

                                    Console.WriteLine("\nN° CHIP: {0}", leitor.GetInt32(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                    Console.WriteLine("Familia: {0}", leitor.GetString(1));
                                    Console.WriteLine("Raça: {0}", leitor.GetString(2));
                                    Console.WriteLine("Sexo: {0}", leitor.GetString(3));
                                    Console.WriteLine("Nome: {0}", leitor.GetString(4));
                                }
                            }
                        }
                        #endregion

                        voltar(); 
                        #endregion
                        break;
                      case 8:
                        #region edicao pessoa
                        Console.WriteLine("Qual o n° do cpf do adotante que deseja editar?");
                        string ncpf = Console.ReadLine();
                        cmdselect = $"SELECT cpf, nome, telefone, sexo, rua, bairro, numero, cidade, estado FROM Pessoa where CPF = '{ncpf}'";
                        comando = new SqlCommand(cmdselect, conexaoSql);
                        comando.ExecuteNonQuery();
                        using (SqlDataReader leitor = comando.ExecuteReader())
                        {

                            while (leitor.Read()) //enquanto leitor for verdadeiro
                            {

                                Console.WriteLine("\nCPF: {0}", leitor.GetString(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                Console.WriteLine("Nome {0}", leitor.GetString(1));
                                Console.WriteLine("Telefone {0}", leitor.GetString(2));
                                Console.WriteLine("Sexo {0}", leitor.GetString(3));
                                Console.WriteLine("\nEndereço:\nRua: {0}", leitor.GetString(4));
                                Console.WriteLine("Bairro: {0}", leitor.GetString(5));
                                Console.WriteLine("Numero: {0}", leitor.GetInt32(6));
                                Console.WriteLine("Cidade: {0}", leitor.GetString(7));
                                Console.WriteLine("Estado: {0}", leitor.GetString(8));
                            }
                        }
                        Console.WriteLine("Qual dado deseja editar?");
                        Console.WriteLine("1 - Nome");
                        Console.WriteLine("2 - Telefone");
                        Console.WriteLine("3 - Sexo");
                        Console.WriteLine("4 - Rua");
                        Console.WriteLine("5 - Bairro");
                        Console.WriteLine("6 - Numero");
                        Console.WriteLine("7 - Cidade");
                        Console.WriteLine("8 - Estado");
                        dado = Console.ReadLine();
                        while (dado != "1" && dado != "2" && dado != "3" && dado != "4" && dado != "5" && dado != "6" && dado != "7" && dado != "8")
                        {
                            Console.WriteLine("Insira uma opção valida!");
                            dado = Console.ReadLine();
                        }

                        #region edicao nome
                        if (dado == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("Insira o novo nome ");
                            string novonome = Console.ReadLine();
                            string cmdupdate = $"UPDATE Pessoa SET nome= '{novonome}' WHERE Cpf = '{ncpf}'";
                            comando = new SqlCommand(cmdupdate, conexaoSql);
                            comando.ExecuteNonQuery();
                            cmdselect = $"SELECT cpf, nome, telefone, sexo, rua, bairro, numero, cidade, estado FROM Pessoa where CPF = '{ncpf}'";
                            comando = new SqlCommand(cmdselect, conexaoSql);
                            comando.ExecuteNonQuery();
                            using (SqlDataReader leitor = comando.ExecuteReader())
                            {

                                while (leitor.Read()) //enquanto leitor for verdadeiro
                                {

                                    Console.WriteLine("\nCPF: {0}", leitor.GetString(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                    Console.WriteLine("Nome {0}", leitor.GetString(1));
                                    Console.WriteLine("Telefone {0}", leitor.GetString(2));
                                    Console.WriteLine("Sexo {0}", leitor.GetString(3));
                                    Console.WriteLine("\nEndereço:\nRua: {0}", leitor.GetString(4));
                                    Console.WriteLine("Bairro: {0}", leitor.GetString(5));
                                    Console.WriteLine("Numero: {0}", leitor.GetInt32(6));
                                    Console.WriteLine("Cidade: {0}", leitor.GetString(7));
                                    Console.WriteLine("Estado: {0}", leitor.GetString(8));
                                }
                            }
                        }

                        #endregion

                        #region edicao telefone
                        if (dado == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("Insira o novo telefone ");
                            string novotelefone = Console.ReadLine();
                            string cmdupdate = $"UPDATE Pessoa SET telefone= '{novotelefone}' WHERE cpf= '{ncpf}'";
                            comando = new SqlCommand(cmdupdate, conexaoSql);
                            comando.ExecuteNonQuery();
                            cmdselect = $"SELECT cpf, nome, telefone, sexo, rua, bairro, numero, cidade, estado FROM Pessoa where CPF = '{ncpf}'";
                            comando = new SqlCommand(cmdselect, conexaoSql);
                            comando.ExecuteNonQuery();
                            using (SqlDataReader leitor = comando.ExecuteReader())
                            {

                                while (leitor.Read()) //enquanto leitor for verdadeiro
                                {

                                    Console.WriteLine("\nCPF: {0}", leitor.GetString(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                    Console.WriteLine("Nome {0}", leitor.GetString(1));
                                    Console.WriteLine("Telefone {0}", leitor.GetString(2));
                                    Console.WriteLine("Sexo {0}", leitor.GetString(3));
                                    Console.WriteLine("\nEndereço:\nRua: {0}", leitor.GetString(4));
                                    Console.WriteLine("Bairro: {0}", leitor.GetString(5));
                                    Console.WriteLine("Numero: {0}", leitor.GetInt32(6));
                                    Console.WriteLine("Cidade: {0}", leitor.GetString(7));
                                    Console.WriteLine("Estado: {0}", leitor.GetString(8));
                                }
                            }
                        }

                        #endregion

                        #region edicao sexo
                        if (dado == "3")
                        {
                            Console.Clear();
                            Console.WriteLine("Insira o novo sexo (feminino/masculino)");  
                            string novosexo = Console.ReadLine().ToLower();
                            while (novosexo != "feminino" && novosexo != "masculino")
                            {
                                Console.WriteLine("Insira um valor valido: (feminino/masculino): ");
                                novosexo = Console.ReadLine().ToUpper(); ;
                            }

                            string cmdupdate = $"UPDATE Pessoa SET sexo= '{novosexo}' WHERE cpf= '{ncpf}'";
                            comando = new SqlCommand(cmdupdate, conexaoSql);
                            comando.ExecuteNonQuery();
                            cmdselect = $"SELECT cpf, nome, telefone, sexo, rua, bairro, numero, cidade, estado FROM Pessoa where CPF = '{ncpf}'";
                            comando = new SqlCommand(cmdselect, conexaoSql);
                            comando.ExecuteNonQuery();
                            using (SqlDataReader leitor = comando.ExecuteReader())
                            {

                                while (leitor.Read()) //enquanto leitor for verdadeiro
                                {

                                    Console.WriteLine("\nCPF: {0}", leitor.GetString(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                    Console.WriteLine("Nome {0}", leitor.GetString(1));
                                    Console.WriteLine("Telefone {0}", leitor.GetString(2));
                                    Console.WriteLine("Sexo {0}", leitor.GetString(3));
                                    Console.WriteLine("\nEndereço:\nRua: {0}", leitor.GetString(4));
                                    Console.WriteLine("Bairro: {0}", leitor.GetString(5));
                                    Console.WriteLine("Numero: {0}", leitor.GetInt32(6));
                                    Console.WriteLine("Cidade: {0}", leitor.GetString(7));
                                    Console.WriteLine("Estado: {0}", leitor.GetString(8));
                                }
                            }
                        }

                        #endregion

                        #region edicao rua
                        if (dado == "4")
                        {
                            Console.Clear();
                            Console.WriteLine("Insira o novo nome da rua ");
                            string novarua = Console.ReadLine();

                            string cmdupdate = $"UPDATE Pessoa SET rua= '{novarua}' WHERE cpf= '{ncpf}'";
                            comando = new SqlCommand(cmdupdate, conexaoSql);
                            comando.ExecuteNonQuery();
                            cmdselect = $"SELECT cpf, nome, telefone, sexo, rua, bairro, numero, cidade, estado FROM Pessoa where CPF = '{ncpf}'";
                            comando = new SqlCommand(cmdselect, conexaoSql);
                            comando.ExecuteNonQuery();
                            using (SqlDataReader leitor = comando.ExecuteReader())
                            {

                                while (leitor.Read()) //enquanto leitor for verdadeiro
                                {

                                    Console.WriteLine("\nCPF: {0}", leitor.GetString(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                    Console.WriteLine("Nome {0}", leitor.GetString(1));
                                    Console.WriteLine("Telefone {0}", leitor.GetString(2));
                                    Console.WriteLine("Sexo {0}", leitor.GetString(3));
                                    Console.WriteLine("\nEndereço:\nRua: {0}", leitor.GetString(4));
                                    Console.WriteLine("Bairro: {0}", leitor.GetString(5));
                                    Console.WriteLine("Numero: {0}", leitor.GetInt32(6));
                                    Console.WriteLine("Cidade: {0}", leitor.GetString(7));
                                    Console.WriteLine("Estado: {0}", leitor.GetString(8));
                                }
                            }
                        }
                        #endregion

                        #region edicao bairro
                        if (dado == "5")
                        {
                            Console.Clear();
                            Console.WriteLine("Insira o novo nome do bairro ");
                            string novobairro = Console.ReadLine();

                            string cmdupdate = $"UPDATE Pessoa SET bairro= '{novobairro}' WHERE cpf= '{ncpf}'";
                            comando = new SqlCommand(cmdupdate, conexaoSql);
                            comando.ExecuteNonQuery();
                            cmdselect = $"SELECT cpf, nome, telefone, sexo, rua, bairro, numero, cidade, estado FROM Pessoa where CPF = '{ncpf}'";
                            comando = new SqlCommand(cmdselect, conexaoSql);
                            comando.ExecuteNonQuery();
                            using (SqlDataReader leitor = comando.ExecuteReader())
                            {

                                while (leitor.Read()) //enquanto leitor for verdadeiro
                                {

                                    Console.WriteLine("\nCPF: {0}", leitor.GetString(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                    Console.WriteLine("Nome {0}", leitor.GetString(1));
                                    Console.WriteLine("Telefone {0}", leitor.GetString(2));
                                    Console.WriteLine("Sexo {0}", leitor.GetString(3));
                                    Console.WriteLine("\nEndereço:\nRua: {0}", leitor.GetString(4));
                                    Console.WriteLine("Bairro: {0}", leitor.GetString(5));
                                    Console.WriteLine("Numero: {0}", leitor.GetInt32(6));
                                    Console.WriteLine("Cidade: {0}", leitor.GetString(7));
                                    Console.WriteLine("Estado: {0}", leitor.GetString(8));
                                }
                            }
                        }
                        #endregion

                        #region edicao numero
                        if (dado == "6")
                        {
                            Console.Clear();
                            Console.WriteLine("Insira o novo numero do endereco ");
                            int novonumero = int.Parse(Console.ReadLine());

                            string cmdupdate = $"UPDATE Pessoa SET numero= '{novonumero}' WHERE cpf= '{ncpf}'";
                            comando = new SqlCommand(cmdupdate, conexaoSql);
                            comando.ExecuteNonQuery();
                            cmdselect = $"SELECT cpf, nome, telefone, sexo, rua, bairro, numero, cidade, estado FROM Pessoa where CPF = '{ncpf}'";
                            comando = new SqlCommand(cmdselect, conexaoSql);
                            comando.ExecuteNonQuery();
                            using (SqlDataReader leitor = comando.ExecuteReader())
                            {

                                while (leitor.Read()) //enquanto leitor for verdadeiro
                                {

                                    Console.WriteLine("\nCPF: {0}", leitor.GetString(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                    Console.WriteLine("Nome {0}", leitor.GetString(1));
                                    Console.WriteLine("Telefone {0}", leitor.GetString(2));
                                    Console.WriteLine("Sexo {0}", leitor.GetString(3));
                                    Console.WriteLine("\nEndereço:\nRua: {0}", leitor.GetString(4));
                                    Console.WriteLine("Bairro: {0}", leitor.GetString(5));
                                    Console.WriteLine("Numero: {0}", leitor.GetInt32(6));
                                    Console.WriteLine("Cidade: {0}", leitor.GetString(7));
                                    Console.WriteLine("Estado: {0}", leitor.GetString(8));
                                }
                            }
                        }
                        #endregion

                        #region edicao cidade
                        if (dado == "7")
                        {
                            Console.Clear();
                            Console.WriteLine("Insira o novo nome da cidade ");
                            string novacidade = Console.ReadLine();

                            string cmdupdate = $"UPDATE Pessoa SET cidade= '{novacidade}' WHERE cpf= '{ncpf}'";
                            comando = new SqlCommand(cmdupdate, conexaoSql);
                            comando.ExecuteNonQuery();
                            cmdselect = $"SELECT cpf, nome, telefone, sexo, rua, bairro, numero, cidade, estado FROM Pessoa where CPF = '{ncpf}'";
                            comando = new SqlCommand(cmdselect, conexaoSql);
                            comando.ExecuteNonQuery();
                            using (SqlDataReader leitor = comando.ExecuteReader())
                            {

                                while (leitor.Read()) //enquanto leitor for verdadeiro
                                {

                                    Console.WriteLine("\nCPF: {0}", leitor.GetString(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                    Console.WriteLine("Nome {0}", leitor.GetString(1));
                                    Console.WriteLine("Telefone {0}", leitor.GetString(2));
                                    Console.WriteLine("Sexo {0}", leitor.GetString(3));
                                    Console.WriteLine("\nEndereço:\nRua: {0}", leitor.GetString(4));
                                    Console.WriteLine("Bairro: {0}", leitor.GetString(5));
                                    Console.WriteLine("Numero: {0}", leitor.GetInt32(6));
                                    Console.WriteLine("Cidade: {0}", leitor.GetString(7));
                                    Console.WriteLine("Estado: {0}", leitor.GetString(8));
                                }
                            }
                        }
                        #endregion

                        #region edicao estado
                        if (dado == "8")
                        {
                            Console.Clear();
                            Console.WriteLine("Insira a nova sigla do estado ");
                            string novasigla = Console.ReadLine();
                            while(novasigla.Length>2)
                            {
                                Console.WriteLine("Insira a sigla com dois caracteres!\n(Ex: SP)");
                                novasigla = Console.ReadLine();
                            }

                            string cmdupdate = $"UPDATE Pessoa SET estado= '{novasigla}' WHERE cpf= '{ncpf}'";
                            comando = new SqlCommand(cmdupdate, conexaoSql);
                            comando.ExecuteNonQuery();
                            cmdselect = $"SELECT cpf, nome, telefone, sexo, rua, bairro, numero, cidade, estado FROM Pessoa where CPF = '{ncpf}'";
                            comando = new SqlCommand(cmdselect, conexaoSql);
                            comando.ExecuteNonQuery();
                            using (SqlDataReader leitor = comando.ExecuteReader())
                            {

                                while (leitor.Read()) //enquanto leitor for verdadeiro
                                {

                                    Console.WriteLine("\nCPF: {0}", leitor.GetString(0)); //{0} posição da variavel q vai informar, parametro 0, cada linha começa no zero
                                    Console.WriteLine("Nome {0}", leitor.GetString(1));
                                    Console.WriteLine("Telefone {0}", leitor.GetString(2));
                                    Console.WriteLine("Sexo {0}", leitor.GetString(3));
                                    Console.WriteLine("\nEndereço:\nRua: {0}", leitor.GetString(4));
                                    Console.WriteLine("Bairro: {0}", leitor.GetString(5));
                                    Console.WriteLine("Numero: {0}", leitor.GetInt32(6));
                                    Console.WriteLine("Cidade: {0}", leitor.GetString(7));
                                    Console.WriteLine("Estado: {0}", leitor.GetString(8));
                                }
                            }
                        }
                        #endregion
                        #endregion
                        voltar();
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;
                }
            } while (true);



        }
    }
}
