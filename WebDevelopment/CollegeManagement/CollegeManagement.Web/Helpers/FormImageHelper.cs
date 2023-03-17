using CollegeManagement.Web.Models;

namespace CollegeManagement.Web.Helpers
{
    public class FormImageHelper
    {
        public static string SaveProfileImage(IFormFile image)
        {
            if (image is null)
                return string.Empty;
            //save avatar to physical folder
            var filename = $"{Guid.NewGuid()}_{image.FileName}";
            var appFolder = Directory.GetCurrentDirectory();
            var imageFolderPathRelative = $"/images/profiles/{filename}";
            var imageFolderPathAbsolute = appFolder + "/wwwroot/" + imageFolderPathRelative;

            var avatar = File.Create(imageFolderPathAbsolute);
            image.CopyTo(avatar);
            avatar.Close();
            return imageFolderPathRelative;
        }
    }
}
