namespace AlishoxTransServisDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("AutoBase")]
    public partial class AutoBase : INotifyPropertyChanged
    {
        private DateTime? licenseDate;
        private DateTime? insuranceDate;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Number { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LicenseDate
        {
            get => licenseDate;
            set
            {
                licenseDate = value;
                RaisePropertyChanged("ExpiredDate");
                RaisePropertyChanged("LicenseExpiredDate");
            }
        }

        [Column(TypeName = "date")]
        public DateTime? InsuranceDate
        {
            get => insuranceDate;
            set
            {
                insuranceDate = value;
                RaisePropertyChanged("ExpiredDate");
                RaisePropertyChanged("LicenseExpiredDate");
            }
        }

        public string ExpiredDate { get => (LicenseDate.Value - DateTime.Now).TotalDays.ToString("0 days"); }
        public string LicenseExpiredDate { get => (InsuranceDate.Value - DateTime.Now).TotalDays.ToString("0 days"); }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
