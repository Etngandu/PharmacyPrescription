using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.PharmaciesAndPrescriptions.EF.Repositories
{
    /// <summary>
    /// A concrete repository to work with case in the system.
    /// </summary>
    public class AsyncDrugCompanyRepository: AsyncRepository<Drug_company>, IAsyncDrugCompanyRepository
    {
        /// <summary>
        /// Gets a list of all guests whose last name exactly matches the search string.
        /// </summary>
        /// <param name="name">The last name that the system should search for.</param>
        /// <returns>An IEnumerable of Person with the matching people.</returns>
        /// 

        private readonly PharmaciesAndPrescriptionsContext _pharmaciesAndPrescriptionsContext;
        public AsyncDrugCompanyRepository(PharmaciesAndPrescriptionsContext pharmaciesAndPrescriptionsContext) : base(pharmaciesAndPrescriptionsContext)
        {
            _pharmaciesAndPrescriptionsContext = pharmaciesAndPrescriptionsContext;
        }
        public IEnumerable<Drug_company> FindByName(string companyname)
        {
            return _pharmaciesAndPrescriptionsContext.Set<Drug_company>().Where(x => x.Company_name == companyname);
        }
    }
}
