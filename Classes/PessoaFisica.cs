using CadastroPessoa.Interfaces;

namespace CadastroPessoa.Classes
{
    public class PessoaFisica : Pessoa , IPessoaFisica
    {
        public string? Cpf { get; set; }

        public DateTime Datanasc { get; set; }
        
        
        
        
        public override float PagarImposto(float rendimento)
        {
            throw new NotImplementedException();
        }

        public bool ValidarDatNasc(DateTime dataNasc)
        {
            throw new NotImplementedException();
        }
    }
}