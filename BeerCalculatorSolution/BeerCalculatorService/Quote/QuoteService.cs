using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerCalculatorService.Quote
{
    public class QuoteService : IQuoteService
    {
        List<string> quotes;

        public string GetQuote()
        {
            int id = GetRandomNumber();

            string returnQuote = GetQuote(id);

            return returnQuote;
        }

        public QuoteService()
        {

            quotes.Add("The goal of education is the advancement of knowledge and the dissemination of truth.");
            quotes.Add("Education is the most powerful weapon which you can use to change the world.");
            quotes.Add("Education's purpose is to replace an empty mind with an open one.");
            quotes.Add("Education is the passport to the future, for tomorrow belongs to those who prepare for it today");
            quotes.Add("The aim of education is the knowledge, not of the facts, but of the values.");
            quotes.Add("An investment in knowledge pays the best interest.");
            quotes.Add("Education is what remains after on has forgotten what one has learned in school.");
            quotes.Add("I have no special talent. I am only passionately curious.");
            quotes.Add("Education is not prepartion for life; education is life itself.");
            quotes.Add("Knowledge is power. Information is liberating. Education is the premise of progress, in every society, in every family.");

        }

        private string GetQuote(int id)
        {
            string value = string.Empty;

            if (id <= 10)
            {
                value = quotes[id];
            }
            else
            {
                value = quotes[5];
            }

            return value;
        }

        private int GetRandomNumber()
        {
            Random random = new Random();

            int number = random.Next(11);

            return number;
        }
    }

    public interface IQuoteService
    {
        string GetQuote();
    }
}