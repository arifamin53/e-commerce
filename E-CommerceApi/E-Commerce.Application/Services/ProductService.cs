using AutoMapper;
using E_commerce.Domain.Entities;
using E_Commerce.Application.Abstraction.IRepository;
using E_Commerce.Application.Abstraction.IService;
using E_Commerce.Application.Abstraction.IStorageService;
using E_Commerce.Application.Abstraction.IUnitOfWord;
using E_Commerce.Application.RRModels.Product;
using E_Commerce.Application.Utility;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using static E_commerce.Domain.Enums.AppEnums;

namespace E_Commerce.Application.Services
{
    public class ProductService(IUnitOfWork unitOfWork,IMapper mapper,
        IProductRepository productRepository,IStorageService storageService,
        IAppFileRepository appFileRepository) : IProductService
    {
        public async Task<Result<ProductResponse>> Add(ProductRequest model)
        {
            var transection = unitOfWork.BeignTranction();
            var response = mapper.Map<Product>(model);
            await productRepository.AddAsync(response);
            var mappedResponse = mapper.Map<ProductResponse>(response);
            if(model.Files is not null && model.Files.Count() > 0)
            {
                var fileResponse = await storageService.SaveFilesAsync(model.Files);

                List<string> FilePathes = fileResponse.FilePath;
                List<string> FileNames = fileResponse.FileName;

                List<AppFile> appFiles=new List<AppFile>();

                foreach(var (filePath,fileName) in FilePathes.Zip(FileNames, (path, name) => (path, name)))
                {
                    var appfile = new AppFile()
                   {
                      FileName=fileName,
                      FilePath=filePath,
                      AppModule=AppModule.Product,
                      EntityId=response.Id
                    };
                  appFiles.Add(appfile);
                  mappedResponse.Files = appfile.FilePath;
                }
                await appFileRepository.AddRangeAsync(appFiles);
              
            }

            var returnValue = await unitOfWork.SaveChanegeAsync();
            if(returnValue > 0)
            {
                transection.Commit();
                return Result<ProductResponse>.Success(mappedResponse, "Product Added successfully");
            }
            return Result<ProductResponse>.Failure("Something went wrong please try after some time", StatusCodes.Status500InternalServerError);

        }

        public async Task<Result<ProductResponse>> DeleteProduct(Guid id)
        {
            var transection = unitOfWork.BeignTranction();
            var product=await productRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (product is null) return Result<ProductResponse>.Failure("Data Not Found", StatusCodes.Status404NotFound);

            await productRepository.DeleteByIdAsync(product.Id);
            var files=await appFileRepository.GetFileByEntityId(product.Id);
            await appFileRepository.DeleteAppFilesBYEntityId(product.Id);
            int returnValue=await unitOfWork.SaveChanegeAsync();    
            if(returnValue > 0)
            {
                transection.Commit();
                var res=mapper.Map<ProductResponse>(product);

                foreach(var file in files)
                {
                    storageService.DeleteFile(file.FileName);
                }
                return Result<ProductResponse>.Success(res, "product deleted successfully");
            }

            return Result<ProductResponse>.Failure("something went wrong please try after someTime", StatusCodes.Status500InternalServerError);
        }

        public async Task<Result<ProductResponse>> ProductById(Guid id)
        {
            var product = await productRepository.ProductsById(id);
            if (product is null) return Result<ProductResponse>.Failure("not Found", StatusCodes.Status404NotFound);
            return Result<ProductResponse>.Success(product, "Data Fetched Successfully");
        }

        public async Task<Result<IEnumerable<ProductResponse>>> ProductsByCategoryId(Guid id)
        {
            var products = await productRepository.ProductsByCategoryId(id);
            if (products .Count() == 0) return Result<IEnumerable<ProductResponse>>.Success("No Data Found",StatusCodes.Status204NoContent);
            return Result<IEnumerable<ProductResponse>>.Success(products, "Data Fetched Successfully");

        }

        public async Task<Result<ProductResponse>> UpdateProduct(ProductUpdateRequest model)
        {
            var transection = unitOfWork.BeignTranction();
            var product = await productRepository.FirstOrDefaultAsync(x => x.Id == model.Id);
            if(product is not null)
            {
                var response = mapper.Map<Product>(model);
                response.UpdatedAt = true;
                await productRepository.UpdateASync(response);
                int returnvalue = await unitOfWork.SaveChanegeAsync();
                if(returnvalue > 0)
                {
                    transection.Commit();
                    var res = mapper.Map<ProductResponse>(response);
                    return Result<ProductResponse>.Success(res, "Producted Updated Successfully");
                }
                return Result<ProductResponse>.Failure("something went wrong please try after some time",StatusCodes.Status500InternalServerError);
            }
            return Result<ProductResponse>.Failure("Not Found", StatusCodes.Status404NotFound);

        }
    }
}
