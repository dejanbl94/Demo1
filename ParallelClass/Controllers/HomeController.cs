using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParallelClass.Models;

namespace ParallelClass.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 100; i++) //this type of increment is better suited for sequential execution
            {
                //var s = string.Empty;
                var s = Encrypt();
            }
            timer.Stop();
            ViewData["timer1"] = timer.Elapsed;
            timer.Reset();

            var timer2 = new Stopwatch();
            timer2.Start();
            Parallel.For(0, 100, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
             {
                 //var s = string.Empty;
                 var s = Encrypt(); //When we actually do some work the parallelization wins the battle...
             });
            timer2.Stop();
            ViewData["timer2"] = timer2.Elapsed;
            timer2.Reset();

            return View();
        }

        public static string Encrypt(string inputString = "This is an encripted string and you will never see it...")
        {
            var rtnValue = "";
            using (Rijndael crypt = Rijndael.Create())
            {
                crypt.GenerateKey();
                crypt.GenerateIV();

                ICryptoTransform transformer = crypt.CreateEncryptor();
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, transformer, CryptoStreamMode.Write))
                    {
                        using (var wr = new StreamWriter(cs))
                        {
                            wr.Write(inputString);
                        }
                        rtnValue = System.Text.Encoding.UTF8.GetString(ms.ToArray());

                    }
                }
            }
            return rtnValue;
        }

    }
}
