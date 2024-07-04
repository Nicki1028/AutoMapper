using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Student student = new Student();
            //student.Name = "Nicki";
            //student.Email = "nicki831028@gmail.com";
            //student.Address = "Tainan";
            //student.Id = 1;
            //student.phone = new List<string> { "a", "b", "c" };    
            //student.Member = new Member(1, "Andy");


            //var keyValueModel = new KeyVauleModel<Student, User>(student, user);
            //keyValueModel.Formember(sou => sou.Id, dest => dest.id)
            //            .Formember(sou => sou.Name, dest => dest.name)
            //            .Formember(sou => sou.Email, dest => dest.Address);
           
           Type type=   typeof(Convert);
            string number = "123";
           int num =  (int)type.GetMethod("ToInt32",new Type[] { typeof(string) }).Invoke(null,new object[] { number});
            Console.WriteLine(num);
           //User usr =   Mapper.Map<Student, User>(student,config =>
           //{
           //    //config.Formember(sou => sou.Id, dest => dest.id)
           //    //         .Formember(sou => sou.Name, dest => dest.name)
           //    //         .Formember(sou => sou.Email, dest => dest.Address);
                        
           //    return config;
           //});
           
           Console.ReadKey();
        }
    }
}
