using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace webDb
{
    public class CL
    {
         public Guid Id { get; set; }



    }


    public class tblSeller : CL {

        [DisplayName("عنوان")]
        [Column(TypeName = "NVARCHAR(200)")]
        public string Title { get; set; }
        [DisplayName("درصد همکاری")]
        public double Darsad { get; set; }
         
    }

    public class tblSales : CL
    {
        [DisplayName("فروشنده")]
        public Guid tblSellerId { get; set; }
        [DisplayName("فروشنده")]
        public tblSeller? tblSeller { get; set; }

        [DisplayName("زمان")]
        public DateTime Time { get; set; }
        [DisplayName("توضیحات")]
        [Column(TypeName ="NVARCHAR(200)")]
        public string Des { get; set; }
        [DisplayName("مبلغ فروش")]
        public decimal? MabFrosh { get; set; }
        [DisplayName("هزینه ها")]
        public decimal? MabH { get; set; }
        [NotMapped]
        [DisplayName("حاشیه فروش")]
        public decimal? MabHashie { get { return MabFrosh - MabH; } }
        [DisplayName("درصد همکاری")]
        public double? Darsad { get; set; }
        [DisplayName("بدهکار")]
        public decimal? Bed { get; set; }
        [DisplayName("بستانکار")]
        public decimal? Bes { get; set; }
        [DisplayName("مانده")]
        public decimal Mande { get; set; }

    }
}
