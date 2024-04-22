using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.Data
{
    public class InvoiceViewStringBuilder
    {
        private int page;
        private int pageSize;
        private string startDate;
        private string endDate;
        public InvoiceViewStringBuilder(int page, int pageSize, DateTime startDate, DateTime endDate)
        {
            this.page = page;
            this.pageSize = pageSize;
            this.startDate = DateTimeToDateString(startDate);
            this.endDate = DateTimeToDateString(endDate);
        }
        public InvoiceViewStringBuilder(int page, int pageSize, DateTime startDate)
        {
            this.page = page;
            this.pageSize = pageSize;
            this.startDate = DateTimeToDateString(startDate);
            this.endDate = DateTimeToDateString(startDate.AddYears(1));
        }
        private string DateTimeToDateString(DateTime d) // POSSIBLY UNNECCESSARY
        {
            return d.ToString("yyyy") + "-" + d.ToString("MM") + "-" + d.ToString("dd");
        }
        public string BuildQueryParametersString()
        {
            string queryStringParameters = $" WHERE InvoiceDate BETWEEN '{startDate}' AND '{endDate}' ";
            queryStringParameters += "ORDER BY Id " +
                $"OFFSET {(page - 1)*pageSize} ROWS " +
                $"FETCH NEXT {pageSize} ROWS ONLY;";

            return queryStringParameters;
        }
    }
}
