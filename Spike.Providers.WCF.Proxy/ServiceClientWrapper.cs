/* This Generic Service Client Wrapper Class will ensure proper closing of connections  *
 * and more flexible error handling.                                                    *
 * ------------------------------------------------------------------------------------ *
 * 
 *  var consumer = new ServiceClientWrapper<AuthorServiceClient, IAuthorService>();
 *  if (consumer.IsServiceAvailabe())
 *  {
 *      author = consumer.Excecute(service => service.AddAuthor(request));
 *  }
 */

namespace Spike.Providers.WCF.Proxy
{
    using System;
    using System.ServiceModel;
    
    public class ServiceClientWrapper<TClient, TIService> : IDisposable
        where TClient : ClientBase<TIService>, TIService
        where TIService : class
    {

        private TClient serviceClient;

        public void Excecute(
            Action<TIService> serviceCall,
            int retryAttempts = 1,
            Action<CommunicationException> exceptionHandler = null)
        {
            Excecute<object>(
                service => { serviceCall.Invoke(service); return null; },
                    retryAttempts,
                    exceptionHandler);
        }


        public TResult Excecute<TResult>(
            Func<TIService, TResult> serviceCall,
            int retryAttempts = 1,
            Action<CommunicationException> exceptionHandler = null)
        {
            var errors = 0;
            CommunicationException exception = null;

            while (errors < retryAttempts)
            {
                this.DisposeClient();

                try
                {
                    this.serviceClient = this.CreateClient();

                    return serviceCall.Invoke(this.serviceClient);
                }
                catch (CommunicationException comsException)
                {
                    exception = comsException;

                    if (exceptionHandler != null)
                    {
                        try
                        {
                            exceptionHandler.Invoke(exception);
                        }
                        catch (CommunicationException reThrowException)
                        {
                            exception = reThrowException;
                        }
                    }

                    errors++;
                }
                finally
                {
                    this.DisposeClient();
                }
            }

            throw exception ?? new CommunicationException(@"Excecution unsuccessfull with no exceptions. Invalid state reached inside 'Service Client Wrapper' for opperation.");
        }

        public bool IsServiceAvailabe()
        {
            try
            {
                this.serviceClient = this.serviceClient ?? this.CreateClient();
                this.serviceClient.Open();
            }
            catch
            {
                return false;
            }
            finally
            {
                this.DisposeClient();
            }

            return true;
        }

        public void Dispose()
        {
            this.DisposeClient();
        }

        protected virtual TClient CreateClient()
        {
            return (TClient)Activator.CreateInstance(typeof(TClient));
        }

        private void DisposeClient()
        {
            if (this.serviceClient == null)
            {
                return;
            }

            try
            {
                if (this.serviceClient.State == CommunicationState.Faulted)
                {
                    this.serviceClient.Abort();
                }
                else
                {
                    this.serviceClient.Close();
                }
            }
            catch
            {
                this.serviceClient.Abort();
            }

            this.serviceClient = null;
        }
    }
}
