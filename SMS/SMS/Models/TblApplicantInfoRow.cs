namespace SMS.Models
{
    public class TblApplicantAcademicInfo
    {
        public long IntId { get; set; }
        public long IntApplicantHeaderId { get; set; }
        public string StrInstitutionName { get; set; }
        public long PassingYear { get; set; }
        public decimal NumResult { get; set; }
        public long Scale { get; set; }
        public bool IsActive { get; set; }
    }
}
