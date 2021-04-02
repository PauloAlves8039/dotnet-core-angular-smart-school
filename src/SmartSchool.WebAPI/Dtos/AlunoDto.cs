using System;

namespace src.SmartSchool.WebAPI.Dtos
{
    /// <summary>
    /// Classe responsável pela difinição da entidade Aluno como Objeto de Transferência de Dados.
    /// </summary>
    public class AlunoDto
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
        /// Define o Nome e Sobrenome do aluno(a).
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Define o Telefone de contato do aluno(a).
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// Define a idade do aluno(a) através de cálculo relacionado a sua data de nascimento.
        /// </summary>
        public int Idade { get; set; }

        /// <summary>
        /// Aplica data de início de curso realizada pelo aluno(a).
        /// </summary>
        public DateTime DataIni { get; set; }

        /// <summary>
        /// Verifica se aluno(a) está ativo ou não.
        /// </summary>
        public bool Ativo { get; set; }
    }
}
