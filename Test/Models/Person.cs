using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Models
{
    public class Person
    {
        public int Id { get; set; }
        [DisplayName("姓名")]
        [Required(ErrorMessage ="請輸入姓名")]
        public string Name { get; set; }
        [DisplayName("年齡")]
        [Required(ErrorMessage = "請輸入年齡")]
        [Range(18,99,ErrorMessage = "請輸入年齡,至少18歲")]
        public int Age { get; set; }
    }
}