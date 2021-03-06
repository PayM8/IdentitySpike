﻿
namespace RestConsumer
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Spike.Contracts.Books;
    using System.Collections.Generic;
    using System.Linq;

    public class BookClient : ApiClient
    {
        public BookClient()
            : base("http://localhost:4345/v01/")
        { }

        public void GetSingleBook(string relativePath)
        {
            GetSingleAsync(relativePath).Wait();
        }

        public void GetListBook(string relativePath)
        {
            GetListAsync(relativePath).Wait();
        }

        public void PostSingleBook(string relativePath, Book book)
        {
            PostSingleAsync(relativePath, book).Wait();
        }

        private async Task PostSingleAsync(string relativePath, Book book)
        {
            var newBook = PostApi(relativePath, book);

            if (newBook == null)
            {
                Console.WriteLine("BullsEye Book was not found");
            }
            else
            {
                Console.WriteLine("Retrieved [{0}] book", newBook.Display());
            }

            Thread.Sleep(2000);
        }

        private async Task GetSingleAsync(string relativePath)
        {
            var book = GetApi<Book>(relativePath);

            if (book == null)
            {
                Console.WriteLine("BullsEye Book was not found");
            }
            else
            {
                Console.WriteLine("Retrieved [{0}] book", book.Display());
            }

            Thread.Sleep(2000);
        }

        private async Task GetListAsync(string relativePath)
        {
            var books = GetApi<List<Book>>(relativePath);
            if (!books.Any())
            {
                Console.WriteLine("No books where found");
            }
            else
            {
                foreach (var book in books)
                {
                    Console.WriteLine("Retrieved [{0}] book", book.Display());
                }
            }

            Thread.Sleep(2000);
        }
    }

    public abstract class ApiClient
    {
        protected readonly string BaseAddress;

        protected ApiClient(string baseAddress)
        {
            this.BaseAddress = baseAddress;
        }

        protected T GetApi<T>(string relativePath)
        {
            using (var client = this.CreateJsonHttpClient())
            {
                var response = client.GetAsync(relativePath).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<T>().Result;
                }
                else
                {
                    Console.WriteLine(response.ReasonPhrase);
                }

                Console.WriteLine("No Book Found.");
                return default(T);
            }
        }

        protected T PostApi<T>(string relativePath, T data)
        {
            using (var client = this.CreateJsonHttpClient())
            {
                var response = client.PostAsJsonAsync(relativePath, data).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<T>().Result;
                }

                Console.WriteLine("No Book Found.");
                return default(T);
            }
        }

        private HttpClient CreateJsonHttpClient()
        {
            var client = new HttpClient { BaseAddress = new Uri(BaseAddress) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
        "Basic",
        Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
                string.Format("{0}:{1}", "user", "banana"))));
            return client;
        }
    }
}