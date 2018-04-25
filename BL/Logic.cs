using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Data;

namespace BL
{
    public class Logic
    {

        private static CurrencyLayerApi currencyLayerApi = new CurrencyLayerApi("http://www.apilayer.net/api/", "2f6147201b74fa03b7f531996e4a4215");

        public Logic()
        {

        }

        public static Currency Convert(string source, string target)//ILS -> EUR
        {
            List<Currency> currencies = GetLive(source+","+target);
            Currency s = currencies.ElementAt(0);
            Currency t;
            if (s.Value != -0.1)
                t = currencies.ElementAt(1);
            else
                t = new Currency()
                {
                    Source = "No Internet ",
                    Target = "Access!!",
                    Value = -0.1,
                    Timestamp = -111111
                };

            string sour = s.Target;
            string targ = t.Target;
            double value = t.Value / s.Value;
            long timestamp = s.Timestamp;

            Currency curr = new Currency
            {
                Source = sour,
                Target = targ,
                Value = value,
                Timestamp = timestamp
            };

            //SaveToDB(new List<Currency> { curr });

            return curr;
        }

        public static List<Currency> GetHistory(string source, string target)
        {
            List<Currency> currencyHistory;

            using (DB_Manager db_manager = new DB_Manager())
            {
                currencyHistory = (from c in db_manager.Currencies
                                   where (c.Source == source && c.Target == target)
                                   orderby c.Timestamp
                                   select c).ToList();

            }

            return currencyHistory;
        }

        public static List<Currency> GetLive(string currencies)
        {
  
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"currencies", currencies }
            };
            List<Currency> currenciesList = new List<Currency>();
            try
            {
                // this works with async methods
                Task<LiveModel> taskLiveModel = Task.Run<LiveModel>(() => currencyLayerApi.Invoke<LiveModel>("live", dictionary));

                LiveModel liveModel = taskLiveModel.Result;


                int timestamp = liveModel.Timestamp;

                Dictionary<string, string> quotes = liveModel.quotes;
                           
                foreach (var quote in quotes)
                {
                    string name = quote.Key; // USDEUR
                    string source = name.Substring(0, 3); // USD
                    string target = name.Substring(3, 3); // EUR
                    double value = Double.Parse(quote.Value);

                    Currency currency = new Currency
                    {
                        Source = source,
                        Target = target,
                        Value = value,
                        Timestamp = timestamp
                    };

                    currenciesList.Add(currency);
                }
                
            }
            catch
            {
               
                Currency currency = new Currency
                {
                    Source = "No Internet ",
                    Target = "Access!!",
                    Value = -0.1,
                    Timestamp = -111111
                };
                currenciesList.Add(currency);
            }

            //SaveToDB(currenciesList);

            return currenciesList;
        }

        public static List<Quote> GetQuotes()
        {
            
            // this works with async methods
            Task<CurrencyListModel> taskListModel = Task.Run<CurrencyListModel>(() => currencyLayerApi.Invoke<CurrencyListModel>("list"));
          
            CurrencyListModel listModel = taskListModel.Result;

            Dictionary<string, string> quotes = listModel.quotes;

            List<Quote> quotesList = new List<Quote>();

            foreach (var quot in quotes)
            {
                string quo = quot.Key; // USD
                string country =quot.Value;

                Quote quote = new Quote
                {
                    quote = quo,
                    Country = country,
                   
                };

                quotesList.Add(quote);
            }

            return quotesList;
        }


        public static List<CurrencyHistory> GetCurrencyHistoryFromStartDate(string sourceQuote, string targetQuote, string code)
        {
            List<CurrencyHistory> currenciesHistory = new List<CurrencyHistory>();
            DateTime today = DateTime.Now;
            DateTime start = today;
            if (code == "others")
                start = start.AddDays(-5);
            else
                start = start.AddMonths(-12);
            try
            {
                while (start <= today)
                {
                    //int year = start.Year;
                    string year = start.Year.ToString();
                    string month = start.Month.ToString();
                    string day = start.Day.ToString();
                    if (month.Length == 1) month = "0" + month;
                    if (day.Length == 1) day = "0" + day;
                    string date = year + "-" + month + "-" + day;
                    Dictionary<string, string> dictDate = new Dictionary<string, string> { { "date", date } };
                    Dictionary<string, string> dictCurrency = new Dictionary<string, string> { { "currencies", targetQuote } };
                    Task<HistoryModel> taskHistoryModel = Task.Run<HistoryModel>(() => currencyLayerApi.Invoke<HistoryModel>("historical", dictDate, dictCurrency));
                    HistoryModel historyModel = taskHistoryModel.Result;

                    int timestamp = historyModel.Timestamp;
                    string dateString = historyModel.Date;
                    int dateYear = int.Parse(dateString.Substring(0, 4));
                    int dateMonth = int.Parse(dateString.Substring(5, 2));
                    int dateDay = int.Parse(dateString.Substring(8, 2));
                    DateTime dt = new DateTime(dateYear, dateMonth, dateDay);
                    var quotes = historyModel.quotes;
                    foreach (var quote in quotes)
                    {
                        string name = quote.Key; // USDEUR
                        string source = name.Substring(0, 3); // USD
                        string target = name.Substring(3, 3); // EUR
                        double value = Double.Parse(quote.Value);

                        CurrencyHistory currencyHistory = new CurrencyHistory
                        {
                            Source = source,
                            Target = target,
                            Value = value,
                            Timestamp = timestamp,
                            Date = dt
                        };

                        currenciesHistory.Add(currencyHistory);
                    }
                    if (code == "others")
                        start = start.AddDays(1);
                    else
                        start = start.AddMonths(1);
                }
            }
            catch
            {
                CurrencyHistory currencyHistory = new CurrencyHistory
                {
                    Source = "No Internet",
                    Target = " Access!!",
                    Value = -0.1,
                    Timestamp = -111111,
                    Date = new DateTime()
                };

                currenciesHistory.Add(currencyHistory);
            }

            return currenciesHistory;
        }


        private void SaveToDB(List<Currency> currenciesList)
        {
            

                /*           using (DB_Manager db_manager = new DB_Manager())
                           {
                               foreach (Currency c in currenciesList)
                               {
                                   try
                                   {
                                       db_manager.Currencies.Add(c);
                                       db_manager.SaveChanges();
                                   }
                                   catch (Exception)
                                   {
                                       // the currency already is in the table
                                   }
                               }

                           }
               */
            }

        }
}
