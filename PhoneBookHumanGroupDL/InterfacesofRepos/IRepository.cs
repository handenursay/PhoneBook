using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookHumanGroupDL.InterfacesofRepos
{
    public interface IRepository<T,Tid> where T:class , new()
    {
        //insert için
        int Add(T entity);

        //update için
        int Update(T entity); 

        //delete için
        int Delete(T entity);

          //select * from TableName 

         //select * from TableName where Name like 'B%'
         // select * from MemberPhone mp join Member m on m.Id=mp.MemberId
         //join PhoneGroup p on p.Id=mp.PhoneGroupId
        IQueryable<T> GetAll(Expression<Func<T,bool>>?  whereFilter=null,  string[]? joinTablesName=null);


        //select top 1 * from TableName 

        //select top 1 * from TableName where Name like 'B%'
        // select top 1 * from MemberPhone mp join Member m on m.Id=mp.MemberId
        //join PhoneGroup p on p.Id=mp.PhoneGroupId

        T GetByCondition(Expression<Func<T, bool>>? whereFilter = null, string[]? joinTablesName = null);


        //idsini verdiğim datayı getir
        //select * from TableName where Id=
        T GetbyId (int Tid);


    }
}
