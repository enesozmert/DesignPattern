using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Builder design pattern");
            ProductDirector director = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();
            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);
        }

        #region TodoRegion

        //TODO : Builder.
        //TODO : İş katmanlarında if yazmay engelliyor soyutlama ile minimize ediyoruz.

        #endregion

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string CategoryName { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal DiscountedPrice { get; set; }
            public bool DiscountApplied { get; set; }
        }

        //Abstract builder yazıyoruz:
        public abstract class ProductBuilder
        {
            public abstract void GetProductData();
            public abstract void ApplyDiscount();
            public abstract ProductViewModel GetModel();
        }

        class NewCustomerProductBuilder : ProductBuilder
        {
            private ProductViewModel _productViewModel = new ProductViewModel();

            public override void GetProductData()
            {
                _productViewModel.Id = 1;
                _productViewModel.CategoryName = "Beverages";
                _productViewModel.ProductName = "Chai";
                _productViewModel.UnitPrice = 20;
            }

            public override void ApplyDiscount()
            {
                _productViewModel.DiscountedPrice = _productViewModel.UnitPrice * (decimal) 0.90;
                _productViewModel.DiscountApplied = true;
            }

            public override ProductViewModel GetModel()
            {
                return _productViewModel;
            }
        }

        class OldCustomerProductBuilder : ProductBuilder
        {
            private ProductViewModel _productViewModel = new ProductViewModel();

            public override void GetProductData()
            {
                _productViewModel.Id = 1;
                _productViewModel.CategoryName = "Beverages";
                _productViewModel.ProductName = "Chai";
                _productViewModel.UnitPrice = 20;
            }

            public override void ApplyDiscount()
            {
                _productViewModel.DiscountedPrice = _productViewModel.UnitPrice;
                _productViewModel.DiscountApplied = false;
            }

            public override ProductViewModel GetModel()
            {
                return _productViewModel;
            }
        }

        public class ProductDirector
        {
            public void GenerateProduct(ProductBuilder productBuilder)
            {
                productBuilder.GetProductData();
                productBuilder.ApplyDiscount();
            }
        }
    }
}