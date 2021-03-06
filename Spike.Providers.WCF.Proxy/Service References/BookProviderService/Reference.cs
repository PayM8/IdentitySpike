﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Spike.Providers.WCF.Proxy.BookProviderService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="Spike.Providers", ConfigurationName="BookProviderService.BookProviderService")]
    public interface BookProviderService {
        
        [System.ServiceModel.OperationContractAttribute(Action="Spike.Providers/BookProviderService/AddBook", ReplyAction="Spike.Providers/BookProviderService/AddBookResponse")]
        Spike.Contracts.Books.Book AddBook(Spike.Contracts.Books.Book book);
        
        [System.ServiceModel.OperationContractAttribute(Action="Spike.Providers/BookProviderService/AddBook", ReplyAction="Spike.Providers/BookProviderService/AddBookResponse")]
        System.Threading.Tasks.Task<Spike.Contracts.Books.Book> AddBookAsync(Spike.Contracts.Books.Book book);
        
        [System.ServiceModel.OperationContractAttribute(Action="Spike.Providers/BookProviderService/GetBook", ReplyAction="Spike.Providers/BookProviderService/GetBookResponse")]
        Spike.Contracts.Books.Book GetBook(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="Spike.Providers/BookProviderService/GetBook", ReplyAction="Spike.Providers/BookProviderService/GetBookResponse")]
        System.Threading.Tasks.Task<Spike.Contracts.Books.Book> GetBookAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="Spike.Providers/BookProviderService/GetAllBooks", ReplyAction="Spike.Providers/BookProviderService/GetAllBooksResponse")]
        Spike.Contracts.Books.Book[] GetAllBooks();
        
        [System.ServiceModel.OperationContractAttribute(Action="Spike.Providers/BookProviderService/GetAllBooks", ReplyAction="Spike.Providers/BookProviderService/GetAllBooksResponse")]
        System.Threading.Tasks.Task<Spike.Contracts.Books.Book[]> GetAllBooksAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface BookProviderServiceChannel : Spike.Providers.WCF.Proxy.BookProviderService.BookProviderService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BookProviderServiceClient : System.ServiceModel.ClientBase<Spike.Providers.WCF.Proxy.BookProviderService.BookProviderService>, Spike.Providers.WCF.Proxy.BookProviderService.BookProviderService {
        
        public BookProviderServiceClient() {
        }
        
        public BookProviderServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BookProviderServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookProviderServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookProviderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Spike.Contracts.Books.Book AddBook(Spike.Contracts.Books.Book book) {
            return base.Channel.AddBook(book);
        }
        
        public System.Threading.Tasks.Task<Spike.Contracts.Books.Book> AddBookAsync(Spike.Contracts.Books.Book book) {
            return base.Channel.AddBookAsync(book);
        }
        
        public Spike.Contracts.Books.Book GetBook(int id) {
            return base.Channel.GetBook(id);
        }
        
        public System.Threading.Tasks.Task<Spike.Contracts.Books.Book> GetBookAsync(int id) {
            return base.Channel.GetBookAsync(id);
        }
        
        public Spike.Contracts.Books.Book[] GetAllBooks() {
            return base.Channel.GetAllBooks();
        }
        
        public System.Threading.Tasks.Task<Spike.Contracts.Books.Book[]> GetAllBooksAsync() {
            return base.Channel.GetAllBooksAsync();
        }
    }
}
