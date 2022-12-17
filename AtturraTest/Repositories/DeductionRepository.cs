using AtturraTeset.Engine;
using AtturraTeset.Engine.Deductions;
using AtturraTest.Engine.Deductions;
using AtturraTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AtturraTest.Repositories
{
 
    public class DeductionRepository : IRepository<IDeduction>
    {
        public IDeduction GetById(object primaryKey)
        {
            throw new NotImplementedException();
        }

        public void Save(IDeduction entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IDeduction entity)
        {
            throw new NotImplementedException();
        }
       

        public IEnumerable<IDeduction> GetWhere(Expression<Func<IEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDeduction> GetAll()
        {
            var deductions = new List<IDeduction>();

            deductions.Add(new MedicareLevy());
            deductions.Add(new BudgetRepairLevy());
            deductions.Add(new IncomeTax());
            deductions.Add(new SuperContribution());

            return deductions.ToArray();
        }
    }
}
