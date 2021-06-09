using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LandeSatis.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Firmalar")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Firmalar : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Firmalar(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private string _firmaAdi;
        [XafDisplayName("Firma Adı")]
        public string FirmaAdi
        {
            get { return _firmaAdi; }
            set { SetPropertyValue(nameof(FirmaAdi), ref _firmaAdi, value); }
        }

        private Ulkeler _ulkeAdi;
        [XafDisplayName("Ülke Adı")]
        public Ulkeler UlkeAdi
        {
            get { return _ulkeAdi; }
            set { SetPropertyValue(nameof(UlkeAdi), ref _ulkeAdi, value); }
        }


        private string _adresBilgisi;
        [XafDisplayName("Adres Bilgisi")]
        public string AdresBilgisi
        {
            get { return _adresBilgisi; }
            set { SetPropertyValue(nameof(AdresBilgisi), ref _adresBilgisi, value); }
        }

        [XafDisplayName("Firma Çalışanları")]
        [Association("Firmalar-FirmaCalisanlari")]
        public XPCollection<FirmaCalisanlari> FirmaCalisanlaris
        {

            get
            {
                return GetCollection<FirmaCalisanlari>(nameof(FirmaCalisanlaris));
            }
        }

    }
}