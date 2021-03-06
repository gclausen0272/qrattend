using System.Collections.Generic;
using qrattend.Repository.Contract;
using qrattend.Entities;
using System.Linq;

namespace qrattend.Repository.Implementation
{
    ///class repository
    public class ClassRepository: IClassRepository<Class>  
    {  
        private LibraryContext _libraryContext;  

        ///sets up the repo with the database context
        public ClassRepository(LibraryContext context)  
        {  
            _libraryContext = context;  
        }  

        ///refreshes repo for testing
        public void ClassRepositoryRefresh(LibraryContext context){
            _libraryContext = context;
        }

        ///gets teachers classes
        public IEnumerable<Class> GetTeacherClasses(int teacherId){
            var k =  _libraryContext.Classes.ToList().Where(x => x.TeacherId == teacherId);
            return k;
        }

        ///gets a list of all the Classs
        public IEnumerable<Class> GetAllClasses()  
        {  
            return _libraryContext.Classes.ToList();  
        }
        ///adds a Class to the database
        public Class PostClass(int teacherId, string className){
            //adds new Classs and saves database
            Class Class = new Class{TeacherId = teacherId, ClassName = className};
            _libraryContext.Add(Class);
            _libraryContext.SaveChanges();
            return Class;
        }
    }  
}
