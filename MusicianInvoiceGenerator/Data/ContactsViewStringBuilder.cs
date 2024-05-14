using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianInvoiceGenerator.Data
{
    public class ContactsViewStringBuilder
    {
        private int page;
        private int pageSize;
        private bool needAnd;
        private string? nameMatch;
        private string and = "AND ";

        public ContactsViewStringBuilder(int page, int pageSize, string? nameMatch)
        {
            this.page = page;
            this.pageSize = pageSize;
            this.needAnd = true;
            this.nameMatch = nameMatch;
        }

        public string BuildQueryParametersString()
        {
            string queryStringParameters = " ORDER BY Id " +
                $"OFFSET {(page - 1) * pageSize} ROWS " +
                $"FETCH NEXT {pageSize} ROWS ONLY;";
            return queryStringParameters;
        }
    }
}
