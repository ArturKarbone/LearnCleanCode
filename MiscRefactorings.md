
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
