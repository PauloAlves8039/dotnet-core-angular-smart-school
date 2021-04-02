using System;

namespace src.SmartSchool.WebAPI.Dtos
{
    /// <summary>
    /// Classe responsável pela difinição de propriedade de registros da entidade Aluno.
    /// </summary>
    public class AlunoRegistrarDto
    {
        /// <summary>
        /// Identificação de chave no banco de dados.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificação de aluno(a) para negócios na instituição.
        /// </summary>
        public int Matricula { get; set; }

        /// <summary>
        /// Define o Nome do aluno(a).
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Define o Sobrenome do aluno(a).
        /// </summary>
        public string Sobrenome { get; set; }

        /// <summary>
        /// Define o Telefone de contato do aluno(a).
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// Define a Data de Nascimento do aluno(a)
        /// </summary>
        public DateTime DataNasc { get; set; }

        /// <summary>
        /// Define a Data de Início de curso.
        /// </summary>
        public DateTime DataIni { get; set; } = DateTime.Now;

        /// <summary>
        /// Define a Data de Fim de curso.
        /// </summary>
        public DateTime? DataFim { get; set; } = null;

        /// <summary>
        /// Verifica se aluno(a) está ativo ou não.
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}
