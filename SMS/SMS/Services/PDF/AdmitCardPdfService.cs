using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SMS.Helper;
using SMS.Services.PDF.Interface;
using SMS.ViewModel.AdmitCardPrint;

namespace SMS.Services.PDF
{
    public class AdmitCardPdfService: IAdmitCardPdfService
    {
        private readonly IWebHostEnvironment _henv;
        private IConverter _converter;

        public AdmitCardPdfService(IWebHostEnvironment henv, IConverter converter)
        {
               _henv = henv;
              _converter = converter;

        }
        public async Task<byte[]> GetApplicantAdmitCardPDF(GetApplicantHeaderPrintViewModel viewModel)
        {
            try
            {
                var globalSettings = new GlobalSettings()
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    DocumentTitle = "Applicant Admit Card"
                };

                var objectsettings = new ObjectSettings()
                {
                    PagesCount = true,
                    HtmlContent = PdfBody.GetAdmitCardPdftemplate(viewModel, _henv),
                };

                // jodi HtmlToPdfDocument return kori tahole ar byte a convert korte hobe na. Then Controller theke byte a convert kore return korte hobe
                HtmlToPdfDocument pdfdocument = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectsettings }
                };

                //byte a convert korbe.
                return _converter.Convert(pdfdocument);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
           
        }
    }
}
