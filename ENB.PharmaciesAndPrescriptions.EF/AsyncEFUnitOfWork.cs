using ENB.PharmaciesAndPrescriptions.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ENB.PharmaciesAndPrescriptions.EF
{
    /// <summary>
    /// Defines a Unit of Work using an EF DbContext under the hood.
    /// </summary>
    public class AsyncEFUnitOfWork : IAsyncUnitOfWork
    {
        // private readonly IDataContextStorageContainer<InsuranceAndClaimsContext> _cdataContextFactory;

        private readonly PharmaciesAndPrescriptionsContext _pharmaciesAndPrescriptionsContext;
        private bool _forceNew;
        private bool _disposed;

        // private InsuranceAndClaimsContext insuranceAndClaimsContext;

        /// <summary>
        /// Initializes a new instance of the EFUnitOfWork class.
        /// </summary>
        /// <param name="forceNewContext">When true, clears out any existing data context first.</param>

        public AsyncEFUnitOfWork(PharmaciesAndPrescriptionsContext pharmaciesAndPrescriptionsContext)
        {

            _pharmaciesAndPrescriptionsContext = pharmaciesAndPrescriptionsContext ?? throw new ArgumentNullException(nameof(pharmaciesAndPrescriptionsContext)); ;
        }

        public AsyncEFUnitOfWork(bool forceNew, PharmaciesAndPrescriptionsContext pharmaciesAndPrescriptionsContext)
        {
            _forceNew = forceNew;
            _pharmaciesAndPrescriptionsContext = pharmaciesAndPrescriptionsContext;
        }

        /// <summary>
        /// Saves the changes to the underlying DbContext.
        /// </summary>
        public void Dispose()
        {

            _pharmaciesAndPrescriptionsContext.Dispose();
        }

        /// <summary>
        /// Saves the changes to the underlying DbContext.
        /// </summary>
        /// <param name="">When true, clears out the data context afterwards.</param>
        public async Task Commit()
        {

            await _pharmaciesAndPrescriptionsContext.SaveChangesAsync();

        }



        public async ValueTask DisposeAsync()
        {
            //await _insuranceAndClaimsContext.DisposeAsync();
            // await DisposeAsync(true);
            await _pharmaciesAndPrescriptionsContext.SaveChangesAsync();
            // Take this object off the finalization queue to prevent 
            // finalization code for this object from executing a second time.
            // GC.SuppressFinalize(this);
        }

        // <summary>
        /// Cleans up any resources being used.
        /// </summary>
        /// <param name="disposing">Whether or not we are disposing</param> 
        /// <returns><see cref="ValueTask"/></returns>
        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    await _pharmaciesAndPrescriptionsContext.DisposeAsync();
                }

                // Dispose any unmanaged resources here...

                _disposed = true;
            }
        }
    }
}
