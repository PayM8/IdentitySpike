
namespace Spike.Providers.WCF.Proxy.Builders
{
    using System;
    using Contracts.Books;

    public class BookBuilder : Book
    {
        public BookBuilder(int? id = null)
        {
            if (id.HasValue)
            {
                this.Id = id.Value;
            }
        }

        public BookBuilder BullsEye()
        {
            this.Id = 1;
            this.Author = "Brian Tracy";
            this.Title = "Bull's Eye";
            this.Year = new DateTime(1993,03,22);

            return this;
        }

        public BookBuilder FiveDysfunctions()
        {
            this.Id = 2;
            this.Author = "Patrick Lencioni";
            this.Title = "Five Dysfunctions of a Team";
            this.Year = new DateTime(2002, 01, 12);

            return this;
        }

        public BookBuilder PhoenixProject()
        {
            this.Id = 3;
            this.Author = "Gene Kim & Kevin Bechr";
            this.Title = "Phoenix Project";
            this.Year = new DateTime(2005, 07, 23);

            return this;
        }

        public Book Build()
        {
            return new Book
            {
                Id = this.Id,
                Year = this.Year,
                Author = this.Author,
                Title = this.Title
            };
        }
    }
}
