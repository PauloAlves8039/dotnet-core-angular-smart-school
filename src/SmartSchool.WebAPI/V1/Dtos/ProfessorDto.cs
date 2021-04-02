namespace src.SmartSchool.WebAPI.V1.Dtos
{
    /// <summary>
    /// Versão 1: classe responsável pela difinição da entidade Professor como Objeto de Transferência de Dados.
    /// </summary>
    public class ProfessorDto
    {
        /// <summary>
        /// Identificação de chave no banco de dados.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Define o registro do professor(a).
        /// </summary>
        public int Registro { get; set; }

        /// <summary>
        /// Define o Nome e Sobrenome do professor(a).
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Define o Telefone de contato do professor(a).
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// Verifica se professor(a) está ativo ou não.
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}
