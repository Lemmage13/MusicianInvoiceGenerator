using MusicianInvoiceGenerator.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MusicianInvoiceGenerator.ViewModels.Functionality
{
    public class ControlToFixedDoc
    {
        //Small class to handle the conversion of the preview user control to an XPS document format, which the wpf Docviewer allows to print to PDF

        double pageWidth = 96 * 8.5;
        double pageHeight = 96 * 11;
        double margin = 32;

        public FixedDocument ControlToXPS(UserControl control)
        {
            SizeControl(control, pageWidth);
            FixedDocument fixedDoc = new FixedDocument();
            PageContent pgContent = CreateInvoiceDocPagecontent(control);

            fixedDoc.Pages.Add(pgContent);

            return fixedDoc; 
        }
        private PageContent CreateInvoiceDocPagecontent(UserControl control)
        {
            PageContent pgContent = new PageContent();
            FixedPage fixedPg = new FixedPage();

            FixedPage.SetTop(control, margin);
            FixedPage.SetLeft(control, margin);

            fixedPg.Height = pageHeight;
            fixedPg.Width = pageWidth;

            fixedPg.Children.Add(control);

            Size sz = new Size(pageWidth, pageHeight);
            fixedPg.Measure(sz);
            fixedPg.Arrange(new Rect(new Point(), sz));
            fixedPg.UpdateLayout();

            pgContent.Child = fixedPg;

            return pgContent;
        }
        private void SizeControl(UserControl control, double width)
        {
            //height does not need to be set as it should fit
            control.Width = width - 2 * margin;
        }
    }
}
