using Acme.Common;
using System;
using static Acme.Common.LoggingService;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried investory
    /// </summary>

    public class Product
    {

        public const double InchesPerMeter = 39.37;
        public  readonly decimal MinimumPrice;

        #region constructor
        public Product()
        {
            Console.WriteLine("Product instance is created");
            this.MinimumPrice = .96m;
        }

        public Product(int productId, string productName, string description): this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            if (ProductName.StartsWith("Bulk"))
            {
                this.MinimumPrice = 9.99m;
            }
            

            Console.WriteLine($"Product instance is intantiated and has name {ProductName}");
        }
        #endregion

        #region properties

        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }
            

        private string productName;

        public string ProductName
        {
            get
            {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {   
                if(value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Nanme can not be more than 20 characters";
                }
                else
                {
                    productName = value;
                }             
            }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int productId;
        public int ProductId    
        {
            get { return productId; }
            set { productId = value; } 
        }

        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get
            {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }


        #endregion

        #region methods
        public string SayHello()
        {
            //Vendor vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Poduct Class");


            EmailService emailservice = new EmailService();
            emailservice.SendMessage("New Product", this.ProductName, "sale@abc.com");
            var result = LogAction("Say Hello");

            return "Hello " +
                    ProductName +
                    "(" + ProductId + "): " +
                    Description +
                    " Available on: " +
                    AvailabilityDate?.ToShortDateString();

        }

        #endregion
    }
}
