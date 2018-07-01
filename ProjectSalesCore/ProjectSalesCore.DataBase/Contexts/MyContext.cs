// <copyright file="MyContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CSales.Database.Contexts
{
    using System.Configuration;
    using System.Data.Entity;
    using System.Diagnostics;
    using CSales.Database.Models;
    using FirebirdSql.Data.FirebirdClient;
    using ProjectSalesCore.DataBase.Models;

    public class MyContext : DbContext
    {
        public MyContext()
            : base(ConfigurationManager.ConnectionStrings["CSalesDatabase"].ConnectionString)
        {
            this.Database.Log = s => Debug.Write(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AddressStorage> AddressStorage { get; set; }

        public DbSet<Provider> Provider { get; set; }

        public DbSet<AddressClient> AddressClient { get; set; }

        public DbSet<AddressProvider> AddressProvider { get; set; }

        public DbSet<AddressEmployee> AddressEmployee { get; set; }

        public DbSet<StatusOrder> StatusOrder { get; set; }

        public DbSet<Bank> Bank { get; set; }

        public DbSet<DPToSale> DetailsProductsToSale { get; set; }

        public DbSet<Bill> Bill { get; set; }

        public DbSet<BillOfExchange> BillOfExchange { get; set; }

        public DbSet<Check> Chek { get; set; }

        public DbSet<BusinessName> BusinessName { get; set; }

        public DbSet<DetailEntryNote> DetailEntryNote { get; set; }

        public DbSet<CityClient> CityClient { get; set; }

        public DbSet<CityProvider> CityProvider { get; set; }

        public DbSet<Client> Client { get; set; }

        public DbSet<Collection> Collection { get; set; }

        public DbSet<CostCenter> CostCenter { get; set; }

        public DbSet<CounterSale> CounterSale { get; set; }

        public DbSet<CreditNote> CreditNote { get; set; }

        public DbSet<CreditNoteType> CreditNoteType { get; set; }

        public DbSet<CurrentAccountDocumentType> CurrentAccountDocumentType { get; set; }

        public DbSet<CurrentAccountProvider> CurrentAcountProvider { get; set; }

        public DbSet<CustomerCheckingAccount> CustomerCheckingAccount { get; set; }

        public DbSet<DebitNote> DebitNote { get; set; }

        public DbSet<EmailClient> EmailClient { get; set; }

        public DbSet<EmailProvider> EmailProvider { get; set; }

        public DbSet<EmailEmployee> EmailEmployee { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<EntryNote> EntryNote { get; set; }

        public DbSet<ExternalInventory> ExternalInventory { get; set; }

        public DbSet<EProduct> ExternalProduct { get; set; }

        public DbSet<Fax> Fax { get; set; }

        public DbSet<InternalInventory> InternalInventory { get; set; }

        public DbSet<IProduct> InternalProduct { get; set; }

        public DbSet<Kardex> Kardex { get; set; }

        public DbSet<MovementType> MovementType { get; set; }

        public DbSet<MovementsProvider> MovementsProvider { get; set; }

        public DbSet<OutputNote> OuputNote { get; set; }

        public DbSet<OrderDetailsCompras> OrderDetailsCompras { get; set; }

        public DbSet<OrderDetailsVentas> OrderDetailsVentas { get; set; }

        public DbSet<PCondition> PaymentCondition { get; set; }

        public DbSet<PaymentMethod> PaymentMethod { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductLine> ProductLine { get; set; }

        public DbSet<ProductType> ProductType { get; set; }

        public DbSet<PDoc> PurchaseDocument { get; set; }

        public DbSet<POrder> PurchaseOrder { get; set; }

        public DbSet<ReasonNote> ReasonNote { get; set; }

        public DbSet<RUC> RUC { get; set; }

        public DbSet<Sale> Sale { get; set; }

        public DbSet<SaleOrder> SaleOrder { get; set; }

        public DbSet<SaByDisp> SalesByDispatch { get; set; }

        public DbSet<StatusNote> StatusNote { get; set; }

        public DbSet<Storage> Storage { get; set; }

        public DbSet<TelephoneClient> TelephoneClient { get; set; }

        public DbSet<TelephoneProvider> TelephoneProvider { get; set; }

        public DbSet<TelephoneEmployee> TelephoneEmployee { get; set; }

        public DbSet<TOPDoc> TypeOfPurchaseDocument { get; set; }

        public DbSet<TOSDoc> TypeOfSaleDocument { get; set; }

        public DbSet<UOfMeasur> UnitOfMeasurement { get; set; }

        public DbSet<Voucher> Voucher { get; set; }


        // public DbSet<>  { get; set; }
    }
}