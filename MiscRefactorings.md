
Before

```
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
