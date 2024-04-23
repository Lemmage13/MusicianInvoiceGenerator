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
        private bool? paid;
        private bool needAnd;
        private string and = "AND ";
        public InvoiceViewStringBuilder(int page, int pageSize, DateTime startDate, DateTime endDate, bool? paid)
        {
            this.page = page;
            this.pageSize = pageSize;
            this.startDate = DateTimeToDateString(startDate);
            this.endDate = DateTimeToDateString(endDate);
            this.paid = paid;

            needAnd = true;
        }
        public InvoiceViewStringBuilder(int page, int pageSize, DateTime startDate)
        {
            this.page = page;
            this.pageSize = pageSize;
            this.startDate = DateTimeToDateString(startDate);
            this.endDate = DateTimeToDateString(startDate.AddYears(1));

            needAnd = true;
        }
        private string DateTimeToDateString(DateTime d) // POSSIBLY UNNECCESSARY
        {
            return d.ToString("yyyy") + "-" + d.ToString("MM") + "-" + d.ToString("dd");
        }
        public string BuildQueryParametersString()
        {
            string queryStringParameters = $" WHERE InvoiceDate BETWEEN '{startDate}' AND '{endDate}' ";
            if (paid != null)
            {
                if (needAnd) { queryStringParameters += and; needAnd = false; }
                queryStringParameters += IsInvoicePaid((bool)paid);
            }
            queryStringParameters += "ORDER BY Id " +
                $"OFFSET {(page - 1) * pageSize} ROWS " +
                $"FETCH NEXT {pageSize} ROWS ONLY;";
            return queryStringParameters;
        }
        private string IsInvoicePaid(bool p)
        {
            string paidParameters = $"Paid = '{Convert.ToInt16(p)}' ";
            return paidParameters;
        }
    }
}
