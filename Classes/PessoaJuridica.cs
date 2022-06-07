using System.Text.RegularExpressions;
using CadastroPessoa.Interfaces;

namespace CadastroPessoa.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? Cnpj { get; set; }

        public string? RazaoSocial { get; set; }




        public override float PagarImposto(float rendimento)
        {
            throw new NotImplementedException();
        }

        //xx.xxx.xxx/0001-xx ----- xxxxxxxx0001xx
        public bool ValidarCnpj(string cnpj)
        {
          // = Atribuição
          // == Comparação
          // === Comparação exata 
          
            bool retornoCnpjValido = Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}./\d{4}-\d{2})|(\d{14})$)");

            // if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}./\d{4}-\d{2})|(\d{14})$)"))
            if (retornoCnpjValido == true)
            {
                if (cnpj.Length == 18)
                {
                    string substringCnpj = cnpj.Substring(11, 4);

                    if (substringCnpj == "0001")
                    {
                        return true;

                    }

                }
                else if (cnpj.Length == 14)
                {
                    string substringCnpj = cnpj.Substring(8, 4);

                    if (substringCnpj == "0001")
                    {
                        return true;
                    }
                }
            }
            
            return false;

        }
    }
}
