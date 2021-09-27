using System;

namespace Project1.Services.Abstract
{
    public interface IUploadFileValidator
    {
        bool Validate(string fileName);
    }
}
