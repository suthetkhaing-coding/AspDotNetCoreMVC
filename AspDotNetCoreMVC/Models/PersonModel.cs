using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AspDotNetCoreMVC.Models
{
    [Table("tblPerson")]
    public class PersonModel
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [DisplayName("Person Number")]
        public string PersonNo { get; set; }        
        [Required]
        [DisplayName("အမည်")]
        public string PersonName { get; set; }
        [Required]
        [DisplayName("ကျား/မ")]
        public string Gender { get; set; }
        [Required]
        [DisplayName("အိမ်ထောင်ရေး")]
        public string MaritalStatus { get; set; }
        [Required]
        [DisplayName("လူမျိုး")]
        public string Race { get; set; }
        [Required]
        [DisplayName("ကိုးကွယ်သည့်ဘာသာ")]
        public string Religion { get; set; }
        [Required]
        [DisplayName("မှတ်ပုံတင်အမှတ်")]
        public string NrcNo { get; set; }
        [DisplayName("ပုံ")]
        [NotMapped]
        public IFormFile Photo1 { get; set; }
        public string? Photo { get; set; }
        [Required]
        [DisplayName("မွေးသက္ကရာဇ်")]
        public DateTime DOB { get; set; }
        [Required]
        [DisplayName("မွေးဖွားသည့်ဇာတိ")]
        public string POB { get; set; }
        [Required]
        [DisplayName("အရပ်အမြင့် ပေ")]
        public string Height_ft { get; set; }
        [Required]
        [DisplayName("အရပ်အမြင့် လက်မ")]
        public string Height_in { get; set; }
        [DisplayName("သွေးအမျိုးအစား")]
        public string? BloodType { get; set; }
        [DisplayName("ထင်ရှားသည့်အမှတ်အသား")]
        public string? DistinguishMark { get; set; }
        [DisplayName("အလုပ်ရောက်ရက်စွဲ")]
        public DateTime? JoinDate { get; set; }
        [Required]
        [DisplayName("အဖအမည်")]
        public string FatherName { get; set; }
        [Required]
        [DisplayName("အမိအမည်")]
        public string MotherName { get; set; }
        [DisplayName("ယခင်အလုပ်အကိုင်")]
        public string? PrevOccupation { get; set; }
        [DisplayName("အခြားအတတ်ပညာ")]
        public string? OtherQualification { get; set; }
        [Required]
        [DisplayName("အမြဲတမ်းနေရပ်လိပ်စာ")]
        public string PerAddress { get; set; }
        [Required]
        [DisplayName("မြို့နယ်")]
        public string TownshipCode { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        [DisplayName("အမွေစားအမွေခံအမည်")]
        public string? Heir_Person { get; set; }
        [DisplayName("အလုပ်ဝင်ရက်စွဲ")]
        public DateTime? EmployDate { get; set; }
        
        [DisplayName("စတင်ဝင်ရောက်သည့်ဒေသ")]
        public string? duty_start { get; set; }
        [DisplayName("အာမခံ")]
        public decimal? insurance { get; set; }
        [DisplayName("Policy Number")]
        public string? policyno { get; set; }
    }
}
