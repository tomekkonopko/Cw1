using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //console.writeline("hello world!");
            //int? tmp1 = 1; //jezeli dodamy na koniec  ? to zmienna moze przyjac wartosc null
            //double tmp2 = 2.0;
            //string tmp3 = "aaa";
            //string tmp6 = "bbb";
            //bool tmp4 = true;
            //ctrl+k, ctrl+u

            //var tmp5 = 1.0; //var zmienna przyjmuje typ od wartosci ktora dostala nie mozna zrobic var tmp5=null

            //var path = @"https://github.com/tomekkonopko/cw1";
            //console.writeline($"{tmp3} {tmp6} {tmp1}"); //to co w klamrach nie trzeba pisac plusow same spacje sie dodadza, sprawdzic potem samemu

            //var newperson = new person {firstname = "daniel"}; //ctrl + spacja od razu wartosc mozna przypisac

            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";

            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(url))
                {
                    //aby program poczekal trzeba dodac await do metody ktora jest asynchroniczna

                    //2xx jest w porzadku cos tam gada o 404 jakies bledy najgorsze to jest 500+ 500 to blad serwera 502 zla brama cos tam cos tam
                    if (response.IsSuccessStatusCode)
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();

                        var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);
                        var matches = regex.Matches(htmlContent);

                        foreach (var match in matches)
                        {
                            Console.WriteLine(match.ToString());
                        }
                    }
                }                 
            }
                       

            

        }
    }
}
