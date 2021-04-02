using System;

namespace src.SmartSchool.WebAPI.V1.Dtos
{
    /// <summary>
    /// Versão 1: classe responsável pela difinição de propriedade de registros da entidade Professor.
    /// </summary>
    public class ProfessorRegistrarDto
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
        /// Define o Nome do professor(a).
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Define o Sobrenome do professor(a).
        /// </summary>
        public string Sobrenome { get; set; }

        /// <summary>
        /// Define o Telefone do professor(a).
        /// </summary>
        public string Telefone { get; set; }

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
