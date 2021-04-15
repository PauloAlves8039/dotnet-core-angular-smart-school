using System;

namespace src.SmartSchool.WebAPI.V1.Dtos
{
    /// <summary>
    ///Versão 1: classe responsável pela difinição de propriedade de registros da entidade Aluno.
    /// </summary>
    public class AlunoPatchDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}
