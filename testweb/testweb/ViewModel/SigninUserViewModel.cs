using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace testweb.ViewModel
{
    public class SigninUserViewModel
    {


        [Required(ErrorMessage = "نام کاربری وارد نمایید")]
        public string username { get; set; }

        [Required(ErrorMessage = "رمز را وارد نمایید")]
        public string password { get; set; }
       
        public bool rermemberme { get; set; }


    }
}
