﻿using System.Text.RegularExpressions;
using CadastroPessoa.Classes;

Console.Clear();
Console.WriteLine(@$"
==========================================
|   Bem vindo ao sistema de cadastro de  |
|      Pessoas Físicas e Jurídicas       |
==========================================
");


Utils.BarraCarregamento("Iniciando", 100, 40);

List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
==========================================
|    Escolha  umas das opções abaixo      |
|-----------------------------------------|  
|       1 - Pessoa Física                 |
|       2 - Pessoa Jurídica               |
|                                         |
|       0 - Sair                          |
==========================================
");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

            string? opcaoPf;
            do
            {

                Console.Clear();
                Console.WriteLine(@$"
==========================================
|    Escolha  umas das opções abaixo      |
|-----------------------------------------|  
|       1 - Cadastrar Pessoa Física       |
|       2 - Listar Pessoas Físicas        |
|                                         |
|       0 - Voltar ao menu anterior       |
==========================================
");

                opcaoPf = Console.ReadLine();
                PessoaFisica metodosPf = new PessoaFisica();

                switch (opcaoPf)
                {
                    case "1":
                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco novoEndPf = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar");
                        novaPf.Nome = Console.ReadLine();

                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento EX:DD/MM/AAAA");
                            string? dataNascimento = Console.ReadLine();

                            dataValida = metodosPf.ValidarDataNasc(dataNascimento);

                            if (dataValida)
                            {
                                DateTime DataConvertida;
                                DateTime.TryParse(dataNascimento, out DataConvertida);
                                novaPf.dataNasc = DataConvertida;

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data digitada invalida, por favor digite uma data válida");
                                Console.ResetColor();
                                Thread.Sleep(3000);
                            }

                        } while (dataValida == false);


                        Console.WriteLine($"Digite o número do CPF");
                        novaPf.Cpf = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (DIGITE SOMENTE NÚMEROS)");
                        novaPf.Rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro");
                        novoEndPf.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        novoEndPf.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemente (Aperte ENTER para vazio)");
                        novoEndPf.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEndPf.endComercial = true;
                        }
                        else
                        {
                            novoEndPf.endComercial = false;
                        }

                        novaPf.Endereco = novoEndPf;

                        listaPf.Add(novaPf);


                        // StreamWriter sw = new StreamWriter($"{novaPf.Nome}.txt");
                        // sw.WriteLine(novaPf.Nome);
                        // sw.Close();

                        using (StreamWriter sw = new StreamWriter($"{novaPf.Nome}.txt"))
                        {
                            sw.WriteLine(novaPf.Nome);
                        }



                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(@$"Cadastro realizado com sucesso!");
                        Console.ResetColor();
                        Thread.Sleep(3000);

                        break;

                    case "2":

                        Console.Clear();

                        //                         if (listaPf.Count > 0)
                        //                         {
                        //                             foreach (PessoaFisica cadaPessoa in listaPf)
                        //                             {
                        //                                 Console.Clear();
                        //                                 Console.WriteLine(@$"
                        // Nome: {cadaPessoa.Nome}
                        // Endereço: {cadaPessoa.Endereco.logradouro}, {cadaPessoa.Endereco.numero}
                        // Imposto a ser pago: {metodosPf.PagarImposto(cadaPessoa.Rendimento).ToString("C")}
                        // ");
                        //                                 

                        //                             }
                        //                         }
                        //                         else
                        //                         {
                        //                             Console.WriteLine($"Lista vazia");
                        //                             Thread.Sleep(3000);

                        // }

                        using (StreamReader sr = new StreamReader("Welingnton.txt"))
                        {
                            string linha;
                            while ((linha = sr.ReadLine()) != null)
                            {
                                Console.WriteLine($"{linha}");
                            }

                        }

                        Console.WriteLine("Aperte 'ENTER' para continuar");
                        Console.ReadLine();

                        break;

                    case "0":

                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Opção Inválida, por favor digite uma opção válida.");
                        Console.ResetColor();
                        Thread.Sleep(3000);

                        break;
                }


            } while (opcaoPf != "0");

            break;


        // if ternário : condicao ? "sim" : "Não"

        // Console.WriteLine(novaPf.ValidarDataNasc(novaPf.dataNasc));
        // Console.WriteLine($"Nome: {novaPf.Nome} Nome: {novaPf.Nome}");
        // Console.WriteLine("Nome: " + novaPf.Nome + " Nome:" + novaPf.Nome);


        case "2":

            string? opcaoPj;

            do
            {

                Console.Clear();
                Console.WriteLine(@$"
==========================================
|    Escolha  umas das opções abaixo      |
|-----------------------------------------|  
|       1 - Cadastrar Pessoa Jurídica     |
|       2 - Listar Pessoas Jurídicas      |
|                                         |
|       0 - Voltar ao menu anterior       |
==========================================
");

                opcaoPj = Console.ReadLine();
                PessoaJuridica metodosPj = new PessoaJuridica();

                switch (opcaoPj)
                {
                    case "1":

                        PessoaJuridica novaPj = new PessoaJuridica();
                        Endereco novoEndPj = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa jurídica:");
                        novaPj.Nome = Console.ReadLine();

                        Console.WriteLine($"Digite a razão social da empresa:");
                        novaPj.RazaoSocial = Console.ReadLine();

                        bool cnpjValido;
                        do
                        {
                            Console.WriteLine($"Digite o número do CNPJ (Apenas números)");
                            string? CnpjValido = Console.ReadLine();

                            cnpjValido = metodosPj.ValidarCnpj(CnpjValido);

                            if (cnpjValido)
                            {
                                novaPj.Cnpj = CnpjValido;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"CNPJ inválido, por favor digite novamente !");
                                Console.ResetColor();
                                Thread.Sleep(3000);

                            }
                        } while (cnpjValido == false);

                        Console.WriteLine($"Digite o rendimento mensal:");
                        novaPj.Rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro");
                        novoEndPj.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        novoEndPj.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento");
                        novoEndPj.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEndPj.endComercial = true;
                        }
                        else
                        {

                            novoEndPj.endComercial = false;
                        }

                        novaPj.Endereco = novoEndPj;

                        metodosPj.Inserir(novaPj);


                        listaPj.Add(novaPj);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Console.ResetColor();
                        Thread.Sleep(2000);


                        break;

                    case "2":
                        Console.Clear();

                        if (listaPj.Count > 0)

                        {
                            // List<PessoaJuridica> ListPj = metodosPj.LerArquivo();

                            //     foreach (PessoaJuridica cadaItem in listaPj)
                            //     {
                            //         Console.Clear();
                            //         Console.WriteLine(@$"

                            // Razão Social: {cadaItem.RazaoSocial}
                            // CNPJ:{cadaItem.Cnpj},
                            // ");

                            //         Console.WriteLine($"Aperte ENTER para continuar");
                            //         Console.ReadLine();
                            //     }

                            foreach (PessoaJuridica cadaPessoaJ in listaPj)


                            {
                                Console.Clear();
                                Console.WriteLine(@$"

                        Nome: {cadaPessoaJ.Nome}
                        Razão Social: {cadaPessoaJ.RazaoSocial}
                        CNPJ:{cadaPessoaJ.Cnpj}, 
                        Endereco: {cadaPessoaJ.Endereco.logradouro}, N: {cadaPessoaJ.Endereco.numero}, Complemento: {cadaPessoaJ.Endereco.complemento}
                        Rendimento: {cadaPessoaJ.Rendimento}
                        Imposto a ser pago: {metodosPj.PagarImposto(cadaPessoaJ.Rendimento).ToString("C")}
                        ");


                                Console.WriteLine($"Aperte 'ENTER'para continuar");
                                Console.ReadLine();


                            }
                        }
                        else
                        {
                            Console.WriteLine($"Lista vazia!");
                            Thread.Sleep(2000);
                        }



                        break;

                    case "0":

                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Opção inválida, por favor digite uma opção válida!");
                        Console.ResetColor();
                        Thread.Sleep(5000);

                        break;

                }

            } while (opcaoPj != "0");

            break;

        // Console.WriteLine($"Aperte ENTER para continuar");
        // Console.ReadLine();


        case "0":
            Console.Clear();
            Console.WriteLine(@$"Obrigado por utilizar nosso sistema!");
            Thread.Sleep(5000);

            Utils.BarraCarregamento("Finalizando", 1000, 30);

            break;


        default:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Opção inválida, por favor digite uma opção válida.");
            Console.ResetColor();
            Thread.Sleep(3000);

            break;
    }

} while (opcao != "0");



// static void BarraCarregamento( string texto, int tempo, int quantidade)
// {
//     Console.BackgroundColor = ConsoleColor.Blue;
//     Console.ForegroundColor = ConsoleColor.Yellow;

//     Console.Write(texto);

//     for (var contador = 0; contador < quantidade; contador++)
//     {
//         Console.Write(".");
//         Thread.Sleep(tempo);
//     }
//     Console.ResetColor();

// }
