namespace Com.ACSCorp.AccountPlanning.Service.Common.Models
{
    public class ListParameter
    {
        public Filter[] Filter { get; set; }
        public SortField SortField { get; set; }
        public Pagination Pagination { get; set; }
    }
}