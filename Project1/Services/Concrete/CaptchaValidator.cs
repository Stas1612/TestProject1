using Project1.Services.Abstract;

namespace Project1.Services.Concrete
{
    public class CaptchaValidator : IUploadFileValidator
    {
        private readonly string _validateItem;

        public CaptchaValidator()
        {
            _validateItem = "captcha";
        }

        public bool Validate(string fileName)
        {
            return ContainsValidItemInFileName(fileName);
        }

        private bool ContainsValidItemInFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName) || string.IsNullOrWhiteSpace(_validateItem))
                return false;

            if (fileName.ToLower().Contains(fileName.ToLower()))
                return true;

            return false;
        }
    }
}
