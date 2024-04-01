using System.Text;

namespace IdentityAPP.Helper
{
    public static class EmailBody
    {
        public static string ApplicantApprovalBody(string name, string registrationNo, string email, string password, string Admin, string AddmissionDate)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                      <meta charset=""UTF-8"">
                      <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                      <title>Applicant Registration</title>
                      <style>
                        body {
                          font-family: Arial, sans-serif;
                          background-color: #f4f4f4;
                          margin: 0;
                          padding: 0;
                        }

                        .container {
                          max-width: 600px;
                          margin: 20px auto;
                          background-color: #fff;
                          padding: 20px;
                          border-radius: 8px;
                          box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                        }

                        h1 {
                          color: #333;
                        }

                        p {
                          color: #666;
                        }

                        .cta-button {
                          display: inline-block;
                          padding: 10px 20px;
                          background-color: #3498db;
                          color: #fff;
                          text-decoration: none;
                          border-radius: 4px;
                          margin-top: 20px;
                        }
                      </style>
                    </head>");


            sb.Append($@"<body>
                      <div class=""container"">
                        <p>Dear {name},</p>
                        <p>Thank you for applying! We are excited to have you on board. Your Registration Number is: {registrationNo}</p>
                        <p>Your Admission Exam Date is on {AddmissionDate}</p>
                        <p>Please download your Admit card from link below:</p>
                        <a href=""https://localhost:7263/UserRegistration/GetApplicantAdmitCard"" class=""cta-button"">Click To Download Admit Card</a>
                        <p>User Email: {email} <br>password: {password} </p>

                        <p>If the button above doesn't work, you can also copy and paste the following link into your browser:</p>
                        <p>https://localhost:7263/UserRegistration/GetApplicantAdmitCard</p>
                        <p>Best Wishes for your upcomming Admission Exam</p>
                        <p>Best regards,<br>{Admin}, <br>HR & Admin, BAIUST</p>
                      </div>
                    </body>
                    </html>");
                    

            return sb.ToString();
        }
    }
}
