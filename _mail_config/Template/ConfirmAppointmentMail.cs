namespace myProject._mail_config.Template;

public class ConfirmAppointmentMail
{
    public const string body = "<!DOCTYPE HTML><html><head><meta charset=\"UTF-8\"/></head><body style=\"font-family: Arial;\">" +
                               "<table align=\"center\" border=\"1\" cellpadding=\"0\" cellspacing=\"0\" style=\" border: transparent; border-radius: 15px; background: linear-gradient(to right, #eedcec, #dacee6); width: 600px; text-align: center; \"> " +
                               "<tr><td><h1 style=\"color: #2e3454; letter-spacing: 5px; font-weight: bold;\">FIVE SUPERHERO</h1></td></tr><tr><td style=\"text-align: center;\"><table style=\"border: transparent; border-radius: 15px; background: #fff; display: inline-block; border-spacing: 0px; margin: 0 50px;\"><tr>" +
                               "<td><img alt=\"\"src=\"https://imagedelivery.net/KvFcUzLL2k6Q3_ROU5d8cw/37c9970f-8e56-4543-bff5-85993b7bc600/public\"style=\"border-radius: 15px 15px 0 0; display: block;\" width=\"100%\"></td></tr>" +
                               "<tr><td><table style=\"text-align: center; display: inline-block;\"><tr><td><p style=\"color: #2e3454;\">Support | Terms and Conditions | Contact Us</p></td>" +
                               "</tr><tr><td><div style=\"font-weight:bold;font-size:20px;line-height:25px;text-align:center;color:#2e3454;\">CONFIRM EMAIL!</div></td></tr>" +
                               "<tr><td><div class=\"content\"><p style=\"color: #2e3454;\">Welcome my_email_replace<br><br</p>" +"" +
                               "<div>A new user just sent in my_email_replace a request for advice on insurance coverage my_insurance_replace</div>" + 
                               "<div>Please access your account to check and do your work</div>" +
                               "Wish you have a good experience on our platform!</p></div></td></tr><tr>" +
                               "<td style=\"color: #2e3454;\">Best Regards,<br>FSH Team.</td></tr></table></td></tr></table></td></tr>" +
                               "<tr><td><P style=\"color: #2e3454;\">Copyright @2022 FSH Auction</P></td></tr></table></body></html>";
}