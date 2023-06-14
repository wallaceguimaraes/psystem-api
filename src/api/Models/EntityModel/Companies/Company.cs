namespace api.Models.EntityModel.Companies
{
    public class Company
    {
        public long Id { get; set; }
        public string? TradeName { get; set; }
        public string? FullName { get; set; }
        public string? TaxDocument { get; set; }
        public string? CnaeCode { get; set; }
        public string? BusinessTypeName { get; set; }
        public string? BusinessTypeAcronym { get; set; }
        public DateTime SystemImplementation { get; set; } = DateTime.Now;
    }
}