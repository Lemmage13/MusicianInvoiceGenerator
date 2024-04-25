namespace MusicianInvoiceGenerator.Models
{
    public class ContactDetails
    {
        //ContactDetails is an object representing contact details for either the sender or recipient of an invoice

        public int? Id;
        public string Name;
        public string PhoneNumber;
        //Email?

        public string Line1;
        public string Line2;
        public string Town;
        public string Postcode;

        public ContactDetails(string name, string phoneNumber, string line1, string line2, string town, string postcode)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Line1 = line1;
            Line2 = line2;
            Town = town;
            Postcode = postcode;
        }
        public ContactDetails(int id, string name, string phoneNumber, string line1, string line2, string town, string postcode)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Line1 = line1;
            Line2 = line2;
            Town = town;
            Postcode = postcode;
        }
    }
}
