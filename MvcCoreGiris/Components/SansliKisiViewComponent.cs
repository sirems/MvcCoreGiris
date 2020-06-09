using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCoreGiris.Models;

namespace MvcCoreGiris.Components
{
    //View Component; https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-3.1

    public enum TextColor { danger,info,warning, success,primary,secondary, light,dark }
    public class SansliKisiViewComponent : ViewComponent
    {
        private readonly OkulContext _okulContext;

        public SansliKisiViewComponent(OkulContext okulContext)
        {
            _okulContext = okulContext; 
        }
        public async Task<IViewComponentResult> InvokeAsync(TextColor renk)
        {
            var adet =  await _okulContext.Kisiler.CountAsync();
            var index= new Random().Next(adet);
            var kisi = await _okulContext.Kisiler.Skip(index).FirstOrDefaultAsync();

            ViewBag.renk = Enum.GetName(renk.GetType(), renk);

            return View(kisi);
        }
    }
}   
