using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace testweb.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "نام کاربری وارد نمایید")]
        public string? username { get; set; }
        [Required(ErrorMessage = "رمز عبور را وارد نمایید")]
        public string? password { get; set; }


        [Required(ErrorMessage = "نام خود را وارد نمایید")]
        public string? firstName { get; set; }
        [Required(ErrorMessage = "نام خوانوادگی وارد نمایید")]
        public string? lastname { get; set; }
    }
}
