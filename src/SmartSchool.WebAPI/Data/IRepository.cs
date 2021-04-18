using System.Threading.Tasks;
using src.SmartSchool.WebAPI.Helpers;
using src.SmartSchool.WebAPI.Models;

namespace src.SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        #region Métodos para manipulação de registros
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();
        #endregion

        #region Aluno
        Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Task<Aluno[]> GetAlunosAsyncByDisciplinaId(int disciplinaId, bool includeDisciplina);
        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);
        #endregion

        #region Professor
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false);
        Professor GetProfessorById(int professorId, bool includeAlunos = false);
        Professor[] GetProfessoresByAlunoId(int alunoId, bool includeAlunos = false);
        #endregion        
    }
}
