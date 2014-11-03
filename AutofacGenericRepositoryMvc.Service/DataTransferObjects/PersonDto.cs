namespace AutofacGenericRepositoryMvc.Service.DataTransferObjects
{
    public class PersonDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public int CountryId { get; set; }
        public string Languages { get; set; }
    }
}