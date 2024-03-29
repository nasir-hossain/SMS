using DinkToPdf;
using SMS.ViewModel.AdmitCardPrint;

namespace SMS.Services.PDF.Interface
{
    public interface IAdmitCardPdfService
    {
        public Task<byte[]> GetApplicantAdmitCardPDF(GetApplicantHeaderPrintViewModel viewModel);

    }
}
