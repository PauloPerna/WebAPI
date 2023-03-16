using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain
{
    public class Pessoa : BaseEntity
    {
        public Pessoa(
            string name,
            string cidade,
            string nomeMae
        ) : base()
        {
            this.Id = Guid.NewGuid();
            this.Nome = name;
            this.Cidade = cidade;
            this.NomeMae = nomeMae;
            this.Validate();
        }
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cidade { get; private set; }
        public string? NomeMae { get; private set; }

        public void Validate()
        {
            // Essas são as regras de negócio!
            if(string.IsNullOrWhiteSpace(this.Nome))
            {
                Messages.Add($"O {nameof(Nome)} de ver preenchido.");
            }
            if(string.IsNullOrWhiteSpace(this.Cidade))
            {
                Messages.Add($"A {nameof(Cidade)} de ver preenchida.");
            }
        }
    }
}