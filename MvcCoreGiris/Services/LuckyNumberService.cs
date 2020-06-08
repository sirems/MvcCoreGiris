using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreGiris.Services
{
    public class LuckyNumberService
    {
        //bu servis bize bir adet rastgele seçilmiş rakam sağlar
        private readonly static Random rnd = new Random();
        public int LuckyNumber { get; private set; }

        public LuckyNumberService()
        {
            LuckyNumber = rnd.Next(10);
        }
    }
}
