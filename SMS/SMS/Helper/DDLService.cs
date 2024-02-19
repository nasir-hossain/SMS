using SMS.ViewModel;

namespace SMS.Helper
{
    public static class DDLService
    {
        public static List<NationalityViewModel> GetNationality()
        {
            List<NationalityViewModel> Data = new List<NationalityViewModel>()
            {
                new NationalityViewModel() {Id = 1, Name ="Bangladeshi"},
                new NationalityViewModel() {Id = 2, Name ="Indian"},
                new NationalityViewModel() {Id = 3, Name ="Pakistani"},
                new NationalityViewModel() {Id = 4, Name ="Nepali"},
            };

            return Data;
        }

        public static List<ReligionViewModel> GetReligion()
        {
            List<ReligionViewModel> Data = new List<ReligionViewModel>()
            {
                new ReligionViewModel() {Id= 1, Name="Muslim"},
                new ReligionViewModel() {Id= 2, Name="Hindu"},
                new ReligionViewModel() {Id= 3, Name="Christian"},
            };

            return Data;
        }

        public static List<SchoolViewModel> GetSchool()
        {
            List<SchoolViewModel> Data = new List<SchoolViewModel>()
            {
                new SchoolViewModel() { Id = 1, Name = "Chota Sundar A.Ali High School" },
                new SchoolViewModel() { Id = 2, Name = "Hasan Ali High School" },
                new SchoolViewModel() { Id = 3, Name = "Kamranga High School" },
                new SchoolViewModel() { Id = 4, Name = "Others" }
            };

            return Data;
        }

        public static List<CollegeViewModel> GetCollege()
        {
            List<CollegeViewModel> Data = new List<CollegeViewModel>()
            {
                new CollegeViewModel() { Id = 1, Name = "Milestone College" },
                new CollegeViewModel() { Id = 2, Name = "Hajigonj Model College" },
                new CollegeViewModel() { Id = 3, Name = "Al Amin Academy College" },
                new CollegeViewModel() { Id = 4, Name = "Others" }
            };

            return Data;
        }

        public static List<EducationBoardViewModel> GetEducationBoard()
        {
            List<EducationBoardViewModel> Data = new List<EducationBoardViewModel>()
            {
                new EducationBoardViewModel() { Id = 1, Name = "Dhaka" },
                new EducationBoardViewModel() { Id = 2, Name = "Cumilla" }
            };

            return Data;
        }

        public static List<YearViewModel> GetYear()
        {
            List<YearViewModel> Data = new List<YearViewModel>()
            {
                new YearViewModel() { Id = 1, Name = "2012" },
                new YearViewModel() { Id = 2, Name = "2013" },
                new YearViewModel() { Id = 3, Name = "2013" },
                new YearViewModel() { Id = 4, Name = "2014" },
                new YearViewModel() { Id = 5, Name = "2015" },
                new YearViewModel() { Id = 6, Name = "2016" },
                new YearViewModel() { Id = 7, Name = "2017" },
                new YearViewModel() { Id = 8, Name = "2018" },
                new YearViewModel() { Id = 9, Name = "2019" },
                new YearViewModel() { Id = 10, Name = "2020" },
                new YearViewModel() { Id = 11, Name = "2021" },
                new YearViewModel() { Id = 12, Name = "2022" },
                new YearViewModel() { Id = 13, Name = "2023" },
            };

            return Data;
        }
    }
}
