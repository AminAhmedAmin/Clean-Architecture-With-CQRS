using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.Contracts.Application.API.Shared;
using VuexyBase.Application.Application.ViewModels.Helper;
using VuexyBase.Domain.Constants;

namespace VuexyBase.Application.Application.Services.API.Shared
{
    public class SharedService : ISharedService
    {

        //public async Task<string> UploadFileUsingApi(uploadImageDto model)
        //{

        //    var apiUrl = $"{AppRoutes.DashboardUrl}{ApiRoutes.GeneralApi.UploadImage}";

        //    try
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            var formData = new MultipartFormDataContent();

        //            // Use the stream without explicitly disposing it
        //            var fileContent = new StreamContent(model.Image.OpenReadStream());
        //            fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
        //            formData.Add(fileContent, "image", model.Image.FileName);

        //            formData.Add(new StringContent(model.FileName.ToString()), "fileName");

        //            var response = await httpClient.PostAsync($"{apiUrl}", formData);

        //            string jsonString = await response.Content.ReadAsStringAsync();

        //            var responseObject = JsonConvert.DeserializeAnonymousType(jsonString, new { result = "" });
        //            return responseObject.result;

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
