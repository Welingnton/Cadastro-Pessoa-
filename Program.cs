using CadastroPessoa.Classes;

Console.Clear();
Console.WriteLine(@$"
==========================================
|   Bem vindo ao sistema de cadastro de  |
|      Pessoas Físicas e Jurídicas       |
==========================================
");


Utils.BarraCarregamento("Iniciando", 100, 40);


string? opcao;
do
{
    Console.Clear();
    Console.WriteLine($@"
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
            PessoaFisica novaPf = new PessoaFisica();
            PessoaFisica metodosPf = new PessoaFisica();
            Endereco novoEndPf = new Endereco();

            novaPf.Nome = "Odirlei";
            novaPf.dataNasc = new DateTime(2000, 01, 01);
            novaPf.Cpf = "1234567890";
            novaPf.Rendimento = 3500.5f;

            novoEndPf.logradouro = "Alameda Barao de Limeira";
            novoEndPf.numero = 539;
            novoEndPf.complemento = "Senai Informatica";
            novoEndPf.endComercial = true;

            novaPf.Endereco = novoEndPf;

            Console.Clear();
            Console.WriteLine(@$"
Nome: {novaPf.Nome}
Endereço: {novaPf.Endereco.logradouro}, {novaPf.Endereco.numero}
Maior de idade: {(metodosPf.ValidarDataNasc(novaPf.dataNasc) ? "Sim" : "Não")}
Imposto a ser pago: {metodosPf.PagarImposto(novaPf.Rendimento).ToString("C")}
");

            //    condicao ? "sim" : "Não"

            // Console.WriteLine(novaPf.ValidarDataNasc(novaPf.dataNasc));
            // Console.WriteLine($"Nome: {novaPf.Nome} Nome: {novaPf.Nome}");
            // Console.WriteLine("Nome: " + novaPf.Nome + " Nome:" + novaPf.Nome);

            Console.WriteLine($"Aperte ENTER para continuar");
            Console.ReadLine();



            break;

        case "2":
            PessoaJuridica novaPj = new PessoaJuridica();
            PessoaJuridica metodosPj = new PessoaJuridica();
            Endereco novoEndPj = new Endereco();

            novaPj.Nome = "Nome Pj";
            novaPj.RazaoSocial = "Razão Social Pj";
            novaPj.Cnpj = "00000000000100";
            novaPj.Rendimento = 10000.5f;

            novoEndPj.logradouro = "Alameda Barão de Limeira";
            novoEndPj.numero = 539;
            novoEndPj.complemento = "Senai Informática";
            novoEndPj.endComercial = true;

            novaPj.Endereco = novoEndPj;
            Console.Clear();
            Console.WriteLine(@$"
Nome: {novaPj.Nome};
Razão Social: {novaPj.RazaoSocial};
CNPJ; {novaPj.Cnpj}, Válido: {(metodosPj.ValidarCnpj(novaPj.Cnpj) ? "Sim" : "Não")}
Endereço: {novaPj.Endereco.logradouro}, Nº: {novaPj.Endereco.numero};
Complemento: {novaPj.Endereco.complemento}
Imposto a ser pago: {metodosPj.PagarImposto(novaPj.Rendimento).ToString("C")}
");

            Console.WriteLine($"Aperte ENTER para continuar");
            Console.ReadLine();


            break;

        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar nosso sistema!");
            Thread.Sleep(3000);

            Utils.BarraCarregamento("Finalizando", 500, 6);


            break;


        default:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Opção Inválida, por favor digite uma opção válida.");
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
