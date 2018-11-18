using CnF.Domain.Models;

namespace CnF.Domain.Repositories
{
    public class UnitOfWork
    {
        private CnFEntities _db;

        public UnitOfWork()
        {
            this._db = new CnFEntities();
        }

        public void Save() => _db.SaveChanges();

        private IRepository<Supplier> supplierRepo;

        public IRepository<Supplier> SupplierRepository
        {
            get
            {
                if (this.supplierRepo == null)
                {
                    this.supplierRepo = new Repository<Supplier>(_db);
                }
                return supplierRepo;
            }
        }

        private IRepository<ShippingLine> shippingLineRepo;

        public IRepository<ShippingLine> ShippingLineRepository
        {
            get
            {
                if (this.shippingLineRepo == null)
                {
                    this.shippingLineRepo = new Repository<ShippingLine>(_db);
                }
                return shippingLineRepo;
            }
        }

        private IRepository<Job> jobRepo;

        public IRepository<Job> JobRepository
        {
            get
            {
                if (this.jobRepo == null)
                {
                    this.jobRepo = new Repository<Job>(_db);
                }
                return jobRepo;
            }
        }

        private IRepository<JobExpens> jobExpensRepo;

        public IRepository<JobExpens> JobExpensRepository
        {
            get
            {
                if (this.jobExpensRepo == null)
                {
                    this.jobExpensRepo = new Repository<JobExpens>(_db);
                }
                return jobExpensRepo;
            }
        }

        private IRepository<Country> countryRepo;

        public IRepository<Country> CountryRepository
        {
            get
            {
                if (this.countryRepo == null)
                {
                    this.countryRepo = new Repository<Country>(_db);
                }
                return countryRepo;
            }
        }
        private IRepository<Client> clientRepo;

        public IRepository<Client> ClientRepository

        {
            get
            {
                if (this.clientRepo == null)
                {
                    this.clientRepo = new Repository<Client>(_db);
                }
                return clientRepo;
            }
        }

        private IRepository<Billing> billingRepo;

        public IRepository<Billing> BillingRepository
        {
            get
            {
                if (this.billingRepo == null)
                {
                    this.billingRepo = new Repository<Billing>(_db);
                }
                return billingRepo;
            }
        }

        private IRepository<Branch> branchRepo;

        public IRepository<Branch> BranchRepository
        {
            get
            {
                if (this.branchRepo == null)
                {
                    this.branchRepo = new Repository<Branch>(_db);
                }
                return branchRepo;
            }
        }

        private IRepository<Port> portRepo;

        public IRepository<Port> PortRepository
        {
            get
            {
                if (this.portRepo == null)
                {
                    this.portRepo = new Repository<Port>(_db);
                }
                return portRepo;
            }
        }

        private IRepository<UserProfile> userProfileRepo;

        public IRepository<UserProfile> UserProfileRepository
        {
            get
            {
                if (this.userProfileRepo == null)
                {
                    this.userProfileRepo = new Repository<UserProfile>(_db);
                }
                return userProfileRepo;
            }
        }

    }
}
