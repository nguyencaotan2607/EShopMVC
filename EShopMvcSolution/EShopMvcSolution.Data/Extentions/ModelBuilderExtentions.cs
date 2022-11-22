using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopMvcSolution.Data.Entity;
using EShopMvcSolution.Data.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EShopMvcSolution.Data.Extentions
{
    public static class ModelBuilderExtentions
    {


        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "This is Home Page of EshopMvc" },
               new AppConfig() { Key = "HomeKeyword", Value = "This is Keyword of EShopMvc" },
               new AppConfig() { Key = "HomeDescription", Value = "This is Description of EshopMvc" }
               );

            // Data Seeding

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", Isdefault = true },
                new Language() { Id = "en-US", Name = "EngLish", Isdefault =false},
                new Language() { Id = "Korea", Name = "Korea", Isdefault = false }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category() 
                {   Id = 1 ,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1 ,
                    Status = Enum.Status.Active
                },

                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Enum.Status.Active,
                 }
                );

            modelBuilder.Entity<CategoryTranslation>().HasData(
                    new CategoryTranslation() {Id = 1, CategoryId = 1, Name = "Áo Khoác Nam", LanguageId = "vi-VN", SeoAlias = "ao-khoac-nam", SeoDescription = "Áo khoác thời trang nam", SeoTitle = "Áo khoác thời trang nam" },
                    new CategoryTranslation() {Id = 2, CategoryId = 1, Name = "Men's Jacket", LanguageId = "en-US", SeoAlias = "Men's-Jacket", SeoDescription = "Men's Fashion jacket products", SeoTitle = "Men's Fashion jacket" },
                    new CategoryTranslation() { Id = 3, CategoryId = 1, Name = "남성 재킷", LanguageId = "Korea", SeoAlias = "Men's-Jacket", SeoDescription = "남성 재킷", SeoTitle = "남성 재킷" },

                    new CategoryTranslation() {Id = 4, CategoryId = 2, Name = "Áo Khoác Nữ", LanguageId = "vi-VN", SeoAlias = "ao-khoac-nu", SeoDescription = "Áo khoác thời trang nữ", SeoTitle = "Áo khoác thời trang nữ" },
                    new CategoryTranslation() {Id = 5, CategoryId = 2, Name = "Women's Jacket", LanguageId = "en-US", SeoAlias = "women's-Jacket", SeoDescription = "women's Fashion jacket products", SeoTitle = "women's Fashion jacket" }

                    );




            modelBuilder.Entity<Product>().HasData(
                new Product() 
                {
                    Id = 1, 
                    DateCreate = DateTime.Now , 
                    OriginalPrice = 10000 , 
                    Prince = 20000, 
                    Viewcount = 0 ,
                }
                );

            modelBuilder.Entity<ProductTranslation>().HasData(
 
                    new ProductTranslation(){Id = 1, ProductId = 1, Name = "Áo Khoác Nam Nhập khẩu từ hàn Quốc", LanguageId ="vi-VN", SeoAlias="ao-khoac-nam-nhap-khau-tu-han-quoc",SeoDescription="Áo khoác thời trang nam nhập khẩu",SeoTitle="Áo khoác thời trang nam", Details = "Mô tả sản phẩm", Description = ""},
                    new ProductTranslation(){Id = 2, ProductId = 1, Name = "Men's Jacket", LanguageId = "en-US",SeoAlias="Men's-Jacket",SeoDescription="Men's Fashion jacket products",SeoTitle="Men's Fashion jacket", Details = "Description of product",Description = ""},
                    new ProductTranslation() { Id = 3, ProductId = 1, Name = "남성 재킷", LanguageId = "Korea", SeoAlias = "남성 재킷", SeoDescription = "남성 재킷", SeoTitle = "남성 재킷", Details = "남성 재킷", Description = "" }

                );

            modelBuilder.Entity<ProductInCategory>().HasData( 
              new ProductInCategory()
              {
                  ProductId = 1,
                  CategoryId = 1
              }
                
            );

            // any guid
            var RoleID = new Guid("42323D12-3FE8-4118-B801-2D2B201BE1E1");
            var UserID = new Guid("7B60066F-0858-4879-A924-28C011D80F20");

           
            var employeeId = new Guid("A35D4CE1-076B-4369-A16A-C08C10DE1278");
            var sellerId = new Guid("E425FFA2-C591-445B-8051-8605FEE3D90F");
            var customerId = new Guid("28C32CE9-578A-4525-B45D-D115DB752A04");



            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = RoleID,
                Name = "admin",
                NormalizedName = "admin",
                Description= "Adminitration role"
            },
             
             new AppRole
             {
                    Id = employeeId,
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                 Description = "Employee role"
             },
             new AppRole
             {
                    Id = sellerId,
                    Name = "Seller",
                    NormalizedName = "SELLER",
                 Description = "Seller role"
             },
             new AppRole
             {
                    Id = customerId,
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",
                 Description = "Customer role"
             }
            );
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = UserID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "nguyencaotan2607@gmail.com",
                NormalizedEmail = "nguyencaotan2607@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123123$abc"),
                SecurityStamp = string.Empty,
                FirstName = "Cao",
                LastName = "Tan",
                Dob = new DateTime(2022,11,23)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = RoleID,
                UserId = UserID
            });

        }
    }
}
