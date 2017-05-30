
Before

```cs
     public IntegrationContext ShouldHaveInvoices(int numberOfInvoicesdd
        {
            var contractsRepository = Container.Resolve<IContractsRepository>();
            var contract = contractsRepository
                .Get(this.Contract.Id);

            contract?.Invoices?.Count().ShouldBe(numberOfInvoices);
            return this;
        }
```

After (Temp to query + fluent interfaces)

```
  public IntegrationContext ShouldHaveInvoices(int numberOfInvoices)
        {
            Resolver
                .ContractsRepository
                .Get(this.Contract.Id)
                .Invoices
                .Count()
                .ShouldBe(numberOfInvoices);
                       
            return this;
        }
```

Even more readable version where each level of abstraction has it's own indentation
```
     public IntegrationContext ShouldHaveInvoices(int numberOfInvoices)
        {
            Resolver
               .ContractsRepository
                    .Get(this.Contract.Id)
                       .Invoices
                       .Count()
                       .ShouldBe(numberOfInvoices);

            return this;
        }
```

User method overloads/request messages insted of GetByExtranId(...), GetBySomthingElse(...). In general it is a good idea to wrap ids with entities, like Client/Tenant/Order to better communicate the intent, instead of passing client_id/order_id/tenant_id/

```
    public class ExternalTenantRequest
    {
        public string ClientCode { get; set; }
    }

    public interface ITenantsRepository : IRepository<Tenant, string>
    {
        Tenant Get(ExternalTenantRequest request);
    }

    public class TenantsRepository : ITenantsRepository
    {    

        public Tenant Get(ExternalTenantRequest request)
        {
            var tenant = Context
                .Tenants
                .FirstOrDefault(x => x.ExternalId == request.ClientCode);

            return tenant;
        }
    }
```

Leverage dynamic, to reduce internal/nested classes

```
 class FileFixture
    {
        public string BaseResourcePath = "Portal.API.Tests.Shared.Fixtures";

        dynamic Settings { get; }

        public FileFixture(dynamic settings)
        {
            Settings = settings;
        }

        public byte[] Content()
        {
            using (System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream($"{BaseResourcePath}.{Settings.Resource}.{Settings.File}"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }
    }
```

How to ignore tests
```
 [Fact(Skip="Not used in tests suite. Needed on hoc.")]       
        public void EmulateTransactionFromSLS()
        {
            string clientCode = "4005", invoiceNumber = "bc26dc57-fe7e-4a11-9f2e-b627219a3daa";
            decimal amount = 1000;

            var exchangeOptions = new MessagingOptions
            {
                IntegrationWithSLS = new MessagingOptions.IntegrationOptions
                {
                    ConnectionString = "rabbitmq://sls:sls@localhost:5672/SLS_CB_Integration",
                    TransactionsExchange = new MessagingOptions.ExchangeOptions
                    {
                        DefaultQueueName = "ARM_Transactions",
                        ExchangeName = "ARM_Transactions"
                    }
                }
            };

            var transaction = new TransactionOccuredEvent
            {
                EntryDate = DateTime.Now,
                LedgerCode = "400501",
                InvoiceNumber = invoiceNumber,
                TransactionTypeId = 10,
                ClientCode = clientCode,
                TransactionEntries = new List<TransactionEntry>
                {
                     new TransactionEntry
                     {
                          CurrencyId = "EUR",
                          PaymentId =  123,
                          CustomerNumber = Guid.NewGuid().ToARMIdentity(),
                          CreditAccountId = "AR",
                          DebitAccountId = "SALES",
                          Amount = amount,
                          BookingDate = DateTime.Now
                     }
                 }
            };

            BusConfigurator.ConfigureBus(exchangeOptions.IntegrationWithSLS)
                .Publish(transaction);          
        }       
```
