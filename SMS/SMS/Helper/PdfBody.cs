using SMS.ViewModel.AdmitCardPrint;
using System.Text;
using System.Xml.Linq;

namespace SMS.Helper
{
    public static class PdfBody
    {
        public static string GetAdmitCardPdftemplate(GetApplicantHeaderPrintViewModel viewModel, IWebHostEnvironment _henv)
        {
            var sb = new StringBuilder();
			var root = _henv.WebRootPath;
            string logoDir = "image";
            string ProfileDir = "UploadFile";
			var logoName = "logo.png";
            string logoPath = Path.Combine(root, logoDir, logoName);
			string profilePath =Path.Combine(root, ProfileDir, viewModel.Attachment ?? "");


            string ExamDate = viewModel.ExamDateTime?.ToString("ddd dd MMM yyyy") ?? "";
            string ExamTime = viewModel.ExamDateTime?.ToString(" hh:mm tt") ?? "";
            string DoB = viewModel.DoB.ToString("dddd dd MMM yyyy");



            sb.Append(@"<!DOCTYPE html>
						<html lang=""en"">
						<head>
						<meta charset=""UTF-8"">
						<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
						<title>Admit Card</title>
						<style>

						*{margin:0 ; padding-top:0;}

						  body {
							font-family: Arial, sans-serif;
						  }
  
						.container {
							position: relative; 
							border:1px dotted black;
						}

						.background-image {
						  position: absolute;
						  top: 45%;
						  left: 35%;
						  width: 330px;
						  height: 350px;
						  opacity: 0.1; 
						}
  
						 .header {
							text-align: center;
							margin:10px;
						  }
  
						 .section{border-top: 1px dotted black; margin-top:20px; margin-bottom:30px;}
  
						 .logo {
							width: 160px; 
							height: 170px;
						  }
						
						  h1,h3{Color:green;}
						  h3, p{ margin-left:10px; }
						  h3{margin-top:5px; margin-bottom:5px;}
						  h2{margin-bottom:10px; margin-top:5px;}
	
						</style>
						</head>");

			sb.Append($@"<body>
						<div class=""container"">
							<img src=""{logoPath}"" alt=""Background Image"" class=""background-image"">

							<div class=""header"">
								<h1>Bangladesh Army International University of Science and Technology</h1>
								<h2>Admit Card</h2>
								<img class=""logo"" src=""{profilePath}"" alt=""""/>
							</div>
	
							<div class=""section"">
									<p><b>Address: </b>Cumilla Cantonment, Cumilla</p>
									<p><b>Exam Date: </b>{ExamDate}</p>
									<p><b>Time: </b>{ExamTime}</p>
							</div>
  
							<div class=""section"">
									<h3><u>Personal Information</u></h3>
									<p><b>Registration No: </b>{viewModel.RegistrationCode}</p>
									<p><b>Name: </b>{viewModel.FullName}</p>
									<p><b>Department: </b>{viewModel.FirstDepartmentName}</p>
									<p><b>Department(Optional): </b>{viewModel.OptionalDepartmentName}</p>
									<p><b>Father's Name: </b>{viewModel.FatherName}</p>
									<p><b>Mother's Name: </b>{viewModel.MotherName}</p>
									<p><b>Gender: </b>{viewModel.Gender}</p>
									<p><b>Nationality: </b>{viewModel.Nationality}</p>
									<p><b>Religion: </b>{viewModel.Religion}</p>
									<p><b>Address: </b>{viewModel.Address}</p>
									<p><b>Date of Birth: </b>{DoB}</p>
							</div>
		
		
							<div class=""section"">
									<h3><u>College Information</u></h3>
									<p><b>Registration No: </b>{viewModel.AcademicInfo[1].RegistrationNumber}</p>
									<p><b>School Name: </b>{viewModel.AcademicInfo[1].InstitutionName}</p>
									<p><b>Passing Year: </b>{viewModel.AcademicInfo[1].PassingYear}</p>
									<p><b>Group: </b>{viewModel.AcademicInfo[1].Group}</p>
									<p><b>Grade: </b>{viewModel.AcademicInfo[1].Result}</p>
									<p><b>Scale: </b>{viewModel.AcademicInfo[1].Scale}</p>
									<p><b>Board: </b>{viewModel.AcademicInfo[1].Board}</p>
							</div>
		
		
							<div class=""section"">
									<h3><u>School Information</u></h3>
									<p><b>Registration No: </b>{viewModel.AcademicInfo[0].RegistrationNumber}</p>
									<p><b>School Name: </b>{viewModel.AcademicInfo[0].InstitutionName}</p>
									<p><b>Passing Year: </b>{viewModel.AcademicInfo[0].PassingYear}</p>
									<p><b>Group: </b>{viewModel.AcademicInfo[0].Group}</p>
									<p><b>Grade: </b>{viewModel.AcademicInfo[0].Result}</p>
									<p><b>Scale: </b>{viewModel.AcademicInfo[0].Scale}</p>
									<p><b>Board: </b>{viewModel.AcademicInfo[0].Board}</p>
							</div>
	
	
							<div class=""section"">
									<h3><u>Instructions</u></h3>
									<ul>
									  <li>Students must bring this admit card along with a valid ID proof to the examination hall.</li>
									  <li>Reach the examination venue at least 30 minutes before the scheduled time.</li>
									  <li>Electronic devices such as mobile phones, calculators, etc., are strictly prohibited inside the examination hall.</li>
									  <li>Follow all examination rules and regulations strictly.</li>
									</ul>
							</div>
					  </div>    
					</body>
					</html>");

            return sb.ToString();
        }
    }
}
