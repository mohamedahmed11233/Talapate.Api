using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talapate.Core.Entities;

namespace Talapate.Core.specification
{
    public class BaseSpecifiction<T> : Ispecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }= new List<Expression<Func<T, object>>>();

        // in case the Criteria = null
        public BaseSpecifiction()
        {

            //Includes = new List<Expression<Func<T, bool>>>(); 
        }
        public BaseSpecifiction(Expression<Func<T,bool>> CriteriaExpression)
        {
            Criteria = CriteriaExpression;


        }
    }
}
