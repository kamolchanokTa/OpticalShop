using OpticalShop.Core.Domain;
using OpticalShop.Models.Products;
using OpticalShop.Service.Interface;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System;
using System.IO;
using System.Web;
using OpticalShop.Infrastructure;
using OpticalShop.Core;
using System.Drawing;

namespace OpticalShop.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        private const int MAX_UPLOAD_IMAGE_WIDTH = 800;
        private const int MAX_UPLOAD_IMAGE_HEIGHT = 600;

        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductOverview()
        {
            return View();
        }

        public ActionResult Lense(string brand = null)
        {
            LenseOverviewModel model = new LenseOverviewModel();
            List<Lense> totalLense = _productService.GetLense().ToList();
            List<Lense> lenses;
            if (string.IsNullOrEmpty(brand))
            {
                lenses = _productService.GetLense().ToList();
            }
            else
            {
                model.SelectedBrand = brand;
                lenses = _productService.GetLense().Where(m => m.Brand == brand).ToList();
            }
            if(lenses != null)
            {
                model.Lenses = TransformLenseToLenseModel(lenses);
                model.Categories = totalLense.Select(m => new SelectListItem { Text = m.Category, Value =m.Category}).Distinct().ToList();
                model.Chromatics = totalLense.Select(m => new SelectListItem { Text = m.Chromatics, Value = m.Chromatics }).Distinct().ToList();
                model.FamiliesLense = totalLense.Select(m => new SelectListItem { Text = m.FamilyLense, Value = m.FamilyLense }).Distinct().ToList();
                model.Indexs = totalLense.Select(m => new SelectListItem { Text = m.Index, Value = m.Index }).Distinct().ToList();
                model.Materials = totalLense.Select(m => new SelectListItem { Text = m.Material, Value = m.Material }).Distinct().ToList();
                model.Process = totalLense.Select(m => new SelectListItem { Text = m.Process, Value = m.Process }).Distinct().ToList();
                model.Brands = totalLense.Select(m => new SelectListItem { Text = m.Brand, Value = m.Brand }).Distinct().ToList();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Lense(LenseOverviewModel model)
        {
            List<Lense> lenses = _productService.GetLense().ToList();
            if(lenses.Count > 0)
            {
                model.Categories = lenses.Select(m => new SelectListItem { Text = m.Category, Value = m.Category }).Distinct().ToList();
                model.Chromatics = lenses.Select(m => new SelectListItem { Text = m.Chromatics, Value = m.Chromatics }).Distinct().ToList();
                model.FamiliesLense = lenses.Select(m => new SelectListItem { Text = m.FamilyLense, Value = m.FamilyLense }).Distinct().ToList();
                model.Indexs = lenses.Select(m => new SelectListItem { Text = m.Index, Value = m.Index }).Distinct().ToList();
                model.Materials = lenses.Select(m => new SelectListItem { Text = m.Material, Value = m.Material }).Distinct().ToList();
                model.Process = lenses.Select(m => new SelectListItem { Text = m.Process, Value = m.Process }).Distinct().ToList();
                model.Brands = lenses.Select(m => new SelectListItem { Text = m.Brand, Value = m.Brand }).Distinct().ToList();
            }

            if (!String.IsNullOrEmpty(model.SelectedBrand))
            {
                lenses = lenses.Where(m => m.Brand == model.SelectedBrand).ToList();
            }

            if (!String.IsNullOrEmpty(model.SelectedCategories))
            {
                lenses = lenses.Where(m => m.Category == model.SelectedCategories).ToList();
            }

            if (!String.IsNullOrEmpty(model.SelectedChromatics))
            {
                lenses = lenses.Where(m => m.Chromatics == model.SelectedChromatics).ToList();
            }

            if (!String.IsNullOrEmpty(model.SelectedFamiliesLense))
            {
                lenses = lenses.Where(m => m.FamilyLense == model.SelectedFamiliesLense).ToList();
            }

            if (!String.IsNullOrEmpty(model.SelectedIndexs))
            {
                lenses = lenses.Where(m => m.Index == model.SelectedIndexs).ToList();
            }

            if (!String.IsNullOrEmpty(model.SelectedMaterials))
            {
                lenses = lenses.Where(m => m.Material == model.SelectedMaterials).ToList();
            }

            if (!String.IsNullOrEmpty(model.SelectedProcess))
            {
                lenses = lenses.Where(m => m.Process == model.SelectedProcess).ToList();
            }

            if (lenses != null)
            {
                model.Lenses = TransformLenseToLenseModel(lenses);
            }
            return View(model);
        }


        public ActionResult AddLense(string brand,string Id)
        {
            LenseOverviewModel model = new LenseOverviewModel();
            if (!string.IsNullOrEmpty(Id))
            {
                var lens = this._productService.GetLense().Where(m => m.Id == Id).ToList();
                model.Lense = TransformLenseToLenseModel(lens).FirstOrDefault();
            }
            else
            {
                model.Lense = new LenseModel();
            }
            List<Lense> totalLense = _productService.GetLense().ToList();
            model.SelectedBrand = brand;
            if (totalLense != null)
            {
                model.Categories = totalLense.Select(m => new SelectListItem { Text = m.Category, Value = m.Category }).Distinct().ToList();
                model.Chromatics = totalLense.Select(m => new SelectListItem { Text = m.Chromatics, Value = m.Chromatics }).Distinct().ToList();
                model.FamiliesLense = totalLense.Select(m => new SelectListItem { Text = m.FamilyLense, Value = m.FamilyLense }).Distinct().ToList();
                model.Indexs = totalLense.Select(m => new SelectListItem { Text = m.Index, Value = m.Index }).Distinct().ToList();
                model.Materials = totalLense.Select(m => new SelectListItem { Text = m.Material, Value = m.Material }).Distinct().ToList();
                model.Process = totalLense.Select(m => new SelectListItem { Text = m.Process, Value = m.Process }).Distinct().ToList();
                model.Brands = totalLense.Select(m => new SelectListItem { Text = m.Brand, Value = m.Brand }).Distinct().ToList();

            }
            
            model.Lense.Brand = brand;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddLense(LenseOverviewModel model)
        {
            try
            {
                List<Lense> totalLense = _productService.GetLense().ToList();
                if (totalLense != null)
                {
                    model.Categories = totalLense.Select(m => new SelectListItem { Text = m.Category, Value = m.Category }).Distinct().ToList();
                    model.Chromatics = totalLense.Select(m => new SelectListItem { Text = m.Chromatics, Value = m.Chromatics }).Distinct().ToList();
                    model.FamiliesLense = totalLense.Select(m => new SelectListItem { Text = m.FamilyLense, Value = m.FamilyLense }).Distinct().ToList();
                    model.Indexs = totalLense.Select(m => new SelectListItem { Text = m.Index, Value = m.Index }).Distinct().ToList();
                    model.Materials = totalLense.Select(m => new SelectListItem { Text = m.Material, Value = m.Material }).Distinct().ToList();
                    model.Process = totalLense.Select(m => new SelectListItem { Text = m.Process, Value = m.Process }).Distinct().ToList();
                    model.Brands = totalLense.Select(m => new SelectListItem { Text = m.Brand, Value = m.Brand }).Distinct().ToList();

                }
                Lense lense = TransformLenseModelToLense(model.Lense);
                if (!String.IsNullOrEmpty(model.Lense.LenseId))
                {
                    lense.Id = model.Lense.LenseId;
                }
                _productService.InsertLense(lense);
                SuccessNotification("Adding Lense successfully");
            }
            catch(Exception ex)
            {
                ErrorNotification(ex);
            }
            return View(model);
        }

        public ActionResult DeleteProduct(string Id)
        {
            if (!String.IsNullOrEmpty(Id))
            {
                try
                {
                    this._productService.DeleteProduct(Id);
                    return Json(new
                    {
                        IsSuccess = true,
                        Message = "Done for delete product "
                    });
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        IsSuccess = true,
                        Message = ex.Message
                    });
                }
            }
            else
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = "No Id product"
                });
            }
        }
        public ActionResult DeleteLense(string Id)
        {
            if (!String.IsNullOrEmpty(Id))
            {
                try
                {
                    this._productService.DeleteLense(Id);
                    return Json(new
                    {
                        IsSuccess = true,
                        Message = "Done for delete lense "
                    });
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        IsSuccess = true,
                        Message = ex.Message
                    });
                }
            }
            else
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = "No Id lense"
                });
            }

        }

        public ActionResult AddProduct(string productType, string productId)
        {
            ProductModel model = new ProductModel();
            var productsbrand = this._productService.GetProducts().Where(m => m.ProductType != "ContactLense").Select(m => m.Brand).Distinct().ToList();
            if (!string.IsNullOrEmpty(productId))
            {
                var products = this._productService.GetProducts().Where(m => m.Id == productId).ToList();
                model = TransformProductToProductModel(products).FirstOrDefault();
            }
            if (productsbrand != null)
                model.Brands = productsbrand.Select(m => new SelectListItem { Text = m, Value = m }).Distinct().ToList();
            model.ProductType = productType;
            return View(model);

        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel model)
        {
            try
            {
                var products = this._productService.GetProducts().Where(m => m.ProductType != "ContactLense").Select(m => m.Brand).Distinct().ToList();
                if (products != null)
                    model.Brands = products.Select(m => new SelectListItem { Text = m, Value = m }).Distinct().ToList();
                model.ProductImage = GetByteImage(model.Image);
                Product product = TransformProductModelToProduct(model);
                if (!string.IsNullOrEmpty(model.Id)) { product.Id = model.Id; }
                this._productService.InsertProduct(product);
                SuccessNotification("Adding product successfully");
            }
            catch (Exception ex)
            {
                ErrorNotification(ex);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddContactLense(ProductModel model)
        {
            try
            {
                var products = this._productService.GetProducts().Where(m => m.ProductType != "ContactLense").Select(m => m.Brand).Distinct().ToList();
                if (products != null)
                    model.Brands = products.Select(m => new SelectListItem { Text = m, Value = m }).Distinct().ToList();
                model.ProductImage = GetByteImage(model.Image);
                Product product = TransformProductModelToContactLense(model);
                if (!string.IsNullOrEmpty(model.Id))
                    product.Id = model.Id;
                this._productService.InsertProduct(product);
                SuccessNotification("Adding ContactLense successfully");
            }
            catch (Exception ex)
            {
                ErrorNotification(ex);
            }
            return View(model);
        }

        public ActionResult AddContactLense(string productType, string Id)
        {
            ProductModel model = new ProductModel();
            if (!string.IsNullOrEmpty(Id))
            {
                var product = this._productService.GetProducts().Where(m => m.Id == Id).ToList();
                model = TransformContactLenseToProductModel(product).FirstOrDefault();
            }
            model.ProductType = productType;
            var products = this._productService.GetProducts().Where(m => m.ProductType == productType).Select(m => m.Brand).Distinct().ToList();
            if (products != null)
                model.Brands = products.Select(m => new SelectListItem { Text = m, Value = m }).Distinct().ToList();
            return View(model);
        }

        public ActionResult ContactLense(string productType)
        {
            ProductOverviewModel model = new ProductOverviewModel();
            model.ProductType = productType;
            List<Product> products;
            if (string.IsNullOrEmpty(productType))
            {
                products = this._productService.GetProducts().Where(m => m.ProductType == "ContactLense").ToList();
            }
            else
            {
                products = this._productService.GetProducts().Where(m => m.ProductType == productType).ToList();
            }
            if (products != null)
            {
                model.Products = TransformContactLenseToProductModel(products);
            }
            return View(model);
        }


        public ActionResult Product(string productType)
        {
            ProductOverviewModel model = new ProductOverviewModel();
            model.ProductType = productType;
            List<Product> products; 
            if(string.IsNullOrEmpty(productType))
            {
                products = this._productService.GetProducts().Where(m => m.ProductType != "ContactLense").ToList();
            }
            else
            {
                products = this._productService.GetProducts().Where(m => m.ProductType == productType).ToList();
            }
            if(products != null)
            {
                model.Products = TransformProductToProductModel(products);
            }
            return View(model);
        }

        public FileContentResult ImageDisplay(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var image = Convert.FromBase64String(this._productService.GetProducts().FirstOrDefault(m => m.Id == id).ProductImage);
                if (image.Length > 0)
                {
                    return File(image, "image/png");
                }
                else
                {
                    return null;
                }
            }
            else { return null; }
        }

        private Product TransformProductModelToProduct1(ProductModel model)
        {
            return  new Product
            {
                Price = model.Price,
                ProductImage = Convert.ToBase64String(model.ProductImage),
                Brand = model.Brand,
                ProductName = model.ProductName,
                Add = model.Add,
                Axis = model.Axis,
                Coating = model.Coating,
                Cyl = model.Cyl,
                ProductType = model.ProductType,
                Sph = model.Sph,
                Tint = model.Tint,
                InStock = model.InStock,
            };

        }

        private Product TransformProductModelToProduct(ProductModel model)
        {
            return new Product
            {
                Price = model.Price,
                ProductImage = Convert.ToBase64String(model.ProductImage),
                Brand = string.IsNullOrEmpty(model.BrandText) ? model.Brand : model.BrandText,
                ProductName = model.ProductName,
                ProductType = model.ProductType,
                InStock = model.InStock,
            };

        }

        private Product TransformProductModelToContactLense(ProductModel model)
        {
            return new Product
            {
                Price = model.Price,
                ProductImage = Convert.ToBase64String(model.ProductImage),
                Brand = string.IsNullOrEmpty(model.BrandText) ? model.Brand : model.BrandText,
                ProductName = model.ProductName,
                Add = model.Add,
                Axis = model.Axis,
                Coating = model.Coating,
                Cyl = model.Cyl,
                ProductType = model.ProductType,
                Sph = model.Sph,
                Tint = model.Tint,
                InStock = model.InStock,
            };

        }

        private List<ProductModel> TransformProductToProductModel(List<Product> products)
        {
            List<ProductModel> model = products.Select(m => new ProductModel
            {
                Brand = m.Brand,
                Price = m.Price,
                ProductName = m.ProductName,
                ProductType = m.ProductType,
                ProductImage = Convert.FromBase64String(m.ProductImage),
                Id = m.Id,
                InStock = m.InStock,
            }).ToList();
            return model;
        }

        private List<ProductModel> TransformContactLenseToProductModel(List<Product> products)
        {
            List<ProductModel> model = products.Select(m => new ProductModel
            {
                Add = m.Add,
                Brand = m.Brand,
                Axis = m.Axis,
                Cyl = m.Cyl,
                Price = m.Price,
                ProductName = m.ProductName,
                ProductType = m.ProductType,
                Sph = m.Sph,
                Tint = m.Tint,
                ProductImage = Convert.FromBase64String(m.ProductImage),
                Id = m.Id,
                InStock = m.InStock,
            }).ToList();
            return model;
        }

        private List<ProductModel> TransformProductToProductModel1(List<Product> products)
        {
            List<ProductModel> model = products.Select(m => new ProductModel
            {
                Add = m.Add,
                Brand = m.Brand,
                Axis = m.Axis,
                Coating = m.Coating,
                Cyl = m.Cyl,
                Price = m.Price,
                ProductName = m.ProductName,
                ProductType = m.ProductType,
                Sph = m.Sph,
                Tint = m.Tint,
                ProductImage = Convert.FromBase64String(m.ProductImage),
                InStock = m.InStock,
            }).ToList();
            return model;
        }



        private Lense TransformLenseModelToLense(LenseModel lense)
        {
            Lense Lense = new Lense()
            {
                ADDMAX = lense.ADDMAX,
                Brand = lense.Brand,
                Category = string.IsNullOrEmpty(lense.CategoryText) ? lense.Category : lense.CategoryText,
                Chromatics = string.IsNullOrEmpty(lense.ChromaticsText) ? lense.Chromatics : lense.ChromaticsText,                
                CYLMAX = lense.CYLMAX,
                CYLMIN = lense.CYLMIN,
                FamilyLense = string.IsNullOrEmpty(lense.FamilyLenseText) ? lense.FamilyLense : lense.FamilyLenseText,
                Index = string.IsNullOrEmpty(lense.IndexText) ? lense.Index : lense.IndexText,
                Material = string.IsNullOrEmpty(lense.MaterialText) ? lense.Material : lense.MaterialText,
                Process = string.IsNullOrEmpty(lense.ProcessText) ? lense.Process : lense.ProcessText,
                ProductName = lense.ProductName,
                ProductType = lense.ProductType,
                SPHMAX = lense.SPHMAX,
                SPHMIN = lense.SPHMIN,
                Type = lense.Type,
                Price = lense.Price,
                InStock = lense.InStock,
            };
            return Lense;
        }

        private List<LenseModel> TransformLenseToLenseModel(List<Lense> lenses)
        {
            List<LenseModel> model = lenses.Select(m => new LenseModel
            {
               ADDMAX = m.ADDMAX,
               ADDMIN = m.ADDMIN,
               Brand = m.Brand,
               Category = m.Category,
               Chromatics = m.Chromatics,
               CYLMAX = m.CYLMAX,
               CYLMIN = m.CYLMIN,
               FamilyLense = m.FamilyLense,
               Index = m.Index,
               Material = m.Material,
               Process = m.Process,
               ProductName = m.ProductName,
               ProductType =m.ProductType,
               SPHMAX = m.SPHMAX,
               SPHMIN = m.SPHMIN,
               Type = m.Type,
               LenseId = m.Id,
               Price = m.Price,
               InStock = m.InStock,
            }).ToList();

            return model;
        }

        private byte[] GetByteImage(HttpPostedFileBase Imagefile)
        {
            if (ModelState.IsValid)
            {
                if (Imagefile != null && Imagefile.ContentLength > 0)
                {
                    if (!WebConfiguration.ValidateImageType.Contains(Imagefile.ContentType))
                    {
                        ModelState.AddModelError(String.Empty, "Please choose either a GIF, JPG or PNG image.");
                        return null;
                    }
                    else
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            Stream resizedStream = ImageUtility.ResizeGdi(Imagefile.InputStream, new Size(MAX_UPLOAD_IMAGE_WIDTH, MAX_UPLOAD_IMAGE_HEIGHT));

                            resizedStream.CopyTo(ms);

                            byte[] arrayImage = ms.GetBuffer();
                            return arrayImage;
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}