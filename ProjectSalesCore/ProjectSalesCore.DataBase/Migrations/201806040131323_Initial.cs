namespace ProjectSalesCore.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ADDRESS",
                c => new
                    {
                        ID = c.int(nullable: false),
                        ADDRESSNAME = c.String(),
                        DESCRIPTION = c.String(),
                        Bank_IdBank = c.int(),
                        Client_Id = c.int(),
                        Employee_Id = c.int(),
                        Provider_Id = c.int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BANK", t => t.Bank_IdBank)
                .ForeignKey("dbo.CLIENT", t => t.Client_Id)
                .ForeignKey("dbo.EMP", t => t.Employee_Id)
                .ForeignKey("dbo.PROVIDER", t => t.Provider_Id)
                .Index(t => t.Bank_IdBank)
                .Index(t => t.Client_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Provider_Id);
            
            CreateTable(
                "dbo.BANK",
                c => new
                    {
                        IDBANK = c.int(nullable: false),
                        BANKNAME = c.String(),
                        DESCRIPTION = c.String(),
                    })
                .PrimaryKey(t => t.IDBANK);
            
            CreateTable(
                "dbo.TEL",
                c => new
                    {
                        ID = c.int(nullable: false),
                        NUMBER = c.String(),
                        DESCRIPTION = c.String(),
                        Bank_IdBank = c.int(),
                        Employee_Id = c.int(),
                        Client_Id = c.int(),
                        Provider_Id = c.int(),
                        Storage_IdStorage = c.int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BANK", t => t.Bank_IdBank)
                .ForeignKey("dbo.EMP", t => t.Employee_Id)
                .ForeignKey("dbo.CLIENT", t => t.Client_Id)
                .ForeignKey("dbo.PROVIDER", t => t.Provider_Id)
                .ForeignKey("dbo.STOR", t => t.Storage_IdStorage)
                .Index(t => t.Bank_IdBank)
                .Index(t => t.Employee_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Provider_Id)
                .Index(t => t.Storage_IdStorage);
            
            CreateTable(
                "dbo.BILL",
                c => new
                    {
                        ID = c.int(nullable: false),
                        IDCLIENT = c.int(nullable: false),
                        IDEMPLOYEE = c.int(nullable: false),
                        CREATEDDATE = c.DateTime(nullable: false),
                        TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaByDisp_Id = c.int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLIENT", t => t.IDCLIENT, cascadeDelete: true)
                .ForeignKey("dbo.EMP", t => t.IDEMPLOYEE, cascadeDelete: true)
                .ForeignKey("dbo.SBDISPATCH", t => t.SaByDisp_Id)
                .Index(t => t.IDCLIENT)
                .Index(t => t.IDEMPLOYEE)
                .Index(t => t.SaByDisp_Id);
            
            CreateTable(
                "dbo.CLIENT",
                c => new
                    {
                        ID = c.int(nullable: false),
                        NAME = c.String(),
                        IDRUC = c.int(nullable: false),
                        IDEMPLOYEE = c.int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EMP", t => t.IDEMPLOYEE, cascadeDelete: true)
                .ForeignKey("dbo.RUC", t => t.IDRUC, cascadeDelete: true)
                .Index(t => t.IDRUC)
                .Index(t => t.IDEMPLOYEE);
            
            CreateTable(
                "dbo.CITY",
                c => new
                    {
                        ID = c.int(nullable: false),
                        NAME = c.String(),
                        DESCRIPTION = c.String(),
                        Client_Id = c.int(),
                        Provider_Id = c.int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLIENT", t => t.Client_Id)
                .ForeignKey("dbo.PROVIDER", t => t.Provider_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Provider_Id);
            
            CreateTable(
                "dbo.EMAIL",
                c => new
                    {
                        IDEMAIL = c.int(nullable: false),
                        EMAILL = c.String(),
                        Client_Id = c.int(),
                    })
                .PrimaryKey(t => t.IDEMAIL)
                .ForeignKey("dbo.CLIENT", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.EMP",
                c => new
                    {
                        ID = c.int(nullable: false),
                        NAME = c.String(),
                        HIREDATE = c.DateTime(nullable: false),
                        SALARY = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FAX",
                c => new
                    {
                        IDFAX = c.int(nullable: false),
                        FAXX = c.String(),
                        Client_Id = c.int(),
                    })
                .PrimaryKey(t => t.IDFAX)
                .ForeignKey("dbo.CLIENT", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.RUC",
                c => new
                    {
                        IDRUC = c.int(nullable: false),
                        RUCNAME = c.String(),
                    })
                .PrimaryKey(t => t.IDRUC);
            
            CreateTable(
                "dbo.ODETAIL",
                c => new
                    {
                        IDXP = c.int(nullable: false),
                        IDSORDER = c.int(nullable: false),
                        QUANTITY = c.Int(nullable: false),
                        UNITPRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DISCOUNTRATE = c.Int(nullable: false),
                        TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bill_IdBill = c.int(),
                    })
                .PrimaryKey(t => new { t.IDXP, t.IDSORDER })
                .ForeignKey("dbo.EPRODUCT", t => t.IDXP, cascadeDelete: true)
                .ForeignKey("dbo.SOR", t => t.IDSORDER, cascadeDelete: true)
                .ForeignKey("dbo.BILL", t => t.Bill_IdBill)
                .Index(t => t.IDXP)
                .Index(t => t.IDSORDER)
                .Index(t => t.Bill_IdBill);
            
            CreateTable(
                "dbo.EPRODUCT",
                c => new
                    {
                        ID = c.int(nullable: false),
                        IDPRODUCT = c.int(nullable: false),
                        IDM = c.int(nullable: false),
                        IDPT = c.int(nullable: false),
                        IDPL = c.int(nullable: false),
                        PRODUCTDESCRIPTION = c.String(),
                        QUANTITY = c.Int(nullable: false),
                        ACTIVE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PDTO", t => t.IDPRODUCT, cascadeDelete: true)
                .ForeignKey("dbo.PLINE", t => t.IDPL, cascadeDelete: true)
                .ForeignKey("dbo.PTYPE", t => t.IDPT, cascadeDelete: true)
                .ForeignKey("dbo.UNIT", t => t.IDM, cascadeDelete: true)
                .Index(t => t.IDPRODUCT)
                .Index(t => t.IDM)
                .Index(t => t.IDPT)
                .Index(t => t.IDPL);
            
            CreateTable(
                "dbo.PDTO",
                c => new
                    {
                        ID = c.int(nullable: false),
                        PRODUCTNAME = c.int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PLINE",
                c => new
                    {
                        ID = c.int(nullable: false),
                        LINENAME = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PTYPE",
                c => new
                    {
                        ID = c.int(nullable: false),
                        TYPENAME = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UNIT",
                c => new
                    {
                        ID = c.int(nullable: false),
                        UNITNAME = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SOR",
                c => new
                    {
                        ID = c.int(nullable: false),
                        CREATEDDATE = c.DateTime(nullable: false),
                        IDCLIENT = c.int(nullable: false),
                        IDEMPLOYEE = c.int(nullable: false),
                        IDPCONDITION = c.int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLIENT", t => t.IDCLIENT, cascadeDelete: true)
                .ForeignKey("dbo.EMP", t => t.IDEMPLOYEE, cascadeDelete: true)
                .ForeignKey("dbo.PC", t => t.IDPCONDITION, cascadeDelete: true)
                .Index(t => t.IDCLIENT)
                .Index(t => t.IDEMPLOYEE)
                .Index(t => t.IDPCONDITION);
            
            CreateTable(
                "dbo.PC",
                c => new
                    {
                        ID = c.int(nullable: false),
                        CONDITIONNAME = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BOEX",
                c => new
                    {
                        ID = c.int(nullable: false),
                        IDCLIENT = c.int(nullable: false),
                        IDEMPLOYEE = c.int(nullable: false),
                        PAYMENTDATE = c.DateTime(nullable: false),
                        TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLIENT", t => t.IDCLIENT, cascadeDelete: true)
                .ForeignKey("dbo.EMP", t => t.IDEMPLOYEE, cascadeDelete: true)
                .Index(t => t.IDCLIENT)
                .Index(t => t.IDEMPLOYEE);
            
            CreateTable(
                "dbo.BNAME",
                c => new
                    {
                        ID = c.int(nullable: false),
                        NAME = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CHECK",
                c => new
                    {
                        IDCHECK = c.int(nullable: false),
                        CHECKNUMBER = c.Int(nullable: false),
                        DESCRIPTION = c.String(),
                        IDCLIENT = c.int(nullable: false),
                        PAYMENTDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDCHECK)
                .ForeignKey("dbo.CLIENT", t => t.IDCLIENT, cascadeDelete: true)
                .Index(t => t.IDCLIENT);
            
            CreateTable(
                "dbo.COLLECTION",
                c => new
                    {
                        IDCLIENT = c.int(nullable: false),
                        IDCHECK = c.int(nullable: false),
                        IDPAYm = c.int(nullable: false),
                        IDBANK = c.int(nullable: false),
                        IDTDFS = c.int(nullable: false),
                        IDDOCUMENT = c.int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDCLIENT, t.IDCHECK })
                .ForeignKey("dbo.BANK", t => t.IDBANK, cascadeDelete: true)
                .ForeignKey("dbo.CHECK", t => t.IDCHECK, cascadeDelete: true)
                .ForeignKey("dbo.CLIENT", t => t.IDCLIENT, cascadeDelete: true)
                .ForeignKey("dbo.PMETHOD", t => t.IDPAYm, cascadeDelete: true)
                .ForeignKey("dbo.TOSDOC", t => t.IDTDFS, cascadeDelete: true)
                .Index(t => t.IDCLIENT)
                .Index(t => t.IDCHECK)
                .Index(t => t.IDPAYm)
                .Index(t => t.IDBANK)
                .Index(t => t.IDTDFS);
            
            CreateTable(
                "dbo.PMETHOD",
                c => new
                    {
                        ID = c.int(nullable: false),
                        METHODNAME = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TOSDOC",
                c => new
                    {
                        ID = c.int(nullable: false),
                        NAMEDOCUMENT = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CCENTER",
                c => new
                    {
                        ID = c.int(nullable: false),
                        COSTNAME = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CSALE",
                c => new
                    {
                        ID = c.int(nullable: false),
                        IDBILL = c.int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BILL", t => t.IDBILL, cascadeDelete: true)
                .Index(t => t.IDBILL);
            
            CreateTable(
                "dbo.CNOTE",
                c => new
                    {
                        ID = c.int(nullable: false),
                        IdCNType = c.int(nullable: false),
                        IDCLIENT = c.int(nullable: false),
                        IDEMPLOYEE = c.int(nullable: false),
                        TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdTDFSale = c.int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLIENT", t => t.IDCLIENT, cascadeDelete: true)
                .ForeignKey("dbo.CNTYPE", t => t.IdCNType, cascadeDelete: true)
                .ForeignKey("dbo.EMP", t => t.IDEMPLOYEE, cascadeDelete: true)
                .ForeignKey("dbo.TOSDOC", t => t.IdTDFSale, cascadeDelete: true)
                .Index(t => t.IdCNType)
                .Index(t => t.IDCLIENT)
                .Index(t => t.IDEMPLOYEE)
                .Index(t => t.IdTDFSale);
            
            CreateTable(
                "dbo.CNTYPE",
                c => new
                    {
                        ID = c.int(nullable: false),
                        TYPECREDITNOTENAME = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CADTYPE",
                c => new
                    {
                        ID = c.int(nullable: false),
                        TYPENAME = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CADP",
                c => new
                    {
                        ID = c.int(nullable: false),
                        IDP = c.int(nullable: false),
                        TOTALDEBT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CREATEDDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PROVIDER", t => t.IDP, cascadeDelete: true)
                .Index(t => t.IDP);
            
            CreateTable(
                "dbo.PROVIDER",
                c => new
                    {
                        ID = c.int(nullable: false),
                        ISACTIVE = c.Boolean(nullable: false),
                        CONTACT = c.String(),
                        ISFOREIGNPROVIDER = c.Boolean(nullable: false),
                        BUSINESSNAME = c.int(nullable: false),
                        CREATEDDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BNAME", t => t.BUSINESSNAME, cascadeDelete: true)
                .Index(t => t.BUSINESSNAME);
            
            CreateTable(
                "dbo.CCACOUNT",
                c => new
                    {
                        ID = c.int(nullable: false),
                        IDC = c.int(nullable: false),
                        TOTALDEBT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CREATEDDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLIENT", t => t.IDC, cascadeDelete: true)
                .Index(t => t.IDC);
            
            CreateTable(
                "dbo.DNOTE",
                c => new
                    {
                        ID = c.int(nullable: false),
                        IDCLIENT = c.int(nullable: false),
                        IDEMPLOYEE = c.int(nullable: false),
                        IDDOCFORSALE = c.int(nullable: false),
                        IDDOCUMENT = c.int(nullable: false),
                        TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLIENT", t => t.IDCLIENT, cascadeDelete: true)
                .ForeignKey("dbo.EMP", t => t.IDEMPLOYEE, cascadeDelete: true)
                .ForeignKey("dbo.TOSDOC", t => t.IDDOCFORSALE, cascadeDelete: true)
                .Index(t => t.IDCLIENT)
                .Index(t => t.IDEMPLOYEE)
                .Index(t => t.IDDOCFORSALE);
            
            CreateTable(
                "dbo.DENOTE",
                c => new
                    {
                        IDENTRYNOTE = c.int(nullable: false),
                        IDPRODUCT = c.int(nullable: false),
                        IDRNOTE = c.int(nullable: false),
                        ENSTATUS = c.int(nullable: false),
                        QUANTITY = c.Int(nullable: false),
                        UNITEPRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CREATEDDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDENTRYNOTE)
                .ForeignKey("dbo.ENOTE", t => t.IDENTRYNOTE)
                .ForeignKey("dbo.SNOTE", t => t.ENSTATUS, cascadeDelete: true)
                .ForeignKey("dbo.PDTO", t => t.IDPRODUCT, cascadeDelete: true)
                .ForeignKey("dbo.RNOTE", t => t.IDRNOTE, cascadeDelete: true)
                .Index(t => t.IDENTRYNOTE)
                .Index(t => t.IDPRODUCT)
                .Index(t => t.IDRNOTE)
                .Index(t => t.ENSTATUS);
            
            CreateTable(
                "dbo.ENOTE",
                c => new
                    {
                        ID = c.int(nullable: false),
                        NPO = c.Int(nullable: false),
                        IDENST = c.int(nullable: false),
                        IDRNOTE = c.int(nullable: false),
                        IDPDOC = c.int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SNOTE", t => t.IDENST, cascadeDelete: true)
                .ForeignKey("dbo.PDOC", t => t.IDPDOC, cascadeDelete: true)
                .ForeignKey("dbo.PORDER", t => t.NPO, cascadeDelete: true)
                .ForeignKey("dbo.RNOTE", t => t.IDRNOTE, cascadeDelete: true)
                .Index(t => t.NPO)
                .Index(t => t.IDENST)
                .Index(t => t.IDRNOTE)
                .Index(t => t.IDPDOC);
            
            CreateTable(
                "dbo.SNOTE",
                c => new
                    {
                        ID = c.int(nullable: false),
                        STATUSNAME = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PDOC",
                c => new
                    {
                        ID = c.int(nullable: false),
                        PROVIDER = c.int(nullable: false),
                        IDDT = c.int(nullable: false),
                        NPORDER = c.Int(nullable: false),
                        CREATEDDATE = c.DateTime(nullable: false),
                        TOTALAMOUNT = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CADTYPE", t => t.IDDT, cascadeDelete: true)
                .ForeignKey("dbo.PROVIDER", t => t.PROVIDER, cascadeDelete: true)
                .ForeignKey("dbo.PORDER", t => t.NPORDER, cascadeDelete: true)
                .Index(t => t.PROVIDER)
                .Index(t => t.IDDT)
                .Index(t => t.NPORDER);
            
            CreateTable(
                "dbo.DPTOSALE",
                c => new
                    {
                        ID = c.int(nullable: false),
                        IDP = c.int(nullable: false),
                        QUANTITY = c.Int(nullable: false),
                        UNITPRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DISCOUNT = c.Decimal(precision: 18, scale: 2),
                        TOTALAMOUNT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDPC = c.int(nullable: false),
                        PO = c.Int(nullable: false),
                        PDoc_Id = c.int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PC", t => t.IDPC, cascadeDelete: true)
                .ForeignKey("dbo.PDTO", t => t.IDP, cascadeDelete: true)
                .ForeignKey("dbo.PORDER", t => t.PO, cascadeDelete: true)
                .ForeignKey("dbo.PDOC", t => t.PDoc_Id)
                .Index(t => t.IDP)
                .Index(t => t.IDPC)
                .Index(t => t.PO)
                .Index(t => t.PDoc_Id);
            
            CreateTable(
                "dbo.PORDER",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        PLACEOFENTRY = c.String(),
                        IDPROVIDER = c.int(nullable: false),
                        CREATEDDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PROVIDER", t => t.IDPROVIDER, cascadeDelete: true)
                .Index(t => t.IDPROVIDER);
            
            CreateTable(
                "dbo.RNOTE",
                c => new
                    {
                        ID = c.int(nullable: false),
                        REASONNAME = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EXTINV",
                c => new
                    {
                        ID = c.int(nullable: false),
                        IDEP = c.int(nullable: false),
                        IDSTORAGE = c.int(nullable: false),
                        PRODUCTDESCRIPTION = c.String(),
                        QUANTITY = c.Int(nullable: false),
                        UNITPRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DISCOUNTRATE = c.Int(nullable: false),
                        MINIMUMSTOCK = c.Int(nullable: false),
                        MAXIMUMSTOCK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EPRODUCT", t => t.IDEP, cascadeDelete: true)
                .ForeignKey("dbo.STOR", t => t.IDSTORAGE, cascadeDelete: true)
                .Index(t => t.IDEP)
                .Index(t => t.IDSTORAGE);
            
            CreateTable(
                "dbo.STOR",
                c => new
                    {
                        ID = c.int(nullable: false),
                        STORAGENAME = c.String(),
                        IDADDRESS = c.int(nullable: false),
                        CREATEDDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ADDRESS", t => t.IDADDRESS, cascadeDelete: true)
                .Index(t => t.IDADDRESS);
            
            CreateTable(
                "dbo.IINV",
                c => new
                    {
                        ID = c.int(nullable: false),
                        IDSTORAGE = c.int(nullable: false),
                        IDIP = c.int(nullable: false),
                        PRODUCTDESCRIPTION = c.String(),
                        QUANTITY = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.IPDCT", t => t.IDIP, cascadeDelete: true)
                .ForeignKey("dbo.STOR", t => t.IDSTORAGE, cascadeDelete: true)
                .Index(t => t.IDSTORAGE)
                .Index(t => t.IDIP);
            
            CreateTable(
                "dbo.IPDCT",
                c => new
                    {
                        ID = c.int(nullable: false),
                        IDPRODUCT = c.int(nullable: false),
                        IDUM = c.int(nullable: false),
                        IDDCT = c.int(nullable: false),
                        IDCC = c.int(nullable: false),
                        IDPL = c.int(nullable: false),
                        PRODUCTDESCRIPTION = c.String(),
                        QUANTITY = c.Int(nullable: false),
                        ACTIVE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CCENTER", t => t.IDCC, cascadeDelete: true)
                .ForeignKey("dbo.PDTO", t => t.IDPRODUCT, cascadeDelete: true)
                .ForeignKey("dbo.PLINE", t => t.IDPL, cascadeDelete: true)
                .ForeignKey("dbo.PTYPE", t => t.IDDCT, cascadeDelete: true)
                .ForeignKey("dbo.UNIT", t => t.IDUM, cascadeDelete: true)
                .Index(t => t.IDPRODUCT)
                .Index(t => t.IDUM)
                .Index(t => t.IDDCT)
                .Index(t => t.IDCC)
                .Index(t => t.IDPL);
            
            CreateTable(
                "dbo.KARDEX",
                c => new
                    {
                        IdKardex = c.int(nullable: false, identity: true),
                        IDMOVEMENTTYPE = c.int(nullable: false),
                        IDPRODUCT = c.int(nullable: false),
                        QUANTITY = c.Int(nullable: false),
                        UNITPRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DISCOUNTRATE = c.Int(nullable: false),
                        TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDSTORAGE = c.int(nullable: false),
                        MOVEMENTDATE = c.DateTime(nullable: false),
                        PREVIOUSBALANCE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NEWBALANCE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PREVIOUSSTOCK = c.Int(nullable: false),
                        NEWSTOCK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdKardex)
                .ForeignKey("dbo.MTYPE", t => t.IDMOVEMENTTYPE, cascadeDelete: true)
                .ForeignKey("dbo.PDTO", t => t.IDPRODUCT, cascadeDelete: true)
                .ForeignKey("dbo.STOR", t => t.IDSTORAGE, cascadeDelete: true)
                .Index(t => t.IDMOVEMENTTYPE)
                .Index(t => t.IDPRODUCT)
                .Index(t => t.IDSTORAGE);
            
            CreateTable(
                "dbo.MTYPE",
                c => new
                    {
                        ID = c.int(nullable: false),
                        MOVIMENTNAME = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MPROVIDER",
                c => new
                    {
                        IdMovementsProvider = c.int(nullable: false, identity: true),
                        IDDTPE = c.int(nullable: false),
                        DOCUMENTID = c.int(nullable: false),
                        INGRESOS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EGRESOS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CREATEDDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdMovementsProvider)
                .ForeignKey("dbo.TOPDOC", t => t.IDDTPE, cascadeDelete: true)
                .Index(t => t.IDDTPE);
            
            CreateTable(
                "dbo.TOPDOC",
                c => new
                    {
                        ID = c.int(nullable: false),
                        NAMEDOCUMENT = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ONOTE",
                c => new
                    {
                        IDONOTE = c.int(nullable: false),
                        IDSALEORDER = c.int(nullable: false),
                        IDONSTATUS = c.int(nullable: false),
                        IDRNOTE = c.int(nullable: false),
                        IDBILL = c.int(nullable: false),
                    })
                .PrimaryKey(t => t.IDONOTE)
                .ForeignKey("dbo.BILL", t => t.IDBILL, cascadeDelete: true)
                .ForeignKey("dbo.SNOTE", t => t.IDONSTATUS, cascadeDelete: true)
                .ForeignKey("dbo.RNOTE", t => t.IDRNOTE, cascadeDelete: true)
                .ForeignKey("dbo.SOR", t => t.IDSALEORDER, cascadeDelete: true)
                .Index(t => t.IDSALEORDER)
                .Index(t => t.IDONSTATUS)
                .Index(t => t.IDRNOTE)
                .Index(t => t.IDBILL);
            
            CreateTable(
                "dbo.SALE",
                c => new
                    {
                        IDSALE = c.int(nullable: false),
                        IDSALEORDER = c.int(nullable: false),
                        IDCLIENT = c.int(nullable: false),
                        IDEMPLOYEE = c.int(nullable: false),
                        IDNOTEOUTPUT = c.int(nullable: false),
                        CREATEDDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDSALE)
                .ForeignKey("dbo.CLIENT", t => t.IDCLIENT, cascadeDelete: true)
                .ForeignKey("dbo.EMP", t => t.IDEMPLOYEE, cascadeDelete: true)
                .ForeignKey("dbo.ONOTE", t => t.IDNOTEOUTPUT, cascadeDelete: true)
                .ForeignKey("dbo.SOR", t => t.IDSALEORDER, cascadeDelete: true)
                .Index(t => t.IDSALEORDER)
                .Index(t => t.IDCLIENT)
                .Index(t => t.IDEMPLOYEE)
                .Index(t => t.IDNOTEOUTPUT);
            
            CreateTable(
                "dbo.SBDISPATCH",
                c => new
                    {
                        ID = c.int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VOUCHER",
                c => new
                    {
                        ID = c.int(nullable: false),
                        IDCLIENT = c.int(nullable: false),
                        IDEMPLOYEE = c.int(nullable: false),
                        IDTDSALE = c.int(nullable: false),
                        TOTAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLIENT", t => t.IDCLIENT, cascadeDelete: true)
                .ForeignKey("dbo.EMP", t => t.IDEMPLOYEE, cascadeDelete: true)
                .ForeignKey("dbo.TOSDOC", t => t.IDTDSALE, cascadeDelete: true)
                .Index(t => t.IDCLIENT)
                .Index(t => t.IDEMPLOYEE)
                .Index(t => t.IDTDSALE);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VOUCHER", "IDTDSALE", "dbo.TOSDOC");
            DropForeignKey("dbo.VOUCHER", "IDEMPLOYEE", "dbo.EMP");
            DropForeignKey("dbo.VOUCHER", "IDCLIENT", "dbo.CLIENT");
            DropForeignKey("dbo.BILL", "SaByDisp_Id", "dbo.SBDISPATCH");
            DropForeignKey("dbo.SALE", "IDSALEORDER", "dbo.SOR");
            DropForeignKey("dbo.SALE", "IDNOTEOUTPUT", "dbo.ONOTE");
            DropForeignKey("dbo.SALE", "IDEMPLOYEE", "dbo.EMP");
            DropForeignKey("dbo.SALE", "IDCLIENT", "dbo.CLIENT");
            DropForeignKey("dbo.ONOTE", "IDSALEORDER", "dbo.SOR");
            DropForeignKey("dbo.ONOTE", "IDRNOTE", "dbo.RNOTE");
            DropForeignKey("dbo.ONOTE", "IDONSTATUS", "dbo.SNOTE");
            DropForeignKey("dbo.ONOTE", "IDBILL", "dbo.BILL");
            DropForeignKey("dbo.MPROVIDER", "IDDTPE", "dbo.TOPDOC");
            DropForeignKey("dbo.KARDEX", "IDSTORAGE", "dbo.STOR");
            DropForeignKey("dbo.KARDEX", "IDPRODUCT", "dbo.PDTO");
            DropForeignKey("dbo.KARDEX", "IDMOVEMENTTYPE", "dbo.MTYPE");
            DropForeignKey("dbo.IINV", "IDSTORAGE", "dbo.STOR");
            DropForeignKey("dbo.IINV", "IDIP", "dbo.IPDCT");
            DropForeignKey("dbo.IPDCT", "IDUM", "dbo.UNIT");
            DropForeignKey("dbo.IPDCT", "IDDCT", "dbo.PTYPE");
            DropForeignKey("dbo.IPDCT", "IDPL", "dbo.PLINE");
            DropForeignKey("dbo.IPDCT", "IDPRODUCT", "dbo.PDTO");
            DropForeignKey("dbo.IPDCT", "IDCC", "dbo.CCENTER");
            DropForeignKey("dbo.EXTINV", "IDSTORAGE", "dbo.STOR");
            DropForeignKey("dbo.TEL", "Storage_IdStorage", "dbo.STOR");
            DropForeignKey("dbo.STOR", "IDADDRESS", "dbo.ADDRESS");
            DropForeignKey("dbo.EXTINV", "IDEP", "dbo.EPRODUCT");
            DropForeignKey("dbo.DENOTE", "IDRNOTE", "dbo.RNOTE");
            DropForeignKey("dbo.DENOTE", "IDPRODUCT", "dbo.PDTO");
            DropForeignKey("dbo.DENOTE", "ENSTATUS", "dbo.SNOTE");
            DropForeignKey("dbo.DENOTE", "IDENTRYNOTE", "dbo.ENOTE");
            DropForeignKey("dbo.ENOTE", "IDRNOTE", "dbo.RNOTE");
            DropForeignKey("dbo.ENOTE", "NPO", "dbo.PORDER");
            DropForeignKey("dbo.ENOTE", "IDPDOC", "dbo.PDOC");
            DropForeignKey("dbo.PDOC", "NPORDER", "dbo.PORDER");
            DropForeignKey("dbo.PDOC", "PROVIDER", "dbo.PROVIDER");
            DropForeignKey("dbo.DPTOSALE", "PDoc_Id", "dbo.PDOC");
            DropForeignKey("dbo.DPTOSALE", "PO", "dbo.PORDER");
            DropForeignKey("dbo.PORDER", "IDPROVIDER", "dbo.PROVIDER");
            DropForeignKey("dbo.DPTOSALE", "IDP", "dbo.PDTO");
            DropForeignKey("dbo.DPTOSALE", "IDPC", "dbo.PC");
            DropForeignKey("dbo.PDOC", "IDDT", "dbo.CADTYPE");
            DropForeignKey("dbo.ENOTE", "IDENST", "dbo.SNOTE");
            DropForeignKey("dbo.DNOTE", "IDDOCFORSALE", "dbo.TOSDOC");
            DropForeignKey("dbo.DNOTE", "IDEMPLOYEE", "dbo.EMP");
            DropForeignKey("dbo.DNOTE", "IDCLIENT", "dbo.CLIENT");
            DropForeignKey("dbo.CCACOUNT", "IDC", "dbo.CLIENT");
            DropForeignKey("dbo.CADP", "IDP", "dbo.PROVIDER");
            DropForeignKey("dbo.TEL", "Provider_Id", "dbo.PROVIDER");
            DropForeignKey("dbo.CITY", "Provider_Id", "dbo.PROVIDER");
            DropForeignKey("dbo.PROVIDER", "BUSINESSNAME", "dbo.BNAME");
            DropForeignKey("dbo.ADDRESS", "Provider_Id", "dbo.PROVIDER");
            DropForeignKey("dbo.CNOTE", "IdTDFSale", "dbo.TOSDOC");
            DropForeignKey("dbo.CNOTE", "IDEMPLOYEE", "dbo.EMP");
            DropForeignKey("dbo.CNOTE", "IdCNType", "dbo.CNTYPE");
            DropForeignKey("dbo.CNOTE", "IDCLIENT", "dbo.CLIENT");
            DropForeignKey("dbo.CSALE", "IDBILL", "dbo.BILL");
            DropForeignKey("dbo.COLLECTION", "IDTDFS", "dbo.TOSDOC");
            DropForeignKey("dbo.COLLECTION", "IDPAYm", "dbo.PMETHOD");
            DropForeignKey("dbo.COLLECTION", "IDCLIENT", "dbo.CLIENT");
            DropForeignKey("dbo.COLLECTION", "IDCHECK", "dbo.CHECK");
            DropForeignKey("dbo.COLLECTION", "IDBANK", "dbo.BANK");
            DropForeignKey("dbo.CHECK", "IDCLIENT", "dbo.CLIENT");
            DropForeignKey("dbo.BOEX", "IDEMPLOYEE", "dbo.EMP");
            DropForeignKey("dbo.BOEX", "IDCLIENT", "dbo.CLIENT");
            DropForeignKey("dbo.ODETAIL", "Bill_IdBill", "dbo.BILL");
            DropForeignKey("dbo.ODETAIL", "IDSORDER", "dbo.SOR");
            DropForeignKey("dbo.SOR", "IDPCONDITION", "dbo.PC");
            DropForeignKey("dbo.SOR", "IDEMPLOYEE", "dbo.EMP");
            DropForeignKey("dbo.SOR", "IDCLIENT", "dbo.CLIENT");
            DropForeignKey("dbo.ODETAIL", "IDXP", "dbo.EPRODUCT");
            DropForeignKey("dbo.EPRODUCT", "IDM", "dbo.UNIT");
            DropForeignKey("dbo.EPRODUCT", "IDPT", "dbo.PTYPE");
            DropForeignKey("dbo.EPRODUCT", "IDPL", "dbo.PLINE");
            DropForeignKey("dbo.EPRODUCT", "IDPRODUCT", "dbo.PDTO");
            DropForeignKey("dbo.BILL", "IDEMPLOYEE", "dbo.EMP");
            DropForeignKey("dbo.BILL", "IDCLIENT", "dbo.CLIENT");
            DropForeignKey("dbo.TEL", "Client_Id", "dbo.CLIENT");
            DropForeignKey("dbo.CLIENT", "IDRUC", "dbo.RUC");
            DropForeignKey("dbo.FAX", "Client_Id", "dbo.CLIENT");
            DropForeignKey("dbo.CLIENT", "IDEMPLOYEE", "dbo.EMP");
            DropForeignKey("dbo.TEL", "Employee_Id", "dbo.EMP");
            DropForeignKey("dbo.ADDRESS", "Employee_Id", "dbo.EMP");
            DropForeignKey("dbo.EMAIL", "Client_Id", "dbo.CLIENT");
            DropForeignKey("dbo.CITY", "Client_Id", "dbo.CLIENT");
            DropForeignKey("dbo.ADDRESS", "Client_Id", "dbo.CLIENT");
            DropForeignKey("dbo.TEL", "Bank_IdBank", "dbo.BANK");
            DropForeignKey("dbo.ADDRESS", "Bank_IdBank", "dbo.BANK");
            DropIndex("dbo.VOUCHER", new[] { "IDTDSALE" });
            DropIndex("dbo.VOUCHER", new[] { "IDEMPLOYEE" });
            DropIndex("dbo.VOUCHER", new[] { "IDCLIENT" });
            DropIndex("dbo.SALE", new[] { "IDNOTEOUTPUT" });
            DropIndex("dbo.SALE", new[] { "IDEMPLOYEE" });
            DropIndex("dbo.SALE", new[] { "IDCLIENT" });
            DropIndex("dbo.SALE", new[] { "IDSALEORDER" });
            DropIndex("dbo.ONOTE", new[] { "IDBILL" });
            DropIndex("dbo.ONOTE", new[] { "IDRNOTE" });
            DropIndex("dbo.ONOTE", new[] { "IDONSTATUS" });
            DropIndex("dbo.ONOTE", new[] { "IDSALEORDER" });
            DropIndex("dbo.MPROVIDER", new[] { "IDDTPE" });
            DropIndex("dbo.KARDEX", new[] { "IDSTORAGE" });
            DropIndex("dbo.KARDEX", new[] { "IDPRODUCT" });
            DropIndex("dbo.KARDEX", new[] { "IDMOVEMENTTYPE" });
            DropIndex("dbo.IPDCT", new[] { "IDPL" });
            DropIndex("dbo.IPDCT", new[] { "IDCC" });
            DropIndex("dbo.IPDCT", new[] { "IDDCT" });
            DropIndex("dbo.IPDCT", new[] { "IDUM" });
            DropIndex("dbo.IPDCT", new[] { "IDPRODUCT" });
            DropIndex("dbo.IINV", new[] { "IDIP" });
            DropIndex("dbo.IINV", new[] { "IDSTORAGE" });
            DropIndex("dbo.STOR", new[] { "IDADDRESS" });
            DropIndex("dbo.EXTINV", new[] { "IDSTORAGE" });
            DropIndex("dbo.EXTINV", new[] { "IDEP" });
            DropIndex("dbo.PORDER", new[] { "IDPROVIDER" });
            DropIndex("dbo.DPTOSALE", new[] { "PDoc_Id" });
            DropIndex("dbo.DPTOSALE", new[] { "PO" });
            DropIndex("dbo.DPTOSALE", new[] { "IDPC" });
            DropIndex("dbo.DPTOSALE", new[] { "IDP" });
            DropIndex("dbo.PDOC", new[] { "NPORDER" });
            DropIndex("dbo.PDOC", new[] { "IDDT" });
            DropIndex("dbo.PDOC", new[] { "PROVIDER" });
            DropIndex("dbo.ENOTE", new[] { "IDPDOC" });
            DropIndex("dbo.ENOTE", new[] { "IDRNOTE" });
            DropIndex("dbo.ENOTE", new[] { "IDENST" });
            DropIndex("dbo.ENOTE", new[] { "NPO" });
            DropIndex("dbo.DENOTE", new[] { "ENSTATUS" });
            DropIndex("dbo.DENOTE", new[] { "IDRNOTE" });
            DropIndex("dbo.DENOTE", new[] { "IDPRODUCT" });
            DropIndex("dbo.DENOTE", new[] { "IDENTRYNOTE" });
            DropIndex("dbo.DNOTE", new[] { "IDDOCFORSALE" });
            DropIndex("dbo.DNOTE", new[] { "IDEMPLOYEE" });
            DropIndex("dbo.DNOTE", new[] { "IDCLIENT" });
            DropIndex("dbo.CCACOUNT", new[] { "IDC" });
            DropIndex("dbo.PROVIDER", new[] { "BUSINESSNAME" });
            DropIndex("dbo.CADP", new[] { "IDP" });
            DropIndex("dbo.CNOTE", new[] { "IdTDFSale" });
            DropIndex("dbo.CNOTE", new[] { "IDEMPLOYEE" });
            DropIndex("dbo.CNOTE", new[] { "IDCLIENT" });
            DropIndex("dbo.CNOTE", new[] { "IdCNType" });
            DropIndex("dbo.CSALE", new[] { "IDBILL" });
            DropIndex("dbo.COLLECTION", new[] { "IDTDFS" });
            DropIndex("dbo.COLLECTION", new[] { "IDBANK" });
            DropIndex("dbo.COLLECTION", new[] { "IDPAYm" });
            DropIndex("dbo.COLLECTION", new[] { "IDCHECK" });
            DropIndex("dbo.COLLECTION", new[] { "IDCLIENT" });
            DropIndex("dbo.CHECK", new[] { "IDCLIENT" });
            DropIndex("dbo.BOEX", new[] { "IDEMPLOYEE" });
            DropIndex("dbo.BOEX", new[] { "IDCLIENT" });
            DropIndex("dbo.SOR", new[] { "IDPCONDITION" });
            DropIndex("dbo.SOR", new[] { "IDEMPLOYEE" });
            DropIndex("dbo.SOR", new[] { "IDCLIENT" });
            DropIndex("dbo.EPRODUCT", new[] { "IDPL" });
            DropIndex("dbo.EPRODUCT", new[] { "IDPT" });
            DropIndex("dbo.EPRODUCT", new[] { "IDM" });
            DropIndex("dbo.EPRODUCT", new[] { "IDPRODUCT" });
            DropIndex("dbo.ODETAIL", new[] { "Bill_IdBill" });
            DropIndex("dbo.ODETAIL", new[] { "IDSORDER" });
            DropIndex("dbo.ODETAIL", new[] { "IDXP" });
            DropIndex("dbo.FAX", new[] { "Client_Id" });
            DropIndex("dbo.EMAIL", new[] { "Client_Id" });
            DropIndex("dbo.CITY", new[] { "Provider_Id" });
            DropIndex("dbo.CITY", new[] { "Client_Id" });
            DropIndex("dbo.CLIENT", new[] { "IDEMPLOYEE" });
            DropIndex("dbo.CLIENT", new[] { "IDRUC" });
            DropIndex("dbo.BILL", new[] { "SaByDisp_Id" });
            DropIndex("dbo.BILL", new[] { "IDEMPLOYEE" });
            DropIndex("dbo.BILL", new[] { "IDCLIENT" });
            DropIndex("dbo.TEL", new[] { "Storage_IdStorage" });
            DropIndex("dbo.TEL", new[] { "Provider_Id" });
            DropIndex("dbo.TEL", new[] { "Client_Id" });
            DropIndex("dbo.TEL", new[] { "Employee_Id" });
            DropIndex("dbo.TEL", new[] { "Bank_IdBank" });
            DropIndex("dbo.ADDRESS", new[] { "Provider_Id" });
            DropIndex("dbo.ADDRESS", new[] { "Employee_Id" });
            DropIndex("dbo.ADDRESS", new[] { "Client_Id" });
            DropIndex("dbo.ADDRESS", new[] { "Bank_IdBank" });
            DropTable("dbo.VOUCHER");
            DropTable("dbo.SBDISPATCH");
            DropTable("dbo.SALE");
            DropTable("dbo.ONOTE");
            DropTable("dbo.TOPDOC");
            DropTable("dbo.MPROVIDER");
            DropTable("dbo.MTYPE");
            DropTable("dbo.KARDEX");
            DropTable("dbo.IPDCT");
            DropTable("dbo.IINV");
            DropTable("dbo.STOR");
            DropTable("dbo.EXTINV");
            DropTable("dbo.RNOTE");
            DropTable("dbo.PORDER");
            DropTable("dbo.DPTOSALE");
            DropTable("dbo.PDOC");
            DropTable("dbo.SNOTE");
            DropTable("dbo.ENOTE");
            DropTable("dbo.DENOTE");
            DropTable("dbo.DNOTE");
            DropTable("dbo.CCACOUNT");
            DropTable("dbo.PROVIDER");
            DropTable("dbo.CADP");
            DropTable("dbo.CADTYPE");
            DropTable("dbo.CNTYPE");
            DropTable("dbo.CNOTE");
            DropTable("dbo.CSALE");
            DropTable("dbo.CCENTER");
            DropTable("dbo.TOSDOC");
            DropTable("dbo.PMETHOD");
            DropTable("dbo.COLLECTION");
            DropTable("dbo.CHECK");
            DropTable("dbo.BNAME");
            DropTable("dbo.BOEX");
            DropTable("dbo.PC");
            DropTable("dbo.SOR");
            DropTable("dbo.UNIT");
            DropTable("dbo.PTYPE");
            DropTable("dbo.PLINE");
            DropTable("dbo.PDTO");
            DropTable("dbo.EPRODUCT");
            DropTable("dbo.ODETAIL");
            DropTable("dbo.RUC");
            DropTable("dbo.FAX");
            DropTable("dbo.EMP");
            DropTable("dbo.EMAIL");
            DropTable("dbo.CITY");
            DropTable("dbo.CLIENT");
            DropTable("dbo.BILL");
            DropTable("dbo.TEL");
            DropTable("dbo.BANK");
            DropTable("dbo.ADDRESS");
        }
    }
}
