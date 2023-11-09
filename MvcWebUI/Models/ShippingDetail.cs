using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace MvcWebUI.Models
{
    public class ShippingDetail
    {
        //[Required(ErrorMessage ="İsim gerekli")]
        public string FirstName { get; set; }
		//[Required(ErrorMessage = "Soyisim gerekli")]
		public string LastName { get; set; }
		//[Required(ErrorMessage = "Email gecersiz")]
		//[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
		//[Required(ErrorMessage = "Şehir gerekli")]
		public string City { get; set; }
		//[Required(ErrorMessage = "Adres gerekli")]
		//[MinLength(10, ErrorMessage="Minimum 10 karakter olmalı")]
		public string Address { get; set; }
		//[Required(ErrorMessage = "Yaşınız gerekli")]
		//[Range(18,65, ErrorMessage="18-65 yaş aralığı giriniz")]
        public int Age { get; set; }
    }
}
