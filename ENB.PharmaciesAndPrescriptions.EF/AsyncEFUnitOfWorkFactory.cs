using ENB.PharmaciesAndPrescriptions.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ENB.PharmaciesAndPrescriptions.EF
{
  public  class AsyncEFUnitOfWorkFactory :IAsyncUnitOfWorkFactory
    {
        private readonly PharmaciesAndPrescriptionsContext _pharmaciesAndPrescriptionsContext;

      

        public AsyncEFUnitOfWorkFactory(PharmaciesAndPrescriptionsContext pharmaciesAndPrescriptionsContext)
        {
            _pharmaciesAndPrescriptionsContext = pharmaciesAndPrescriptionsContext;

        }
        public AsyncEFUnitOfWorkFactory(bool forcenew, PharmaciesAndPrescriptionsContext pharmaciesAndPrescriptionsContext)
        {
            _pharmaciesAndPrescriptionsContext = pharmaciesAndPrescriptionsContext;

        }
        /// <summary>
        /// Creates a new instance of an EFUnitOfWork.
        /// </summary>
        public async Task<IAsyncUnitOfWork> Create()
        {
            return await Create(false);
        }

        /// <summary>
        /// Creates a new instance of an EFUnitOfWork.
        /// </summary>
        /// <param name="forceNew">When true, clears out any existing data context from the storage container.</param>
        public async Task<IAsyncUnitOfWork> Create(bool forceNew)
        {
            var asyncEFUnitOfWork = await Task.FromResult(new AsyncEFUnitOfWork(forceNew, _pharmaciesAndPrescriptionsContext));


            return asyncEFUnitOfWork;

        }


    }
}
