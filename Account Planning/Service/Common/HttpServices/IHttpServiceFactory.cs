namespace Com.ACSCorp.AccountPlanning.Service.Common.HttpServices
{
    public interface IHttpServiceFactory
    {
        public IHttpService CreateHttpService();

        public IHttpService CreateHttpService(string name);
    }
}