using src.SmartSchool.WebAPI.Models;

namespace src.SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Aluno[] GetAllAlunos();
        Aluno[] GetAllAlunosByDisciplinaId();
        Aluno GetAlunoById();

        Professor[] GetAllProfessores();
        Professor[] GetAllProfessoresByDisciplinaId();
        Professor GetProfessorById();
    }
}
